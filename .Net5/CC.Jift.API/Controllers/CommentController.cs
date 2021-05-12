using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.Common;
using CC.Jift.IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CommentController : BaseController
    {
        private ICommentBll commentBll;
        public CommentController(ICommentBll _commentBll)
        {
            IsCheck = 1;
            commentBll = _commentBll;
        }
        [HttpGet]
        public JsonResult GetList(int noteid)
        {
            var comments = commentBll.GetEntities(n => n.noteid == noteid).ToList();
            return Json(JsonFactory.getResult(200, true, "查询成功", comments));
        }
    }
}
