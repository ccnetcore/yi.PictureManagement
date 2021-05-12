using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.Model
{
    public class myfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "学生姓名")]
        public string uname { get; set; }

        [Display(Name = "是否提交")]
        public int sub { get; set; }

        [Display(Name = "提交时间")]
        public string time { get; set; }

        [Display(Name = "班级id")]
        public int classid { get; set; }

        [Display(Name = "文件名")]
        public string filename { get; set; }

        [Display(Name = "文件路径")]
        public string filedown { get; set; }

    }
}
