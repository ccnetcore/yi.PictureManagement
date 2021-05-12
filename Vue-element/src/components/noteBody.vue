<template>
  <div>
    <div v-for="(item, i) in noteList" :key="i">
      <h4>
        <strong>{{ item.title }}</strong>
        <h6 style="color: #606266">
          发布时间：<em>{{ item.time }}</em>
        </h6>
      </h4>
      <p>{{ item.contents }}</p>
      <router-link :to="{ name: 'Note', params: { noteid: item.id } }"
        ><p><el-button type="primary" plain>了解详情</el-button></p>
      </router-link>
      <hr />
    </div>

    <el-collapse v-model="activeNames" @change="handleChange">
      <el-collapse-item title="更新公告" name="1">
        <div>1.0v后端.Net MVC</div>
        <div>2.0v命名青年大学习截图上传系统</div>
        <div>3.0v升级！.NET MVC后端</div>
        <div>4.0v后端重做架构</div>
        <div>5.0v移动端兼容</div>
        <div>6.0v.NET CORE MVC异步多线程三层架构</div>
        <div>7.0v前端全部更新，搭建VUE-CLI项目,正式改名为：图片管理系统</div>
        <div>8.0vVue+.NetCore+WebAPI前后端完全分离</div>
        <div>9.0vtoken令牌加密</div>
        <div>10.0v权限系统，多平台发布</div>
        <div>11.0v后台管理系统发布，余小七入驻本站！</div>
        <div>12.0v文件管理系统扩展发布</div>
        <div>13.0v公告管理系统扩展发布</div>
        <div>14.0v大幅度优化前端与后端</div>
        <div>15.0v修复巨额的bug！更好的体验</div>
        <div>16.0v后端管理加入移动端</div>
        <div>17.0v后端全部重组采用三层架构.Net 5 WebAPI项目</div>
        <div>18.0v前端重组，极致优化</div>
      </el-collapse-item>
      <el-collapse-item title="关于我们" name="2">
        <div>软件传说招募2020届新人</div>
        <div>QQ群：1104405703</div>
        <div>期望成为下一个软件传说</div>
      </el-collapse-item>
    </el-collapse>
  </div>
</template>
<script>
import note from "@/api/note";
import home from "@/api/home";
export default {
  data() {
    return {
      activeNames: ["0"],
      noteList: [],
    };
  },
  created() {
    this.fetchData();
  },
  name: "noteBody",
  methods: {
    fetchData() {
      const myuname = localStorage.getItem("token");
      const classid = localStorage.getItem("class");

      const p = note.getList();
      p.then((resp) => {
        const myresp = JSON.parse(resp.data);
        if (myresp.flag) {
          this.noteList = myresp.data;
          console.log(this.noteList);
        }
      });
    },
    handleChange(val) {
      console.log(val);
    },
  },
};
</script>

