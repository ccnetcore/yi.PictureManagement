using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Jift.Model
{
    public class mail
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "学生姓名")]
        public string uname { get; set; }

        [Display(Name = "邮箱账号")]
        public string smail { get; set; }

        [Display(Name = "班级id")]
        public int classid { get; set; }

    }
}
