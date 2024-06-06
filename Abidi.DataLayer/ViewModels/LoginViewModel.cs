using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abidi.DataLayer.ViewModels
{
   public class LoginViewModel
    {
        [MaxLength(10)]
        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "کد پرسنلی باید حداقل 4 و حداکثر 10 کاراکتر باشد")]
        public string PersonalCode { get; set; }

        [MaxLength(10)]
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NationalCode { get; set; }
    }
}
