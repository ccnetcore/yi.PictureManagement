<template>
  <div class="navbar">
    <el-menu
      :router="true"
      default-active="/home"
      class="el-menu-vertical-demo"
      @open="handleOpen"
      @close="handleClose"
      background-color="#191A23"
      text-color="#BABBBD"
      active-text-color="#FFFFFF"
    >
      <el-menu-item index="/adminfo">
        <i class="el-icon-menu"></i>
        <span slot="title">首页</span>
      </el-menu-item>

      <el-submenu index="2">
        <template slot="title">
          <i class="el-icon-s-release"></i>
          <span>学生信息管理</span>
        </template>
        <el-menu-item-group>
          <template slot="title">我的学生</template>
          <el-menu-item index="/studentinfo">基本信息</el-menu-item>
          <el-menu-item index="/studentinfo">附加信息</el-menu-item>
        </el-menu-item-group>
      </el-submenu>

      <el-submenu index="3">
        <template slot="title">
          <i class="el-icon-s-release"></i>
          <span>文件信息管理</span>
        </template>
        <el-menu-item-group>
          <template slot="title">我的文件</template>
          <el-menu-item index="/fileinfo">基本信息</el-menu-item>
          <el-menu-item index="/fileinfo">附加信息</el-menu-item>
        </el-menu-item-group>
      </el-submenu>
      <el-submenu index="4">
        <template slot="title">
          <i class="el-icon-s-home"></i>
          <span>公告信息管理</span>
        </template>
        <el-menu-item-group>
          <template slot="title">我的公告</template>
          <el-menu-item index="/noteinfo">公告信息</el-menu-item>
        </el-menu-item-group>
        <el-menu-item-group>
          <template slot="title">我的评论</template>
          <el-menu-item index="/studentinfo">评论信息</el-menu-item>
        </el-menu-item-group>
      </el-submenu>
      <el-submenu index="5">
        <template slot="title">
          <i class="el-icon-s-home"></i>
          <span>班级信息管理</span>
        </template>
        <el-menu-item-group>
          <template slot="title">我的班级</template>
          <el-menu-item index="/studentinfo">班级信息</el-menu-item>
          <el-menu-item index="/studentinfo">附加信息</el-menu-item>
          <el-menu-item index="/studentinfo">积分排行</el-menu-item>
        </el-menu-item-group>
      </el-submenu>

      <el-menu-item index="/studentinfo">
        <i class="el-icon-document"></i>
        <span slot="title">用户管理</span>
      </el-menu-item>
      <el-menu-item index="/studentinfo">
        <i class="el-icon-setting"></i>
        <span slot="title">其他</span>
      </el-menu-item>
    </el-menu>
  </div>
</template>
 <script>
export default {
  methods: {
    handleOpen(key, keyPath) {
      console.log(key, keyPath);
    },
    handleClose(key, keyPath) {
      console.log(key, keyPath);
    }
  }
};
</script>
<style scoped>
.el-menu {
  border-right: none;
  height: 100%;
  width: 100%;
}
</style>
