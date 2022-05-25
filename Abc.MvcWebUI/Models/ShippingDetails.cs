using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class ShippingDetails
    {
        
        public string UserName { get; set; }
        [Required(ErrorMessage ="Lütfen Doldurunuz...")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen Doldurunuz...")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen Doldurunuz...")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen Doldurunuz...")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Lütfen Doldurunuz...")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Lütfen Doldurunuz...")]
        public string PostaKodu { get; set; }

    }
}