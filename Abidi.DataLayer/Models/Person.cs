using Abidi.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abidi.DataLayer.Models
{
  public class Person : IBaseEntity
    {
        public int Id { get; set; }

        [MaxLength(300)]
        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string FirstName { get; set; }

        [MaxLength(300)]
        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string LastName { get; set; }

        
        [MaxLength(10)]
        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "کد پرسنلی باید حداقل 4 و حداکثر 10 کاراکتر باشد")]
        public string PersonalCode { get; set; }

        [MaxLength(10)]
        [Display(Name = "کد ملی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NationalCode { get; set; }


        public virtual List<PersonFile> PersonFiles { get; set; }
        public Person()
        {

        }


        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
