<template>
  <div class="container-xl my-xl-3 con p-0">
    <div class="row justify-content-center">
      <div class="col-lg-9 col-12 my-xl-2">
        <div class="p-0 col-12 shadow-sm text-left bg-white">
          <el-tabs v-model="activeName" type="border-card" @tab-click="handleClick">
            <el-tab-pane label="公告" name="first"></el-tab-pane>
            <el-tab-pane label="图片" name="second"></el-tab-pane>
            <el-tab-pane label="文件" name="third"></el-tab-pane>
            <el-tab-pane label="网盘" name="fourth"></el-tab-pane>
            <router-view />
          </el-tabs>
          <div>
          </div>
        </div>
      </div>

      <div class="col-lg-3 col-12 my-xl-2 row">
        <div>
          <div class="pt-3 col-12 shadow-sm text-center bg-white">
            <div class="row">
              <div class="col-xl-3 col-lg-6 col-3">
                <img
                  src="https://pic.downk.cc/item/5fef654e3ffa7d37b30229c9.png"
                  class="figure-img img-fluid rounded"
                  alt="..."
                />
                <a @click="Updown" v-show="adm"
                  ><figcaption class="figure-caption">下载数据</figcaption></a
                >
              </div>
              <div class="col-xl-3 col-lg-6 col-3">
                <img
                  src="https://pic.downk.cc/item/5fef65553ffa7d37b3022cb4.png"
                  class="figure-img img-fluid rounded"
                  alt="..."
                />
                <a @click="resda" v-show="adm"
                  ><figcaption class="figure-caption">重置提交</figcaption></a
                >
              </div>
              <div class="col-xl-3 col-lg-6 col-3">
                <img
                  src="https://pic.downk.cc/item/5fef655e3ffa7d37b3022eff.png"
                  class="figure-img img-fluid rounded"
                  alt="..."
                />
                <a @click="res" v-show="adm">
                  <figcaption class="figure-caption">重置文件</figcaption></a
                >
              </div>
              <figure class="col-xl-3 col-lg-6 col-3">
                <img
                  src="https://pic.downk.cc/item/5fef65683ffa7d37b30231dc.png"
                  class="figure-img img-fluid rounded"
                  alt="..."
                />
                <a @click="mymail" v-show="adm"
                  ><figcaption class="figure-caption">邮件提醒</figcaption></a
                >
              </figure>
            </div>

            <div class="row">
              <div class="col-6 border-top p-2">管理员</div>
              <div class="col-6 border-top border-left p-2">究极权限</div>
            </div>
          </div>

          <div class="pt-3 my-2 col-12 shadow-sm text-center bg-white">
            <div class="row border-bottom">
              <div class="col-12">
                <p>
                  <img
                    style="height: 24px"
                    src="https://pic.downk.cc/item/5fef658a3ffa7d37b3023a18.png"
                    class="img-fluid"
                  />数据中心
                </p>
              </div>
            </div>
            <div class="row my-2" style="color: darkgray">
              <div class="col-6 border-right p-2">
                <a>大版本更新次数</a><br />
                <a class="text-primary"
                  ><strong>{{ SubTotal }}</strong></a
                ><br />
                <a
                  ><small
                    >优化提高<span class="text-primary">321%</span></small
                  ></a
                >
              </div>
              <div class="col-6 p-2">
                <a>小版本更新次数</a><br />
                <a class="text-primary"
                  ><strong>{{ NotSubTotal }}</strong></a
                ><br />
                <a
                  ><small
                    >较前日上升<span class="text-primary">123%</span></small
                  ></a
                >
              </div>
            </div>
            <div class="row border-top pt-2">
              <div class="col-12">
                <p>腾讯云安全保护中</p>
              </div>
            </div>
          </div>

          <div class="my-2 col-12 shadow-sm">
            <div class="row">
              <div
                id="carouselExampleSlidesOnly"
                class="carousel slide"
                data-ride="carousel"
              >
                <div class="carousel-inner">
                  <div class="carousel-item active">
                    <img
                      src="https://pic.downk.cc/item/5fef659a3ffa7d37b3023dbe.jpg"
                      class="d-block w-100"
                      alt="..."
                    />
                  </div>
                  <div class="carousel-item">
                    <img
                      src="https://pic.downk.cc/item/5fef65a63ffa7d37b3024142.jpg"
                      class="d-block w-100"
                      alt="..."
                    />
                  </div>
                  <div class="carousel-item">
                    <img
                      src="https://pic.downk.cc/item/5fef65b03ffa7d37b3024465.jpg"
                      class="d-block w-100"
                      alt="..."
                    />
                  </div>
                </div>
              </div>
            </div>
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
      adm: false,
      SubTotal: 18,
      NotSubTotal: 999,
      activeName: "first",
      base_api: "",
    };
  },
  beforeCreated() {},
  created() {
    this.fetchData();
    this.fetchDataed();
  },
  mounted() {
    this.base_api = process.env.VUE_APP_BASE_API;
  },
  methods: {
    handleClick() {
      switch (this.activeName) {
        case "first":
          this.$router.push("/noteBody")
          break;
        case "second":
           this.$router.push("/imageBody")
          break;
        case "third":
           this.$router.push("/fileBody")
          break;
        case "fourth":
           this.$router.push("/wpBody")
          break;
      }
    },
    outMy() {
      alert("登录超时!或权限不足！请重新登录！");
      localStorage.clear();
      this.$router.go(0);
    },
    fetchDataed() {
      const myuname = localStorage.getItem("token");
      const classid = localStorage.getItem("class");

      if (myuname != null) {
        this.adm = true;
      }
    },
    fetchData() {},
    Updown() {
      this.$confirm("此操作将下载学生已提交文件, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          const p = image.upDown();
          p.then((resp) => {
            if (resp.data == "ok") {
              alert("文件压缩成功，开始下载！");
              const classid = localStorage.getItem("class");
              window.open(this.base_api + "/studentimage" + classid + ".zip");
            } else {
              this.outMy();
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消下载文件",
          });
        });
    },
    res() {
      this.$confirm("此操作将永久重置学生已提交文件, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          const p = image.resAll();
          p.then((resp) => {
            if (resp.data == "ok") {
              this.$message({
                type: "success",
                message: "文件全部重置成功!",
              });
            } else {
              this.outMy();
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消重置文件",
          });
        });
    },
    resda() {
      this.$confirm("此操作将永久重置学生提交数据, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          const p = image.resAllStudent();
          p.then((resp) => {
            if (resp.data == "ok") {
              this.$router.go(0);
              this.$message({
                type: "success",
                message: "学生数据已重置!",
              });
            } else {
              this.outMy();
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消重置学生数据",
          });
        });
    },
    mymail() {
      this.$confirm("此操作将发送邮件, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning",
      })
        .then(() => {
          const p = image.sendMail();
          p.then((resp) => {
            if (resp.data == "ok") {
              this.$message({
                type: "info",
                message: "邮件已全部发送！",
              });
            } else {
              this.outMy();
            }
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消重置文件",
          });
        });
    },
  }
};
</script>
