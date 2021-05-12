using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ImageAdmController : BaseController
    {
        private IStudentBll studentBll;
        private IAdminBll adminBll;
        private IMailBll mailBll;
        public ImageAdmController(IStudentBll _studentBll, IAdminBll _adminBll, IMailBll _mailBll)
        {
            IsCheck = 3;
            studentBll = _studentBll;
            adminBll = _adminBll;
            mailBll = _mailBll;
        }
        [HttpGet]
        public async Task<JsonResult> Reset(int id)//重置某个学生提交数据
        {
            var student = await studentBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
            student.time = "";
            student.sub = 0;
            studentBll.Update(student);
            return Json("ok");
        }
        [HttpGet]
        public async Task<JsonResult> Vip(int id)//根据id设置vip
        {
            var student = await studentBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
            student.time = "VIP用户";
            student.sub = 1;
            studentBll.Update(student);
            return Json("ok");
        }
        [HttpGet]
        public async Task<JsonResult> ResetAll()//重置所有学生提交数据
        {
            var student = await studentBll.GetEntities(u => u.id > 0 && u.classid == admlv).ToListAsync();
            studentBll.UpdataList(student);
            return Json("ok");
        }
        [HttpGet]
        public JsonResult Mail()//发送邮件
        {
            //由于邮件服务器问题，此功能暂时关闭
            //var mails = await mailBll.GetEntities(n => n.id > 0).ToListAsync();
            //foreach (mail k in mails)
            //{
            //    if (k.smail == "454313500@qq.com")
            //    {
            //        SendMail.Mail(k.smail, "亲爱的" + k.uname + "班委已开启青年大学习截图系统，请及时提交截图，提交地址：https://jiftcc.com");
            //    }
            //}
            return Json("ok");
        }
        [HttpGet]
        public JsonResult CreateZip()//进行压缩
        {
            Common.SaveImage.CreateZip(admlv);
            return Json("ok");
        }
        [HttpGet]
        public JsonResult DeleteAll()//重置全部文件
        {
            if (Common.SaveImage.DeleteAll(admlv))
            {
                return Json("ok");
            }
            else
            {
                return Json("no");
            }
        }
    }
}
