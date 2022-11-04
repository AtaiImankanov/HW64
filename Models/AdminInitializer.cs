using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace homework_64_Atai.Models
{
    public class AdminInitializer

    {

        public static async Task SeedAdminUser(

              RoleManager<IdentityRole<int>> _roleManager)

        {


            var roles = new[] { "company", "worker" };



            foreach (var role in roles)

            {

                if (await _roleManager.FindByNameAsync(role) is null)

                    await _roleManager.CreateAsync(new IdentityRole<int>(role));

            }
        }
    }
}
