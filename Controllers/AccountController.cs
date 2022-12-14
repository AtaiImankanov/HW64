using homework_64_Atai.Models;
using homework_64_Atai.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LabInsta.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private string[] roles = new[] { "company", "worker" };
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)

        {

            _userManager = userManager;

            _signInManager = signInManager;
        }


        [HttpGet]

        public IActionResult Register()

        {
           

            return View();

        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel model)

        {

            if (ModelState.IsValid)

            {

                User user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber,
                    Avatar = model.Avatar,
                    Role = model.Role
                };
                if (user.Avatar == null)
                {
                    user.Avatar = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Anonymous_emblem.svg/640px-Anonymous_emblem.svg.png";
                }
                var result = await _userManager.CreateAsync(user, model.Password);
                

                //Создание пользователя средствами Identity на основе объекта пользователя и его пароля

                //Возвращает результат выполнения в случае успеха впускаем пользователя в систему

                if (result.Succeeded)

                {
                    if (user.Role == "Company")
                    {
                        await _userManager.AddToRoleAsync(user,"company");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "worker");
                    }
                   
                    await _signInManager.SignInAsync(user, false);
                    

                    return RedirectToAction("Index", "Home");

                }

                foreach (var error in result.Errors)

                    ModelState.AddModelError(string.Empty, error.Description);

            }

            return View(model);
 
        }
        [HttpGet]

        public IActionResult Login(string returnUrl = null)

        {

            return View(new LoginViewModel { ReturnUrl = returnUrl });

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)

        {

            if (ModelState.IsValid)

            {
                var users = _userManager.Users;
                User user = await _userManager.FindByEmailAsync(model.Email);

                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(

                    user,

                    model.Password,

                    model.RememberMe,

                    false

                    );

                if (result.Succeeded)

                {

                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))

                    {

                        return Redirect(model.ReturnUrl);

                    }



                    return RedirectToAction("Index", "Home");

                }

                ModelState.AddModelError("", "Неправильный логин и (или) пароль");

            }

            return View(model);

        }



        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<IActionResult> LogOff()

        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");

        }
        public bool EmailValid(string email)
        {
            foreach (var e in _userManager.Users)
            {
                if (e.Email == email)
                {
                    return false;
                }
            }
            return true;
        }
        public bool NameValid(string name)
        {
            foreach (var e in _userManager.Users)
            {
                if (e.UserName == name)
                {
                    return false;
                }
            }
            return true;
        }
        public bool PhoneNumberValid(string name)
        {
            foreach (var e in _userManager.Users)
            {
                if (e.PhoneNumber == name)
                {
                    return false;
                }
            }
            return true;
        }
       
    }
}
