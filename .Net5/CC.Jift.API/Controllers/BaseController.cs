using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Jift.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace CC.Jift.API.Controllers
{
    public class BaseController : Controller
    {
        public int IsCheck = 1;//设置是否需要校验用户是否登录属性
        public int admlv;//管理员lv
        public int classid;//前端班级classid
      
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            switch (IsCheck)
            {
                case 1://普通用户：只需要返回前端选择的班级classid即可
                    //string myclassid = HttpContext.Session.GetString("classid");
                   
                     HttpContext.Request.Cookies.TryGetValue("classid",out string myclassid);
                    if (myclassid == null)//表示用户没有选择班级
                    {        
                        filterContext.Result = Json(JsonFactory.getResult(200, false, "请选择班级！"));
                    }
                    else
                    {
                        classid = Convert.ToInt32(myclassid);
                        return;
                    }
                    break;
                case 2://管理员后台登入：需要返回管理员的等级admlv即可
                    string myadmlv = HttpContext.Session.GetString("admlv");
                    if (myadmlv == null)//表示用户没有登入
                    {
                        filterContext.Result = Json(JsonFactory.getResult(200, false, "请以管理员身份进行登入！"));
                    }
                    else
                    {
                        admlv = Convert.ToInt32(myadmlv);
                        return;
                    }

                    break;
                case 3://管理员登入班级界面：需要返回管理员的等级admlv，但admlv要与classid作比较！
                    string myadmlv1 = HttpContext.Session.GetString("admlv");
                    HttpContext.Request.Cookies.TryGetValue("classid", out string myclassid1);
                    if (myadmlv1 == null || myclassid1==null)//表示用户没有登入或者没有选择班级
                    {
                        filterContext.Result = Json(JsonFactory.getResult(200, false, "请以管理员身份进行登入并选择班级！"));
                    }
                    else
                    {
                        admlv = Convert.ToInt32(myadmlv1);
                        if (admlv == 0)
                        {
                            admlv = Convert.ToInt32(myclassid1);
                        }
                        if (admlv != Convert.ToInt32(myclassid1))
                        {
                            filterContext.Result = Json(JsonFactory.getResult(200, false, "你尚未拥有该班级权限！"));
                        }
                        return;
                    }
                    break;
                case 0:
                    return;
 
            }


        }
    }
}
