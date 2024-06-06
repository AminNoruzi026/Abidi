using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abidi.DataLayer.Models
{
   public class PersonFile
    {
        [Key]
        public int FileId { get; set; }
        public int PersonId { get; set; }
        [Display(Name = "نام فایل")]
        public string FileName { get; set; }
        [Display(Name = "فرمت فایل")]
        public string FileFormat { get; set; }
        [Display(Name = "انتخاب فایل")]
        public string FileAddress { get; set; }

        public virtual Person Person { get; set; }
        public PersonFile()
        {

        }
    }
}
