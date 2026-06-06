using Microsoft.AspNetCore.Identity;

namespace Identity.Identity
{
    public class MyUser : IdentityUser
    {

        public string PrimerNombre { get; set; }

        public string? SegundoNombre { get; set; }

        public string Apellido { get; set; }


    }
}
