import myaxios from "@/utils/myaxios";
const qs = require("querystring");
export default {
    search(page, size, searchWhere) {
    //得到所有班级
    return  myaxios({
        url: `/ImageBackstage/search?page=${page}&size=${size}`,
        method: "post",
        data:qs.stringify(searchWhere)
    });
  },
  deleteBookById(id){
    return  myaxios({
      url: `/ImageBackstage/del/${id}`,
      method: "get",
  });
  },
  add(bookform) {
    return myaxios({
      url: "/ImageBackstage/add",
      method: "post",
      data: qs.stringify(bookform)
    });
  },
  getStudentById(id){
    return myaxios({
      url: `/ImageBackstage/getStudentById/${id}`,
      method: "get"
    });
  },
  update(Obj) {
    return myaxios({
      url: `/ImageBackstage/update/${Obj.id}`,
      method: "post",
      data: qs.stringify(Obj)
    });
  },
};
