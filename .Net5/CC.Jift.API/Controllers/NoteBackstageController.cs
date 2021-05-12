using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.Common;
using CC.Jift.IBLL;
using CC.Jift.Model;
using Microsoft.AspNetCore.Mvc;


namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NoteBackstageController : BaseController
    {
        private INoteBll noteBll;

        public NoteBackstageController(INoteBll _noteBll)
        {
            IsCheck = 2;
            noteBll = _noteBll;
        }

        [HttpPost]
        public JsonResult search(int page, int size,  string author, string title, string contents, string time)//根据条件返回数据
        {

            var mydata = noteBll.GetPageEntities<int>(size, page, out int total,

               u => (author == null ? true : u.author.Contains(author)) && (title == null ? true : u.title.Contains(title)) && (contents == null ? true : u.contents.Contains(contents))  && (admlv == 0 ? true : u.classid == admlv)
                , o => o.id, true).ToArray();
            object dataend = JsonFactory.getResult(200, true, "查询成功", total, mydata);
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult del(int id)//根据id删除数据
        {
          
             var  mydata = noteBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend;
            if (noteBll.Delete(mydata))
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
        public JsonResult add( string title, string contents, string time)//添加数据
        {
            note mynote = new note();
            mynote.author = "管理员";
            mynote.title = title;
            mynote.contents = contents;
            mynote.time = time;
            mynote.classid = admlv;
            noteBll.Add(mynote);
            object dataend = JsonFactory.getResult(200, true, "添加成功");
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult getStudentById(int id)//根据id得到数据
        {
            var mydata = noteBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend = JsonFactory.getResult(200, true, "查询成功", mydata);
            return Json(dataend);
        }
        [HttpPost]
        public JsonResult update(int id, string author, string title, string contents, string time)//更新数据
        {
            var mydata = noteBll.GetEntities(n => n.id == id).FirstOrDefault();
            mydata.author = author;
            mydata.title = title;
            mydata.time = time;
            mydata.contents = contents;
            noteBll.Update(mydata);
            object dataend = JsonFactory.getResult(200, true, "修改成功");
            return Json(dataend);
        }
    }
}
