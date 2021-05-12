<template>
  <div>
    <div id="show2"><i style="color:white;font-size:35px" @click="mob" class="el-icon-s-unfold btnm"></i></div>
    <app-header></app-header>
    <app-main></app-main>
    <app-navbar id="show1" ></app-navbar>
  </div>
</template>

<script>
import AppHeader from "../components/adminBody/AppHeader";
import AppMain from "../components/adminBody/AppMain";
import AppNavbar from "../components/adminBody/AppNavbar";

export default {
  components: {
    AppHeader,
    AppMain,
    AppNavbar,
  },
  methods: {
    mob() {
      var otherDiv = document.getElementById("show1");
      if (otherDiv.style.display == "block") {
        otherDiv.style.display = "";
      } else {
        otherDiv.style.display = "block";
      }
    },
  },
};
</script>

<style scoped>
.btnm
{
  background: #191A23;
}
.btnm:hover{
  cursor: pointer;
}
@media screen and (max-width: 900px) {
  .main {
    left: 0px;
  }
  #show1 {
    display: none;
  }
  #show2 {
    display: block;
    margin-top: 5px;

  }
}
@media screen and (min-width: 900px) {
  .main {
    left: 250px;
  }
  #show1 {
    display: block;
  }
  #show2 {
    display: none;
  }
}
.header {
  position: absolute;
  height: 65px;
  top: 0px;
  left: 0px;
  right: 0px;
  background-color: #191a23;
  box-shadow: 10px 10px 5px #888888;
}
.navbar {
  position: absolute;
  width: 250px;
  left: 0px;
  top: 50px;
  bottom: 0px;
  background-color: #191a23;
  padding: 0px;
  overflow-y: auto;
  box-shadow: 10px;
}
.main {
  position: absolute;


  top: 50px;
  right: 0px;
  bottom: 0px;

  overflow-y: auto;
}
#show2 {
  position: absolute;
  left: 0;
  top: 0;

  z-index: 100;
}
#show1{
  z-index: 99;
}

</style>