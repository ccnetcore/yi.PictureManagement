import Vue from 'vue'
import App from './App'
import router from './router'

import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'
import 'bootstrap/dist/js/bootstrap.min.js'
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import './permission'
Vue.config.productionTip = false
Vue.use(ElementUI);

/* eslint-disable no-new */
new Vue({
    router,
    render: h => h(App)
}).$mount("#app");