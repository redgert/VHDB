using System.ComponentModel.DataAnnotations;

namespace VocableMVC.Controllers
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}