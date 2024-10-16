using JeugdLinkApp.Models;
using JeugdLinkApp.Pages.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace JeugdLinkApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly string _connstring;
        
        public RegisterModel(IConfiguration configuration)
        {
            _connstring = configuration.GetConnectionString("DefaultConnection");
      
        }

        [BindProperty]
        public User newuser { get; set; }



        public void OnGet()
        {
        }

        public IActionResult OnPost()

        {
           if (!ModelState.IsValid)
            {
             
                return Page();

            }

            try
            {
                using (var conn = new MySqlConnection(_connstring))
                {
                    conn.Open();
                    string query = @"INSERT INTO Users (Firstname, Lastname,Email,Password,DateOfBirth) VALUES(@Firstname, @Lastname,@Email,@Password,@DateOfBirth)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Firstname", newuser.firstname);
                        cmd.Parameters.AddWithValue("@Lastname", newuser.lastname);
                        cmd.Parameters.AddWithValue("@Email", newuser.email);
                        cmd.Parameters.AddWithValue("@Password", newuser.password);
                        cmd.Parameters.AddWithValue("@DateOfBirth", newuser.dateofbirth);

                        cmd.ExecuteNonQuery();
                    }

                }
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,$"An error occured: { ex.Message }"); 
                return Page();
            }
           
        }
    }
}
