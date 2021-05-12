using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading;

namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ImageController : BaseController
    {
        private IStudentBll studentBll;
        public ImageController(IStudentBll _studentBll)
        {
            IsCheck = 1;
            studentBll = _studentBll;
        }
        [HttpGet]
        public async Task<JsonResult>   Index()//展示全部数据
        {
 
            var students =await studentBll.GetEntities(n => n.id > 0 && n.classid ==classid ).ToListAsync();
            return Json(JsonSerializer.Serialize( students));
        }
        [HttpGet]
        public JsonResult Show(int id)//进入展示页面
        {
            var student = studentBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
            return Json(JsonSerializer.Serialize(student));
        }
        [HttpGet]
        public async Task<JsonResult> SubTotal()//返回提交总数
        {
            var students = await studentBll.GetEntities(n => n.sub == 1 && n.classid == classid).ToListAsync();
            return Json(students.Count().ToString());
        }
        [HttpGet]
        public async Task<JsonResult> NotSubTotal()//返回未提交总数
        {
            var students = await studentBll.GetEntities(n => n.sub == 0 && n.classid == classid).ToListAsync();
            return Json(students.Count().ToString());
        }
        [HttpPost]
        public async Task<JsonResult> Index(string myimg, string name)
        {
            var stu = await studentBll.GetEntities(u => u.name == name && u.classid == classid).FirstOrDefaultAsync();
            if (myimg == null)
                return Json("no");
            if (stu != null)
            {
                string diffImg = "1";
                stu.sub = 1;
                stu.time = DateTime.Now.ToString();
                Common.SaveImage.ByStringToSave(name, myimg, classid);
                //if (System.IO.File.Exists("./wwwroot/StudentImage1/陈淳.jpg"))
                //    if (Common.SaveImage.Compare("./wwwroot/StudentImage/" + name + ".jpg", "./wwwroot/StudentImage/陈淳.jpg") > 20)
                //    {
                //        diffImg = "2";
                //    }
                studentBll.Update(stu);
                return Json("ok" + diffImg);
            }
            else
            {
                return Json("no");
            }

        }
    }
}
