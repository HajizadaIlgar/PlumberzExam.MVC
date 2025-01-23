using System.ComponentModel.DataAnnotations;

namespace Plumberz.BL.ViewModels.Accounts
{
    public class LoginVM
    {
        [Required, MaxLength(64)]
        public string UserNameOrEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
