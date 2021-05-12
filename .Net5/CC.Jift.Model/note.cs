using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.Model
{
    public class note
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "发布作者")]
        public string author { get; set; }


        [Display(Name = "提交时间")]
        public string time { get; set; }


        [Display(Name = "标题")]
        public string title { get; set; }

        [Display(Name = "内容")]
        public string contents { get; set; }

        [Display(Name = "班级id")]
        public int classid { get; set; }
    }
}
