using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.db
{
    public class Gallery
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان تصویر ")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "  نام تصویر ")]
        [Required]
        public string NamePic { get; set; }


        [Display(Name = "  تصویر شاخص ")]
        public bool Default { get; set; }

        [Required]
        [Display(Name = " شناسه تئاتر")]
        public int TeaterId { get; set; }


        [Required]
        [Display(Name = " شناسه فیلم")]
        public int FilmId { get; set; }

        [Required]
        [Display(Name = " شناسه دوره")]
        public int CourseId { get; set; }


        [Display(Name = "  شناسه تصویر ")]
        public int ViewImageID { get; set; }

        //معرفی کلیدهای خارجی
        [ForeignKey(nameof(FilmId))]
        public virtual Film Tbl_Film { get; set; }


        [ForeignKey(nameof(TeaterId))]
        public virtual Teater Tbl_Teater { get; set; }


        [ForeignKey(nameof(CourseId))]
        public virtual Course Tbl_Course { get; set; }

        [ForeignKey(nameof(ViewImageID))]
        public virtual ViewImage Tbl_Images { get; set; }

    }
}
