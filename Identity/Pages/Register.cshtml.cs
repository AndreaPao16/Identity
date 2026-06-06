using Identity.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<MyUser> _userManager;

        [BindProperty]
        public RegisterDTO Register { get; set; }
        public string ReturnUrl { get; set; }

        public RegisterModel(UserManager<MyUser> userManager)
        =>
            _userManager = userManager;

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Register.Password != Register.Password2)
            {
                throw new Exception("Las contraseñas no coinciden");
            }

            var user = new MyUser
            {
                Email = Register.Email,
                UserName = Register.Email,
                PrimerNombre = Register.PrimerNombre,
                SegundoNombre = Register.SegundoNombre,
                Apellido = Register.Apellido
            };


            var res = await _userManager
                .CreateAsync(user, Register.Password);

            if (ReturnUrl == null)
            {
                ReturnUrl = "/";
            }

            return LocalRedirect(ReturnUrl);
        }
    }
}
