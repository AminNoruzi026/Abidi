using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abidi.DataLayer.Models
{
   public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام کاربری ")]
        public string UserName { get; set; }

        [Display(Name = "پسورد")]
        public string Password { get; set; }

        [Display(Name = "نام")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [Display(Name = "وضعیت")]
        public int Status { get; set; }




    }
}
