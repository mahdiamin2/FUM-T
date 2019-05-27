using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.db
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [Display(Name = " نام دوره")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = " قیمت")]
        public double Price { get; set; }

        [Required]
        [Display(Name = " تاریخ")]
        public DateTime CTime { get; set; }


       
        [Display(Name = " نام مدرس")]
        public string TeacherName { get; set; }

        
        [Display(Name = " اطلاعات مدرس")]
        public string TeacherBio { get; set; }

        
        [Display(Name = " توضیحات")]
        public string Explain { get; set; }

        [Required]
        [Display(Name = " آدرس")]
        public int Address { get; set; }

        [Required]
        [Display(Name = " فعال / غیرفعال")]
        public Boolean Active { get; set; }

        //ارتباط با سایر جداول
        public virtual ICollection<Shopping> Tbl_Shopping { get; set; }

        public virtual ICollection<Invoice> Tbl_Invoice { get; set; }
    }
}
