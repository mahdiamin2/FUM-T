using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.db
{
    public class Teater
    {
        [Key]
        public int TeaterId { get; set; }


        [Required]
        [Display(Name = " نام تئاتر")]
        public string TeaterName { get; set; }


        [Required]
        [Display(Name = " قیمت")]
        public double Price { get; set; }


        [Required]
        [Display(Name = " تاریخ")]
        public DateTime TTime { get; set; }

 
        [Display(Name = " کارگردان")]
        public string Director { get; set; }


        
        [Display(Name = " نویسنده")]
        public string Writer { get; set; }


        
        [Display(Name = " بازیگران")]
        public string Cast { get; set; }


        
        [Display(Name = " توضیحات")]
        public string Explain { get; set; }

        [Required]
        [Display(Name = " ظرفیت")]
        public int Capacity { get; set; }


        [Required]
        [Display(Name = " فعال/غیرفعال")]
        public Boolean Active { get; set; }

        [Required]
        [Display(Name = " آدرس")]
        public int Address { get; set; }


        //ارتباط با سایر جداول
        public virtual ICollection<Shopping> Tbl_Shopping { get; set; }

        public virtual ICollection<Invoice> Tbl_Invoice { get; set; }
    }
}
