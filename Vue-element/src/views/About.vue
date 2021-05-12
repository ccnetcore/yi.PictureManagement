<template>
  <div class="about">
    <div class="container-xl">
      <div class="row mt-3 ">
        <div class="text-center m-auto shadow-sm bg-white">
          <router-link :to="{ name: 'Home' }" class="btn btn-primary my-2 "
            >返回首页</router-link
          >
          <h2>这里是 {{ mydata.name }} 的空间</h2>
          <p>学号：{{ mydata.sid }}</p>
          <p>提交时间： {{ mydata.time }}</p>

          <p>
            <img
              class="img-fluid"
              :src="
               base_api+'/StudentImage' +
                  myclassid +
                  '/' +
                  mydata.name +
                  '.jpg'
              "
              alt="加载中"
              style="width:50%;height:50%"
            />
          </p>
          <div class="my-2">
            <a v-show="adm" @click="resimg" class="btn btn-warning del"
              >重置他的截图</a
            >
            <a v-show="adm" @click="vip" class="btn btn-primary vip"
              >给他设置会员</a
            >
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import home from "@/api/home";
import image from "@/api/image";
export default {
  data() {
    return {
      mydata: [],
      adm: false,
      myclassid: 0,
      base_api:""
    };
  },
  created() {
    this.fetchData();
  },
  mounted() {
    this.base_api=process.env.VUE_APP_BASE_API;
  },
  methods: {
    resimg() {
      this.$confirm("此操作将永久重置改学生提交数据, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          const p = image.resStudent(this.$route.params.id);
          p.then(resp => {
            if (resp.data == "ok") {
              this.$router.push({ name: "Home" });
              this.$message({
                type: "success",
                message: "提交数据已重置"
              });
            } else {
              this.$message({
                type: "warning",
                message: "权限不足"
              });
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消重置改学生数据"
          });
        });
    },
    vip() {
      this.$confirm("此操作将改学生设置为会员, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          const p = image.setVip(this.$route.params.id);
          p.then(resp => {
            alert(resp.data)
            if (resp.data == "ok") {
              this.$router.push({ name: "Home" });
              this.$message({
                type: "success",
                message: "设置会员成功"
              });
            } else {
              this.$message({
                type: "warning",
                message: "权限不足"
              });
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消重置该学生数据"
          });
        });
    },
    fetchData() {
      this.myclassid = localStorage.getItem("class");
      const myuname = localStorage.getItem("token");
      if (myuname != null) {
        this.adm = true;
      }
      const p = image.getStudent(this.$route.params.id);
      p.then(resp => {
        this.mydata =JSON.parse(resp.data) ;
      });
      p.catch(err => {
        console.log(err);
      });
    }
  }
};
</script>
