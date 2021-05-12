<template>
  <div class="home">

    <mainBody msg="Welcome to Your Vue.js App" />
  </div>
</template>

<script>
// @ is an alias to /src
import mainBody from "@/components/mainBody.vue";

export default {
  name: "Home",
  components: {
    mainBody
  }
};
</script>
