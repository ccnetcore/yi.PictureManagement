using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CC.Jift.Common;
using CC.Jift.IBLL;
using CC.Jift.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FileController : BaseController
    {
        private IMyFileBll myFileBll;
        private IStudentBll studentBll;
        public FileController(IMyFileBll _myFileBll,IStudentBll _studentBll)
        {
            IsCheck = 1;
            myFileBll = _myFileBll;
            studentBll = _studentBll;
        }

        [Obsolete]
        [HttpPost]
        public JsonResult Index([FromServices] IHostingEnvironment env, IFormFile formFile,string uname)//上传文件
        {
            if (formFile != null)
            {
                student studentData = studentBll.GetEntities(n => n.name == uname && n.classid == classid).FirstOrDefault();
                string filename = studentData.sid+ uname + Path.GetExtension(formFile.FileName);//文件名：张三.jpg
                string filedown = Path.Combine("StudentFile" + classid.ToString(), filename);//班级名目录下的文件名
                string filepub = Path.Combine(env.WebRootPath, "StudentFile" + classid.ToString(), filename);//完整目录
                string fileexit = Path.Combine(env.WebRootPath, "StudentFile" + classid.ToString());//班级文件目录名
                if (!Directory.Exists(fileexit))
                {
                    Directory.CreateDirectory(fileexit);
                }
                using (var stream = new FileStream(filepub, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
              
                myfile data = myFileBll.GetEntities(n => n.uname == uname && n.classid == classid).FirstOrDefault();
                data.time = DateTime.Now.ToString();
                data.sub = 1;
                data.filename = filename;
                data.filedown = filedown;

                myFileBll.Update(data);

            }
            object mydata=JsonFactory.getResult(200,true,"上传成功！");
            return Json(mydata);
        }
        [HttpGet]
        public async Task<JsonResult>  getFile()//展示全部数据
        {
            var myFiles =await myFileBll.GetEntities(n => n.id > 0 && n.classid == classid).ToListAsync();
            //return View(await students);
            return Json(myFiles);

        }

    }
}
