using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Plugins;

namespace WebApplication1.Data.db
{
    public class OtherServer
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMsg.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrorMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrorMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*", ErrorMessage = ErrorMsg.RegeMsg)]
        public string Title { get; set; }


        [Display(Name = "ادرس سرور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMsg.RequierdMsg)]
        [MaxLength(150, ErrorMessage = ErrorMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrorMsg.MinLenghtMsg)]
        // [RegularExpression(@"[\w\._\:]*", ErrorMessage = ErrorMsg.RegeMsg)]
        public string IP { get; set; }


        [Display(Name = "نام کاربری")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrorMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrorMsg.MinLenghtMsg)]
        [RegularExpression(@"[\w_\-\@\.]*", ErrorMessage = ErrorMsg.RegeMsg)]
        public string UserName { get; set; }


        [Display(Name = "کلمه ی عبور")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMsg.RequierdMsg)]
        [MinLength(4, ErrorMessage = ErrorMsg.MinLenghtMsg)]
        public string Password { get; set; }


        [Display(Name = "مسیر")]
        [MaxLength(500, ErrorMessage = ErrorMsg.MaxLenghtMsg)]
        public string Path { get; set; }


        [Display(Name = "نوع")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMsg.RequierdMsg)]
        [MaxLength(100, ErrorMessage = ErrorMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrorMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_]*", ErrorMessage = ErrorMsg.RegeMsg)]
        public string Type { get; set; }

        [Display(Name = "دامنه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrorMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrorMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrorMsg.MinLenghtMsg)]
        [RegularExpression(@"((H|http://)|(Hhttps://))[\wا-ی\-_\./]*", ErrorMessage = ErrorMsg.RegeMsg)]
        public string HttpDomain { get; set; }


        public virtual ICollection<ViewImage> Tbl_ViewImage { get; set; }
    }
}
