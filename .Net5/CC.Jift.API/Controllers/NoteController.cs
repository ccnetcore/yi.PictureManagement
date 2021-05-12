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
    public class NoteController : BaseController
    {
        private INoteBll noteBll;
        public NoteController(INoteBll _noteBll)
        {
            IsCheck = 1;
            noteBll = _noteBll;
        }
        [HttpGet]
        public async Task<JsonResult>   GetList()
        {
            var notes =await noteBll.GetEntities(n => n.classid == classid).ToListAsync();
            return Json(JsonFactory.getResult(200, true, "查询成功", notes));
        }
        [HttpGet]
        public async Task<JsonResult> GetById(int Id)
        {
            var notes = await noteBll.GetEntities(n => n.id==Id).FirstOrDefaultAsync();
            return Json(JsonFactory.getResult(200, true, "查询成功", notes));
        }
    }
}
