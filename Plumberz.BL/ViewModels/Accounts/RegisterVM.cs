using System.ComponentModel.DataAnnotations;

namespace Plumberz.BL.ViewModels.Accounts
{
    public class RegisterVM
    {
        [Required, MaxLength(64), MinLength(3, ErrorMessage = "Minimum 3 simvol daxil edilmelidir !")]
        public string FullName { get; set; }
        [Required, MaxLength(256), MinLength(1, ErrorMessage = "Minimum 1 simvol daxil edilmelidir !")]
        public string UserName { get; set; }
        [Required, EmailAddress, MaxLength(256)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string RePassword { get; set; }

    }
}
