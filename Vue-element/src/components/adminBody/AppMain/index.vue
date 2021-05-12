<template>
  <div class="main">
   
    <el-breadcrumb
      v-show="$route.path != '/adminfo'"
      separator-class="el-icon-arrow-right"
    >
      <span class="line">|</span>
      <el-breadcrumb-item :to="{ path: '/adminfo' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item
        v-show="$route.path == '/studentinfo' || $route.path == '/morestudentinfo'"
        >学生信息管理</el-breadcrumb-item
      >
      <el-breadcrumb-item
        v-show="
          $route.path == '/classinfo' ||
            $route.path == '/moreclassinfo' ||
            $route.path == '/classnum'
        "
        >班级信息管理</el-breadcrumb-item
      >
      <el-breadcrumb-item :to="{ path: $route.path }">{{
        $route.meta.title
      }}</el-breadcrumb-item>
    </el-breadcrumb>
    <router-view></router-view>
  </div>
</template>
<style scoped>
.el-breadcrumb {
  height: 20px;
  padding: 20px;
  border-radius: 5px;
  box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
  margin-bottom: 10px;
  margin-top: 10px;
  text-align: center;
}
.line {
  position: absolute;
  color: white;
  border-left: 3px solid red;
  left: 10px;
}
</style>
