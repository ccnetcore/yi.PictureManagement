import myaxios from "@/utils/myaxios";
const token = localStorage.getItem("token");
export default {
  resAll() {
    //重置全部图片
    return myaxios({
      url: `/ImageAdm/DeleteAll`,
      method: "get"
    });
  },
  upDown() {
    //下载图片
    return myaxios({
      url: `/ImageAdm/CreateZip`,
      method: "get"
    });
  },
  sendImg(name, myimg) {
    //提交图片
    const qs = require("querystring");
    return myaxios({
      url: "/Image/Index",
      method: "post",
      headers: { "content-type": "application/x-www-form-urlencoded" },
      data: qs.stringify({ name: name, myimg: myimg})
    });
  },
  getStudentList() {
    //获取全部学生数据
    return myaxios({
      url: `/Image/index`,
      method: "get"
    });
  },
  getStudent(id) {
    //获取单个学生数据
    return myaxios({
      url: `/Image/show/${id}`,
      method: "get"
    });
  },
  getStudentNum() {
    //获取提交学生数据
    return myaxios({
      url: `/Image/SubTotal`,
      method: "get"
    });
  },
  getStudentNotNum() {
    //获取未提交学生数据
    return myaxios({
      url: `/Image/NotSubTotal`,
      method: "get"
    });
  },
  resAllStudent() {
    //重置所有学生数据
    return myaxios({
      url: `/ImageAdm/ResetAll`,
      method: "get"
    });
  },
  resStudent(id) {
    //重置单个学生数据
    return myaxios({
      url: `/ImageAdm/Reset/${id}`,
      method: "get"
    });
  },
  sendMail() {
    //发送邮件
    return myaxios({
      url: `/ImageAdm/Mail`,
      method: "get"
    });
  },
  setVip(id) {
    //设置学生vip
    return myaxios({
      url: `/ImageAdm/Vip/${id}`,
      method: "get"
    });
  }
};
