import myaxios from "@/utils/myaxios";
const qs = require("querystring");
export default {
    search(page, size, searchWhere) {
    //得到所有班级
    return  myaxios({
        url: `/FileBackstage/search?page=${page}&size=${size}`,
        method: "post",
        data:qs.stringify(searchWhere)
    });
  },
  deleteBookById(id){
    return  myaxios({
      url: `/FileBackstage/del/${id}`,
      method: "get",
  });
  },
  add(bookform) {
    return myaxios({
      url: "/FileBackstage/add",
      method: "post",
      data: qs.stringify(bookform)
    });
  },
  getStudentById(id){
    return myaxios({
      url: `/FileBackstage/getStudentById/${id}`,
      method: "get"
    });
  },
  update(Obj) {
    return myaxios({
      url: `/FileBackstage/update/${Obj.id}`,
      method: "post",
      data: qs.stringify(Obj)
    });
  },
  resAll() {
    //重置全部文件和数据
    return myaxios({
      url: `/FileBackstage/DeleteAll`,
      method: "get"
    });
  },
  upDown() {
    //下载全部文件
    return myaxios({
      url: `/FileBackstage/CreateZip`,
      method: "get"
    });
  },
};
