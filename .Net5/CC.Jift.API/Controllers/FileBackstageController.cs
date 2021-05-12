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
    public class FileBackstageController : BaseController
    {

        private IMyFileBll myFileBll;
        public FileBackstageController(IMyFileBll _myFileBll)
        {
            IsCheck = 2;
            myFileBll = _myFileBll;
        }
        //public JsonResult Index()//展示全部数据
        //{
        //    LogHelper.WriteLog("现在是观察者模式下的");
        //    return Json("888");

        //}
        [HttpPost]
        public JsonResult search(int page, int size, string uname, int? sub, string time)//根据条件返回数据
        {
         
            var mydata = myFileBll.GetPageEntities<int>(size, page, out int total,

               u => (uname == null ? true : u.uname.Contains(uname)) && (sub == null ? true : u.sub == sub) && (admlv == 0 ? true : u.classid == admlv)
                , o => o.id, true).ToArray();
            object dataend = JsonFactory.getResult(200, true, "查询成功", total, mydata);
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult del(int id)//根据id删除数据
        {

           var mydata = myFileBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend;
            if (myFileBll.Delete(mydata))
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
        public JsonResult add(string uname, string time,  int sub)//添加数据
        {
            myfile _myfile = new myfile();
            _myfile.uname = uname;
            _myfile.sub = sub;
            _myfile.time = time;
            _myfile.classid = admlv;
            myFileBll.Add(_myfile);
            object dataend = JsonFactory.getResult(200, true, "添加成功");
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult getStudentById(int id)//根据id得到数据
        {
            var mydata = myFileBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend = JsonFactory.getResult(200, true, "查询成功", mydata);
            return Json(dataend);
        }
        [HttpPost]
        public JsonResult update(int id,string uname, string time,int sub)//更新数据
        {
            var mydata = myFileBll.GetEntities(n => n.id == id).FirstOrDefault();
            mydata.uname = uname;
            mydata.time = time;
            mydata.sub = sub;
            myFileBll.Update(mydata);
            object dataend = JsonFactory.getResult(200, true, "修改成功");
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult CreateZip()//进行压缩
        {
            Common.SaveFile.CreateZip(admlv);
            return Json(JsonFactory.getResult(200, true, admlv.ToString()));
        }
        [HttpGet]
        public JsonResult DeleteAll()//重置全部文件
        {
            if (Common.SaveFile.DeleteAll(admlv))
            {
                var myEntities = myFileBll.GetEntities(n => n.classid == admlv).ToList();
                myFileBll.UpdataList(myEntities);
                return Json(JsonFactory.getResult(200, true, "文件全部重置成功!"));
            }
            else
            {
                return Json(JsonFactory.getResult(200, false, "文件全部重置失败!"));
            }
        }
    }
}
