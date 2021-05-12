<template></template>
<script>
import home from "@/api/home";
export default {
  created() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      const classid = localStorage.getItem("class");
      const mc = home.getMyClassid(classid);
      mc.then((resp) => {
        if (resp.data != "ok") {
          alert("错误！");
        }
      this.$router.push({ name: "Home" });
      });
    },
  },
};
</script>