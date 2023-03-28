using Shoppers12.Data;
using Shoppers12.Models.Data;
using Microsoft.AspNetCore.Identity;


namespace Shoppers12.Data
{
    public static class SeedData
    {
        static Shoppers12DbContext? _context;
        static RoleManager<IdentityRole>? _roleManager;
        static UserManager<IdentityUser>? _userManager;
        public static async Task EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                _context = scope.ServiceProvider.GetRequiredService<Shoppers12DbContext>();
                _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await AddRoleAsync();
                await CreateIdentityRecordAsync(Roles.Client, "student@pxl.be", "Student123!", Roles.Client);
                await CreateIdentityRecordAsync(Roles.Admin, "admin@pxl.be", "Admin456!", Roles.Admin);



             

            }
        }

        public static async Task AdRollAsync()
        {
            //_rolemanager count = 1, idk maar door dit werkt het niet
            if (_roleManager != null && !_roleManager.Roles.Any())
            {
                await AddRoleAsync(Roles.Client);
                await AddRoleAsync(Roles.Admin);

            }
        }
        public static async Task AddRoleAsync(string rolename)
        {
            if (_roleManager != null && !await _roleManager.RoleExistsAsync(rolename))
            {
                IdentityRole role = new IdentityRole(rolename);
                await _roleManager.CreateAsync(role);
            }
        }

        private static async Task CreateIdentityRecordAsync(string userName, string email, string pwd, string role)
        {

            if (_userManager != null && await _userManager.FindByEmailAsync(email) == null &&
                    await _userManager.FindByNameAsync(userName) == null)
            {
                var identityUser = new IdentityUser() { Email = email, UserName = userName };
                var result = await _userManager.CreateAsync(identityUser, pwd);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);
                }
            }
        }
        public static List<Gebruiker> GebruikerOpvullen = new List<Gebruiker>()
        {
            new Gebruiker
            {
                //GebruikerId = automatisch gegenereerd
                Naam = "Tom",
                Voornaam = "Quarem",
                Email = "Admin@pxl.be"
            },
            new Gebruiker
            {
                //GebruikerId = automatisch gegenereerd
                Naam = "Thomas",
                Voornaam = "Knoops",
                Email = "Thomas.Knoops@student.pxl.be"
            },
             new Gebruiker
            {
                //GebruikerId = automatisch gegenereerd
                Naam = "Evi",
                Voornaam = "Boelen",
                Email = "Evi.Boelen@student.pxl.be"
            }
        };

        public static Client ClientenOpvullen = new Client()
        {
            Gebruiker = GebruikerOpvullen[0]
        };

        public static Admin LectorOpvullen = new Admin()
        {
            Gebruiker = GebruikerOpvullen[1]
        };
      
    }
}

