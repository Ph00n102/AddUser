using System.ComponentModel.DataAnnotations;

namespace HosxpUi.ViewModels.Accounts
{
     public class LoginVm
    {
        //[Required]
        public string LoginName { get; set; }
        //[Required]
        public string Password { get; set; }
    }
}