<template>
  <div>
    <h4>
      <p id="tit"><em>JIFT</em><strong>-开始</strong></p>
      <p><strong>三步提交</strong></p>
    </h4>
    <el-steps :active="active" align-center finish-status="success">
      <el-step title="输入姓名"></el-step>
      <el-step title="选择图片"></el-step>
      <el-step title="确定提交"></el-step>
    </el-steps>
    <form class="text-center">
      <div v-show="m1" class="m-4">
        <el-input
          style="width: 60%"
          v-model="usernames"
          placeholder="请输入姓名"
          id="name"
        ></el-input>
      </div>

      <div v-show="m2" class="m-4">
        <p>
          <label class="btn btn-primary" for="uploadFile" id="ulf"
            >选择图片</label
          >
        </p>
        <input
          style="display: none"
          type="file"
          id="uploadFile"
          class="clip"
          accept="image/*"
        />
        <div id="imgUploadX"></div>
      </div>
      <div v-show="m3" class="m-4">
        <p>
          <input
            v-show="m3"
            v-on:click="sub()"
            type="button"
            class="btn btn-success"
            value="确认提交"
          />
        </p>
      </div>

      <el-button v-show="su" @click="change" type="primary" round class="m-2">{{
        mesg
      }}</el-button>
    </form>
    <a class="text-info">详细了解</a>
    <hr />
    <div>
      <h4>
        <strong>未提交学生</strong><em><h6>管理员点击设置会员</h6></em>
      </h4>

      <a
        @click="gvip(item.id)"
        v-for="(item, i) in nodata1"
        :key="i"
        class="btn btn-outline-warning text-warning"
        >{{ item.name }}</a
      >

      <p><a class="text-info">详细了解</a></p>
      <hr />
    </div>
    <div>
      <h4>
        <strong>已提交学生</strong><em><h6>点击进入空间详情</h6></em>
      </h4>

      <router-link
        :to="{ name: 'About', params: { id: item.id } }"
        v-for="(item, i) in mydata1"
        :key="i"
        class="btn btn-outline-primary text-primary"
        >{{ item.name }}</router-link
      >
      <p><a class="text-info">详细了解</a></p>
      <hr />
    </div>
  </div>
</template>
<script>
import home from "@/api/home";
import image from "@/api/image";
import noteBody from "@/components/noteBody.vue";
import imageBody from "@/components/imageBody.vue";

import itt from "@/mycore.js";
export default {
  data() {
    return {
      mydata1: [],
      nodata1: [],
      myimgs: "",
      usernames: "",
      adm: false,
      m1: true,
      m2: false,
      m3: false,
      mesg: "下一步",
      active: 0,
      su: true,
    };
  },
  created() {
    this.fetchData();
  },
  mounted() {
    this.usemycore();
  },
  methods: {
    outMy() {
      alert("登录超时!或权限不足！请重新登录！");
      localStorage.clear();
      this.$router.go(0);
    },
    handleClick(tab, event) {
      console.log(tab, event);
    },
    usemycore() {
      var eleUploadFile = document.getElementById("uploadFile");
      var eleImgUploadX = document.getElementById("imgUploadX");
      eleUploadFile.addEventListener("change", function (event) {
        var reader = new FileReader();
        var file = event.target.files[0] || event.dataTransfer.files[0];
        reader.onload = function (e) {
          var base64 = e.target.result;

          // 使用canvas合成图片，并base64化
          itt.imgTogether(base64, function (url) {
            eleImgUploadX.innerHTML =
              '<img id="myimg" src="' +
              url +
              '" width="' +
              648 +
              '" height="' +
              1404 +
              '">';
          });
        };
        reader.readAsDataURL(file);
      });
    },
    fetchData() {
      const myuname = localStorage.getItem("token");
      const classid = localStorage.getItem("class");
     

      if (myuname != null) {
        this.adm = true;
      }
      this.mydata1 = [];
      this.nodata1 = [];
      const p = image.getStudentList();
      p.then((resp) => {
        const myresp = JSON.parse(resp.data);
        myresp.forEach((item) => {
          if (item.sub == "1") {
            this.mydata1.push(item);
          } else {
            this.nodata1.push(item);
          }
        });
      });
    },
    next() {
      if (this.active++ > 2) this.active = 0;
    },
    change() {
      if (this.m1 == true) {
        const classid = localStorage.getItem("class");
        const p = home.myUser(this.usernames, classid);
        p.then((resp) => {
          const myresp = resp.data;
          if (myresp == "ok") {
            this.m1 = false;
            this.m2 = true;
            this.next();
          } else {
            this.$message({
              type: "warning",
              message: "你确定你是本班的？",
            });
          }
        });
      } else if (this.m2 == true) {
        window.scrollTo(0, 0);
        this.mesg = "最后一步";
        this.m2 = false;
        this.m3 = true;
        this.su = false;
        this.next();
      } else if (this.m3 == true) {
        this.m3 = false;
        this.mesg = "别点了！已经没了！";
      }
    },
    sub() {
      this.m3 = false;
      this.next();
      this.myimgs = document.getElementById("myimg").src;
      const p = image.sendImg(this.usernames, this.myimgs);
      p.then((resp) => {
        if (resp.data == "no") {
          this.fetchData();
          this.$message.error("提交失败");
        } else if (resp.data == "ok1") {
          this.fetchData();
          this.$message({
            type: "success",
            message: "提交成功",
          });
        } else if (resp.data == "ok2") {
          this.fetchData();
          this.$message({
            type: "success",
            message: "提交成功！但与原图相差较大，最好先检查是否交错图片！",
          });
        } else {
          alert(resp.data);
        }
      });
    },
    gvip(id) {
      const myuname = localStorage.getItem("token");
      if (myuname == null) {
        console.log("你无权这么做！");
      } else {
        const p = image.setVip(id);
        p.then((resp) => {
          if (resp.data == "ok") {
            this.fetchData();
            alert("成功设置Vip");
          } else {
            this.outMy();
          }
        });
      }
    },
  },
  name: "mainBody",
  // props: {
  //   msg: String
  // }
};
</script>
