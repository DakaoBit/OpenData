using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.Medicine
{
    public class UserRegisterViewModel
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號!")]
        public string UserID { get; set; }

        [DisplayName("名稱")]
        [Required(ErrorMessage = "請輸入名稱!")]
        [RegularExpression(@"^[\u4e00-\u9fa5]{0,}$", ErrorMessage = "請填寫中文名稱!")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼!")]
        [StringLength(6, ErrorMessage = "密碼 必須為 {2} 個字元至 {1} 個字元之間。", MinimumLength = 4)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "確認密碼")]
        [Compare("Password", ErrorMessage = "密碼不相符，請再確認一次!。")]
        public String ConfirmPassword { get; set; }

        [DisplayName("電子郵件")]
        [Required(ErrorMessage = "請輸入註冊的電子郵件!")]
        [EmailAddress(ErrorMessage = "請輸入正確的電子郵件格式!")]
        public string Email { get; set; }
    }
}
