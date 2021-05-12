using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CC.Jift.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClassController : BaseController
    {
        private IMyClassBll myClassBll;
        public ClassController(IMyClassBll _myClassBll)
        {
            IsCheck = 0;
            myClassBll = _myClassBll;
        }
        [HttpGet]
        public JsonResult Index()//返回所有班级
        {
            var myClasses = myClassBll.GetEntities(n => n.id > 0).ToList();
            return Json( myClasses);
        }
    }
}
