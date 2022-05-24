using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class Login
    {
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        
        [DisplayName("BEni Hatırla")]
        public string RememberMe { get; set; }
    }
}