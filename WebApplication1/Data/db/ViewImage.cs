using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.db
{
    public class ViewImage
    {
        [Key]
        public int ID { get; set; }


        public Nullable<int> ServerID { get; set; }

        [Display(Name = "عنوان تصویر")]
        public string Title { get; set; }

        [Display(Name = "نام فیزیکی")]
        [Required]
        public string Filename { get; set; }

        [Display(Name = "نام جایگزین ")]
        public string Alt { get; set; }


        [ForeignKey(nameof(ServerID))]
        public virtual OtherServer Tbl_OtherServer { get; set; }

        public virtual ICollection<Gallery> Tbl_Gallery { get; set; }
    }
}
