import myaxios from "@/utils/myaxios";
const token = localStorage.getItem("token");
export default {
  myUser(uname, classid) {
    //查询该学生是否在本班存在
    return myaxios({
      url: `/home/MyUser?uname=${uname}&classid=${classid}`,
      method: "get"
    });
  },
  login(name, pwd) {
    //登入
    const qs = require("querystring");
    return myaxios({
      url: "/home/login",
      method: "post",
      data: qs.stringify({ uname: name, pwd: pwd })
    });
  },
  outLogin() {
    //注销登录
    return myaxios({
      url: "/Home/OutLogin",
      method: "get"
    });
  },
  getMyClassid(myClassid) {
    //给后端打开班级的id
    return myaxios({
      url: `/Home/getMyClassid?myClassid=${myClassid}`,
      method: "get"
    });
  },
  judgeLogin()
  {
    return myaxios({
      url: `/Home/judgeLogin`,
      method: "get"
    });
  }
};
