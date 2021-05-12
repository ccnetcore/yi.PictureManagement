using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.Model
{
    public class comment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "公告id")]
        public int noteid { get; set; }


        [Display(Name = "提交时间")]
        public string time { get; set; }

        [Display(Name = "内容")]
        public string contents { get; set; }
    }
}
