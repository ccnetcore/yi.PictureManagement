import myaxios from "@/utils/myaxios";
const token = localStorage.getItem("token");
export default {
  getAllClass() {
    //得到所有班级
    return myaxios({
      url: "/Class/Index",
      method: "get"
    });
  }
};
