import myaxios from "@/utils/myaxios";
const qs = require("querystring");
export default {
  getList() {    //获取全部公告数据
    return myaxios({
      url: `/note/getlist`,
      method: "get"
    });
  },
  getById(id) {    //通过id获取
    return myaxios({
      url: `/note/getById?id=${id}`,
      method: "get"
    });
  },
  search(page, size, searchWhere) {
    //得到所有班级

    return myaxios({
      url: `/NoteBackstage/search?page=${page}&size=${size}`,
      method: "post",
      data: qs.stringify(searchWhere)
    });
  },
  deleteBookById(id) {
    return myaxios({
      url: `/NoteBackstage/del/${id}`,
      method: "get",
    });
  },
  add(bookform) {
    return myaxios({
      url: "/NoteBackstage/add",
      method: "post",
      data: qs.stringify(bookform)
    });
  },
  getStudentById(id) {
    return myaxios({
      url: `/NoteBackstage/getStudentById/${id}`,
      method: "get"
    });
  },
  update(Obj) {
    return myaxios({
      url: `/NoteBackstage/update/${Obj.id}`,
      method: "post",
      data: qs.stringify(Obj)
    });
  }
};
