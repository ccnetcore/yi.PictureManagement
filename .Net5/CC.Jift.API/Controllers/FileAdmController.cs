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
    public class FileAdmController : BaseController
    {
        private IMyFileBll myFileBll;
        public FileAdmController(IMyFileBll _myFileBll)
        {
            IsCheck = 3;
            myFileBll = _myFileBll;
        }
        [HttpGet]
        public async Task<JsonResult> FileVip(int id)//根据id设置文件vip
        {
            var filedata = await myFileBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
            filedata.time = "VIP用户";
            filedata.sub = 1;
            myFileBll.Update(filedata);
            return Json(JsonFactory.getResult(200, true, "设置成功！"));
        }
        [HttpGet]
        public async Task<JsonResult> ResetFile(int id)//重置某个学生提交file数据
        {
            var filedata = await myFileBll.GetEntities(n => n.id == id).FirstOrDefaultAsync();
            filedata.time = "";
            filedata.sub = 0;
            myFileBll.Update(filedata);
            return Json(JsonFactory.getResult(200, true, "设置成功！"));
        }
    }
}
