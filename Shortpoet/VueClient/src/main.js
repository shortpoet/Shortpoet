import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

import jquery from 'jquery'

require('bootstrap')
require('jquery.easing')

require('bootstrap/dist/css/bootstrap.css')
require('popper.js')

require('devicons/css/devicons.css')

// Font Awesome Vue
import { library } from '@fortawesome/fontawesome-svg-core'
import { faLinkedin, faGithub, faTwitter, faInstagram, faCss3, faJs, faVuejs, faHtml5, faBootstrap, faNodeJs, faLinux, faSass, faNpm, faFontAwesomeFlag } from '@fortawesome/free-brands-svg-icons'
import { faTrophy, faCheck, faFlag, faCircle, faFilePdf, faSave, faGlobe} from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon, FontAwesomeLayers } from '@fortawesome/vue-fontawesome'
// import { dom } from '@fortawesome/fontawesome-svg-core'

// dom.watch()

library.add(
  faLinkedin, faGithub, faTwitter, faInstagram, faCss3, faJs, faVuejs, 
  faHtml5, faBootstrap, faNodeJs, faLinux, faSass, faNpm, 
  faTrophy, faCheck, faFlag, faFontAwesomeFlag, 
  faCircle, faFilePdf, faSave, faGlobe
  )
Vue.component('font-awesome-icon', FontAwesomeIcon)
Vue.component('font-awesome-layers', FontAwesomeLayers)

Vue.prototype.jquery = jquery

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
