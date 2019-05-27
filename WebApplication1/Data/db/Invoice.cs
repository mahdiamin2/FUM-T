using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data.db
{
    public class Invoice
    {
        [Key]
        public int ID { get; set; }
        

        [Required]
        [Display(Name = " خریدار")]
        public string UserId { get; set; }


        [Required]
        [Display(Name = " تاریخ خرید")]
        public DateTime IDate { get; set; }


        [Required]
        [Display(Name = " وضعیت")]
        public bool Status { get; set; }


        [Required]
        [Display(Name = " تعداد")]
        public int Count { get; set; }


        [Required]
        [Display(Name = " شناسه سفارش")]
        public int InvoiceId { get; set; }


        [Display(Name = " مبلغ پرداختی")]
        [Required]
        [MaxLength(15)]
        public string Price { get; set; }

        
        [Display(Name = " شناسه تراکنش")]
        [MaxLength(100)]
        public string TransactionID { get; set; }

        [Required]
        [Display(Name = " شناسه تئاتر")]
        public int TeaterId { get; set; }


        [Required]
        [Display(Name = " شناسه فیلم")]
        public int FilmId { get; set; }

        [Required]
        [Display(Name = " شناسه دوره")]
        public int CourseId { get; set; }
        //معرفی کلیدهای خارجی
        [ForeignKey(nameof(FilmId))]
        public virtual Film Tbl_Film { get; set; }


        [ForeignKey(nameof(TeaterId))]
        public virtual Teater Tbl_Teater { get; set; }


        [ForeignKey(nameof(CourseId))]
        public virtual Course Tbl_Course { get; set; }


        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser Tbl_User { get; set; }

    }
}
