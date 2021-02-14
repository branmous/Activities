namespace Actividades.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entidades;
    using Helpers;
    using Microsoft.AspNetCore.Identity;
    

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {

            //Valida si la base de datos esta creada.
            await this.context.Database.EnsureCreatedAsync();
            await this.userHelper.CheckRoleAsync("Admin");


            var user = await this.userHelper.GetUserByEmailAsync("branmous101@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    Name = "Brandon",
                    LastName = "Montoya",
                    Email = "branmous101@gmail.com",
                    UserName = "branmous101@gmail.com"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se pudo crear el usuario");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");

                var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
                if (!isInRole)
                {
                    await this.userHelper.AddUserToRoleAsync(user, "Admin");
                }
            }
        }
    }

}
