import Vue from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import VueApexCharts from 'vue-apexcharts'
import Vuelidate from 'vuelidate'

Vue.config.productionTip = false
Vue.use(VueApexCharts)
Vue.use(Vuelidate)
Vue.component('apexchart', VueApexCharts)

new Vue({
  router,
  vuetify,
  Vuelidate,
  render: h => h(App)
}).$mount('#app')
