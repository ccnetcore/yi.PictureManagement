import myaxios from "@/utils/myaxios";
export default {
  getList(noteid) {    //获取全部公告数据
    return myaxios({
      url: `/comment/getlist?noteid=${noteid}`,
      method: "get"
    });
  }
};
