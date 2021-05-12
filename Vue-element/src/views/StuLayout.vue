<template>
  <body
    class="pt-5"
    style="
        background-color: #F6F6F6;overflow-x:hidden
"
  >
    <div>
      <el-menu
        :default-active="activeIndex"
        class="el-menu-demo shadow-sm"
        mode="horizontal"
        style=" position: fixed;top: 0;width:100%;z-index:10"
      >
        <el-menu-item index="1">
          <a class="navbar-brand" href=""
            ><img src="/favicon.ico" width="25" height="25" /> </a
        ></el-menu-item>

        <el-submenu index="2"  v-if="loginShow">
          <template slot="title" >登入</template>
          <el-menu-item index="2-1"  @click="drawer = true"
            >班级管理员登录</el-menu-item
          >
          <el-menu-item index="2-2">校级管理员登录</el-menu-item>
          <el-submenu index="2-3">
            <template slot="title">学生登录</template>
            <el-menu-item index="2-4-1">游客</el-menu-item>
            <el-menu-item index="2-4-2">普通</el-menu-item>
            <el-menu-item index="2-4-3">VIP</el-menu-item>
          </el-submenu>
        </el-submenu>
        <el-menu-item v-if="!loginShow" v-on:click="outLogin()" index="3"
          >注销登录</el-menu-item
        >
        <el-menu-item v-on:click="outClass()" index="4">班级</el-menu-item>
        <el-menu-item index="5" v-on:click="back()">后台管理</el-menu-item>
      </el-menu>
      <el-drawer
        :visible.sync="drawer"
        :direction="direction"
        :before-close="handleClose"
        size="40%"
      >
        <div class="text-center">
          <h4>登入</h4>
          <el-input
            style="width: 80%"
            placeholder="学号"
            v-model="uname"
            class="m-2"
          ></el-input>
          <el-input
            style="width: 80%"
            placeholder="密码"
            v-model="pwd"
            class="m-2"
            show-password
          ></el-input>

          <el-divider></el-divider>
          <el-button
            v-on:click="login()"
            type="primary"
            round
            style="width: 80%"
            >确定登入</el-button
          >
        </div>
      </el-drawer>

      <router-view />

      <footer class="col text-center" style="color:darkgray">
        <hr />
        <a> 大数据学院 &nbsp;</a>
        <a>&copy; 2020 - WC &nbsp;</a>
        <a style="color:darkgray" href="https://beian.miit.gov.cn"
          >赣ICP备20008025号</a
        >
        <br />
        <a
          style="color:darkgray"
          href="http://www.beian.gov.cn/portal/registerSystemInfo?recordcode=36012102000235"
          ><img src="/images/备案图标.png" />赣公网安备 36012102000235号
        </a>
        <br />
        <a>友情链接：</a
        ><a style="color:darkgray" href="https://yicraftcore.com/">CC</a>/
        <a>友情链接：</a
        ><a style="color:darkgray" href="https://funto.top/">funto</a>
      </footer>
    </div>
  </body>
</template>

<script>
import home from "@/api/home";
export default {
  data() {
    return {
      loginShow: true,
      uname: "",
      pwd: "",
      activeIndex: "1",
      drawer: false,
      direction: "rtl"
    };
  },
  created() {
    this.getmydunme();
  },
  methods: {
    back(){
      this.$router.push({ name: "adm" });
    }
    ,
    outClass() {
      this.$router.push({ name: "Class" });
    },
    handleClose(done) {
      this.$confirm("确定退出登录？")
        .then(_ => {
          done();
        })
        .catch(_ => {});
    },
    getmydunme() {
      const myuname = localStorage.getItem("token");
      if (myuname != "" && myuname!=null) {
        this.loginShow = false;
      }
    },
    login() {
      const p = home.login(this.uname, this.pwd);
      p.then(resp => {
        // resp.data=resp.data.replace(/\\/g,"");
        // console.log(resp.data)
        const myresp = JSON.parse(resp.data);
        if (myresp.msg == "ok") {
          localStorage.setItem("token", myresp.token);
          this.$router.go(0);
          // this.$router.push({name:'/home'});

          this.$message({
            type: "success",
            message: "欢迎您，管理员！"
          });
        } else {
          alert("登入失败，请检查你的帐号或者密码！");
        }
        p.catch(err => console.log(err));
      });
    },
    outLogin() {
      const p = home.outLogin();
      p.then(resp => {
        const myresp = resp.data;
        if (myresp == "ok") {
          localStorage.clear();
          this.$router.go(0);
          this.$message({
            type: "success",
            message: "成功退出"
          });
        } else {
          alert("退出失败");
        }
      });
    }
  }
};
</script>
