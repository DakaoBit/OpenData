﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenData.Domain.ViewModels.Medicine
{
    public class LoginViewModel
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號!")]
        public string UserID { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "請輸入密碼!")]
        public string Password { get; set; }
   
    }
}
