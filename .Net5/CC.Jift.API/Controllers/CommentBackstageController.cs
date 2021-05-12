using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.Common;
using CC.Jift.IBLL;
using CC.Jift.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;


namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommentBackstageController : BaseController
    {
        private ICommentBll commentBll;
        public CommentBackstageController(ICommentBll _commentBll)
        {
            IsCheck = 2;
            commentBll = _commentBll;
        }
        [HttpPost]
        public JsonResult search(int page, int size, int noteid, string time,string contents)//根据条件返回数据
        {

            var mydata = commentBll.GetPageEntities<int>(size, page, out int total,

               u => (noteid == 0 ? true : u.noteid==noteid) && (contents == null ? true : u.contents.Contains(contents)) 
                , o => o.id, true).ToArray();
            object dataend = JsonFactory.getResult(200, true, "查询成功", total, mydata);
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult del(int id)//根据id删除数据
        {
            comment mycomment = new comment();
            mycomment = commentBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend;
            if (commentBll.Delete(mycomment))
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
        public JsonResult add(int noteid, string time, string contents)//添加数据
        {
            comment mycomment = new comment();
            mycomment.noteid = noteid;
            mycomment.time = time;
            mycomment.contents = contents;
            commentBll.Add(mycomment);
            object dataend = JsonFactory.getResult(200, true, "添加成功");
            return Json(dataend);
        }
        [HttpGet]
        public JsonResult getStudentById(int id)//根据id得到数据
        {
            var mydata = commentBll.GetEntities(n => n.id == id).FirstOrDefault();
            object dataend = JsonFactory.getResult(200, true, "查询成功", mydata);
            return Json(dataend);
        }
        [HttpPost]
        public JsonResult update(int id, string time, string contents)//更新数据
        {
            var mydata = commentBll.GetEntities(n => n.id == id).FirstOrDefault();
            mydata.contents = contents;
            mydata.time = time;
            commentBll.Update(mydata);
            object dataend = JsonFactory.getResult(200, true, "修改成功");
            return Json(dataend);
        }
    }
}
