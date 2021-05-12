import router from "./router/index.js";
import home from "@/api/home";
router.beforeEach((to, from, next) => {
  // next();
  const myclass = localStorage.getItem("class");
  const token = localStorage.getItem("token");
  if(to.path!="/ls")
  {
      home.judgeLogin().then(resp=>{
      if( resp.data=="no")
      {
        localStorage.setItem("token","")
      }
      })
    }
  if(!myclass)
  {
    if(to.path=="/class")
    next();
    else
    next({ name: 'Class' })
  }
  else
  {
    if(!token)
    {
      if (to.path=="/adminfo")
      {
        next({ name: 'Class' })
      }
      else
      {
        next()
      }
    }
    else
    {
      next();
    }

  }
  // if(!myclass)
  // {

  //   next({ name: 'Class' })
  // }
  // else
  // {
  //   alert("2")
  //     if(!token)
  //     {
  //       alert("3")
  //       if(to.path=="/home")
  //       {
  //         alert("4")
  //         next();
  //       }
  //       else
  //       {
  //         next({ name: 'Class' })
  //       }
  //     }
  // }
  // if (!myclass) {
  //   if (to.path != "/class") {
  //     next({ path: "/class" });
  //   } else {
  //     next();
  //   }
  // } else {
  //   if (to.path == "/class") {
  //     next();
  //   } else {

  //     if (token) {
  //       next();
  //     } else {
        // getUserInfo(token).then(res=>
        //     {
        //         const resp=res.data;
        //         if(resp.flag)
        //         {
        //             localStorage.setItem("cc-user",JSON.stringify(resp.data));
        // next();
        //     }
        //     else
        //     {
        //         next({path:'/login'});
        //     }
        // })
  //     }
  //   }
  // }
});
