import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

import jquery from 'jquery'

require('bootstrap')
require('jquery.easing')

// require('bootstrap/dist/css/bootstrap.css')

require('devicons/css/devicons.css')

// Font Awesome Vue
import { library } from '@fortawesome/fontawesome-svg-core'
import { faLinkedin, faGithub, faTwitter, faInstagram, faCss3, faJs, faVuejs, faHtml5, faBootstrap, faNodeJs, faLinux, faSass, faNpm } from '@fortawesome/free-brands-svg-icons'
import { faTrophy, faCheck } from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { dom } from '@fortawesome/fontawesome-svg-core'

dom.watch()

library.add(faLinkedin, faGithub, faTwitter, faInstagram, faCss3, faJs, faVuejs, faHtml5, faBootstrap, faNodeJs, faLinux, faSass, faNpm, faTrophy, faCheck)
Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.prototype.jquery = jquery

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
