<template>
  <div class="header">
    <div id="show2" style="float: left; width: 20px">管理系统</div>
    <div style="margin-top: 10px;float:left" >
    <a href="/" style="padding-left: 25px">
      <img  class="logo" src="@/assets/logo.png" />
      <span class="title">数据管理系统</span>
      </a>
</div>


    <el-dropdown @command="handleCommand">
      <span class="el-dropdown-link">
        <i class="el-icon-user-solid"></i>
        <!-- 用户：{{ this.user.name}} -->
        用户：管理员
        <i class="el-icon-arrow-down el-icon--right"></i>
      </span>
      <el-dropdown-menu slot="dropdown">
        <el-dropdown-item command="a">修改密码</el-dropdown-item>
        <el-dropdown-item command="b">退出系统</el-dropdown-item>
      </el-dropdown-menu>
    </el-dropdown>

    <!-- <el-dialog title="修改密码" :visible.sync="dialogFormVisible" width="400px">
      <el-form
        :model="ruleForm"
        status-icon
        :rules="rules"
        ref="ruleForm"
        label-width="100px"
        style="width:300px;margin-top:-30px;margin-bottom:-20px;"
        size="mini"
      >
        <el-form-item label="旧密码" prop="oldpass">
          <el-input
            type="password"
            v-model="ruleForm.oldpass"
            autocomplete="off"
          ></el-input>
        </el-form-item>
        <el-form-item label="新密码" prop="newpass">
          <el-input
            type="password"
            v-model="ruleForm.newpass"
            autocomplete="off"
          ></el-input>
        </el-form-item>
        <el-form-item label="确认密码" prop="checkpass">
          <el-input type="password" v-model="ruleForm.checkpass"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="submitForm('ruleForm')"
            >提交</el-button
          >
          <el-button @click="resetForm('ruleForm')">重置</el-button>
        </el-form-item>
      </el-form>
    </el-dialog> -->
  </div>
</template>
<style scoped>
@media screen and (max-width: 900px) {
  #show1 {
    display: none;
  }
  #show2 {
    display: block;
  }
}
@media screen and (min-width: 900px) {
  #show1 {
    display: block;
  }
  #show2 {
    display: none;
  }
}
.logo {
  width: 25px;
  vertical-align: middle;
  border-radius: 5px;
}

.title {
  position: absolute;
  color: #fff;
  padding-left: 5px;
  font-size: 20px;
}
.el-dropdown-link {
  cursor: pointer;
  color: #fff;
}
.el-icon-arrow-down {
  font-size: 12px;
}
.el-dropdown {
  float: right;
  margin-right: 30px;
  margin-top: 10px;
}
</style>
<script>
import home from "@/api/home";
export default {
  data() {
    return {};
  },
  methods: {
    handleCommand(command) {
      // this.$message('click on item ' + command);
      switch (command) {
        case "a":
          // this.$message("单击了修改密码 ");
          // this.updatePwd();
          break;
        case "b":
          //  this.$message('单击了退出系统 ');
          this.LogoutSystem();
          break;
      }
    },
    LogoutSystem() {
      const p = home.outLogin();
      p.then((resp) => {
        const myresp = resp.data;
        if (myresp == "ok") {
          localStorage.clear();
          this.$router.push("/class");
        }
      });
    },
  },
};
</script>
