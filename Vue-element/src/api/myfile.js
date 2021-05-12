import myaxios from "@/utils/myaxios";
const token = localStorage.getItem("token");
const classid = localStorage.getItem("class");
export default {
  sendData(data) {
    //得到所有班级
    const qs = require("querystring");
    return myaxios({
      url: `/file/index`,
      method: "post",
      headers: { "content-type": "multipart/form-data" },
      data: qs.stringify(data)
    });
  },
  getFileList() {    //获取全部文件数据
    return myaxios({
      url: `/file/getFile`,
      method: "get"
    });
  },
  resStudentFile(id) {
    //重置单个学生数据File
    return myaxios({
      url: `/FileAdm/ResetFile/${id}`,
      method: "get"
    });
  },
  setVipFile(id) {
    //设置学生vipFile
    return myaxios({
      url: `/FileAdm/FileVip/${id}`,
      method: "get"
    });
  }
};
