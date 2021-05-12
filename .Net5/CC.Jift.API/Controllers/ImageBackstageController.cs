using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ImageBackstageController : BaseController
    {
        private IStudentBll studentBll;
        private IStudentAddOrDel studentAddOrDel;
        private IMyFileBll myFileBll;
        public ImageBackstageController(IStudentBll _studentBll, IStudentAddOrDel _studentAddOrDel, IMyFileBll _myFileBll)
        {
            IsCheck = 2;
            studentBll = _studentBll;
            studentAddOrDel = _studentAddOrDel;
            myFileBll = _myFileBll;
        }
        //public JsonResult Index()//展示全部数据
        //{
        //    LogHelper.WriteLog("现在是观察者模式下的");
        //    return Json("888");

        //}
        [HttpPost]
        public JsonResult search(int page, int size, string sid, string name, int? sub, string time, int? num)//根据条件返回数据
        {
         
            var mydata = studentBll.GetPageEntities<int>(size, page, out int total,

               u => (name == null ? true : u.name.Contains(name)) && (sid == null ? true : u.sid == sid) && (sub == null ? true : u.sub == sub) && (num == null ? true : u.num == num) && (admlv == 0 ? true : u.classid == admlv)
                , o => o.id, true).ToArray();
            object dataend = JsonFactory.getResult(200, true, "查询成功", total, mydata);
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult del(int id)//根据id删除数据
        {
            student mystudent = new student();
            mystudent = studentBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend;
            if (studentAddOrDel.Delete(mystudent))
            {
                dataend = JsonFactory.getResult(200, true, "删除成功");
            }
            else
            {
                dataend = JsonFactory.getResult(200, false, "删除失败");
            }
            return Json(dataend);

        }
        [HttpPost]
        public JsonResult add(string sid, string name, string time, int num, int sub)//添加数据
        {
            student mystudent = new student();
            mystudent.name = name;
            mystudent.num = num;
            mystudent.sid = sid;
            mystudent.sub = sub;
            mystudent.time = time;
            mystudent.classid = admlv;
            studentAddOrDel.Add(mystudent);
            object dataend = JsonFactory.getResult(200, true, "添加成功");
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult getStudentById(int id)//根据id得到数据
        {
            var mydata = studentBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend = JsonFactory.getResult(200, true, "查询成功", mydata);
            return Json(dataend);
        }
        [HttpPost]
        public JsonResult update(int id, string sid, string name, string time, int num, int sub)//更新数据
        {
            var mydata = studentBll.GetEntities(n => n.id == id).FirstOrDefault();
            mydata.sid = sid;
            mydata.name = name;
            mydata.time = time;
            mydata.num = num;
            mydata.sub = sub;
            studentBll.Update(mydata);
            object dataend = JsonFactory.getResult(200, true, "修改成功");
            return Json(dataend);
        }
    }
}
