using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.Common;
using CC.Jift.IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HomeController : BaseController
    {
        private IStudentBll studentBll;
        private IAdminBll adminBll;
        private IMailBll mailBll;
        public HomeController(IStudentBll _studentBll, IAdminBll _adminBll, IMailBll _mailBll)
        {
            IsCheck = 0;
            studentBll = _studentBll;
            adminBll = _adminBll;
            mailBll = _mailBll;
        }
        [HttpGet]
        public async Task<JsonResult> MyUser(string uname, int classid)//查询是否该学生存在本班
        {
            if (uname == null)
            {
                return Json("no");
            }
            var students = await studentBll.GetEntities(n => n.name == uname && n.classid == classid).FirstOrDefaultAsync();
            if (students != null)
            {
                return Json("ok");
            }
            else
            {
                return Json("no");
            }
        }
        [HttpPost]
        public async Task<JsonResult> Login([FromForm] string pwd, [FromForm] string uname)//管理员进行登入
        {
            var ad = await adminBll.GetEntities(n => n.uname == uname).FirstOrDefaultAsync();
            if (ad == null)
            {
                return Json(JsonFactory.getResult(200, false, "用户不存在"));
            }
            else
            {
                if (ad.pwd == pwd)
                {
                    string token = TokenMake.getToken();
                    HttpContext.Session.SetString(token, uname);
                    HttpContext.Session.SetString("admlv", (await getLvByToken(token)).ToString());//存入一个管理员的权限等级！
                    return Json("{\"msg\": \"ok\",\"token\": \"" + token + "\"}");
                }
                else
                {
                    return Json(JsonFactory.getResult(200, false, "密码错误!"));
                }
            }
        }
        [HttpGet]
        public async Task<int> getLvByToken(string token)//通过token返回权限等级
        {
            string uname;
            uname = HttpContext.Session.GetString(token);
            var admin = await adminBll.GetEntities(n => n.uname == uname).FirstOrDefaultAsync();
            return admin.lv;
        }
        [HttpGet]
        public JsonResult getMyClassid(string myClassid)//得到前端正在访问的页面
        {
            //HttpContext.Session.SetString("classid", myClassid);//存入一个前端正在访问的classid
            HttpContext.Response.Cookies.Append("classid", myClassid);
            return Json("ok");
        }
        [HttpGet]
        public JsonResult OutLogin()//退出登录
        {
            HttpContext.Session.Clear();
            return Json("ok");
        }
        [HttpGet]
        public JsonResult judgeLogin()//前端判定是否保存登入的session
        {
            string test = HttpContext.Session.GetString("admlv");
            if (HttpContext.Session.GetString("admlv") != null)
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
