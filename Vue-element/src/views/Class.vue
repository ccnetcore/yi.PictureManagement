<template>
  <div id="mybody" class="shadow-sm">
    <div class="myCenter">
      <div class="text-center p-4">
        
        <h4>
          <img class="logo" src="@/assets/logo.png" />
          <h1><strong>数据管理</strong></h1>
          <hr />
        </h4>
      </div>
      <div class="row">
        <ul class="myCenter">
          <li
            class="myli"
            v-for="(item, i) in classdata"
            :key="i"
            @click="getinto(item.id)"
          >
            <el-card :body-style="{ padding: '0px' }" style="background-color:rgba(70,98,217,0.1);border-color:#35495e">
              <img
                src="@/assets/logo.png"
                class="image"
                height="80"
        
              />
              <div style="padding: 14px;color: #35495e">
                <span >{{ item.name }}</span>
                <div class="bottom clearfix">
                  <el-button type="text" class="button">进入</el-button>
                </div>
              </div>
            </el-card>
          </li>
        </ul>
      
      </div>
       
    </div>
     <hr style="clear: both">
  </div>
</template>
<style>
#mybody {
  background-image: url("https://pic.downk.cc/item/5fef65053ffa7d37b302175a.png");
  height: 780px;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  background-attachment: fixed;
  background-color: rgba(0, 0, 0, 0.000000000001);

}
.myli {
  float: left;
  list-style-type: none;
  margin: 10px;
  width: 150px;
}
.myCenter {
  margin-top: 0;
  margin-right: auto;
  margin-bottom: 0;
  margin-left: auto;
}
.el-carousel__item h3 {
  color: #475669;
  font-size: 14px;
  opacity: 0.75;
  line-height: 150px;
  margin: 0;
}

.bottom {
  margin-top: 13px;
  line-height: 12px;
}

.button {
  padding: 0;
  float: right;
}

.image {
  width: 100%;
  display: block;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}

.clearfix:after {
  clear: both;
}
</style>
<script>
import myclass from "@/api/myclass";
export default {
  data() {
    return {
      classdata: [],
    };
  },
  created() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      const p = myclass.getAllClass();
      p.then((resp) => {
        const myresp = resp.data;
        this.classdata = myresp;
      });
    },
    getinto(id) {
      localStorage.setItem("class", id);
      this.$router.push({ name: "ls" });
    },
  },
};
</script>
