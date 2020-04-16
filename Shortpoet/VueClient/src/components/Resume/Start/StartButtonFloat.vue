<template>
  <portal :to="target">
      <!-- 
        * div containing all elements hidden at first 
        * blur to close
        * has to be on root else have to click in the element where it's placed or use js to .blur()
        * https://forum.vuejs.org/t/how-to-implement-a-click-outside-event-like-vue-multiselect/24148
        * https://github.com/shentao/vue-multiselect/blob/master/src/Multiselect.vue#L5
        * alternative using event listeners
        * https://forum.vuejs.org/t/best-way-to-blur-close-a-contextmenu/27524
      -->
      <div :class="rippleContainer" >
        <div  :class="rippleMask">
          <div class="ripple-content">
            <slot name="ripple-content">
              Check out the other layout by clicking the pdf icon.
            </slot>
          </div>
        </div>
        <div :class="iconHalo">
          <div class="icon-circle">

            <!-- <font-awesome-icon
              v-if="!isExpanded"
              class="button-float-icon"
              size="2x"
              :transform="_icon.transform"
              :icon="_icon.icon"
              @click="open"
            ></font-awesome-icon>
            <a v-else href="/pdf">
              <font-awesome-icon
                class="button-float-icon"
                size="2x"
                :transform="_icon.transform"
                :icon="_icon.icon"
              ></font-awesome-icon>
            </a> -->

            <font-awesome-icon
              ref="float-icon-rocket"
              v-if="!isExpanded"
              class="button-float-icon"
              size="2x"
              :transform="iconMap['rocket'].transform"
              :icon="iconMap['rocket'].icon"
              @click="open"
            ></font-awesome-icon>
            <a v-else href="/pdf">
              <font-awesome-icon
                ref="float-icon-pdf"
                class="button-float-icon"
                size="2x"
                :transform="iconMap['pdf'].transform"
                :icon="iconMap['pdf'].icon"
              ></font-awesome-icon>
            </a>

          </div>
        </div>
      </div>
  </portal>
</template>

<script>

export default {
  name: 'StartButtonFloat',
  components: {
  },
  props: {
    target: {
      type: String
    },
    href: {
      type: String,
      required: false
    },
    icon: {
      type: String
    },
    isExpanded: {
      type: Boolean,
      default: false
    }
    // handler: {
    //   type: Function,
    //   required: false
    // }
  },
  data () {
    return {
      iconMap: {
        pdf: {
          icon: 'file-pdf',
          transform: ''
        },
        save: {
          icon: 'save',
          transform: 'shrink-5 right-1'
        },
        rocket: {
          icon: 'rocket',
          transform: 'down-1 left-1'
        }
      },
      // isExpanded: false,
    }
  },
  computed: {
    mobile () {
      return window.innerWidth < 768
    },
    rippleContainer () { //([^\s|]'),
      return {
        'ripple-container': true,
        'mobile': this.mobile
      }
    },
    iconHalo () {
      return this.isExpanded ? 'icon-halo icon-halo-show' : 'icon-halo icon-halo-hide'
    },
    rippleMask () {
      return this.isExpanded ? 'ripple-mask ripple-mask-show' : 'ripple-mask ripple-mask-hide'
    },
    _icon () {
      return this.iconMap[`${this.icon}`]
    }
  },
  methods: {
    open () {
      this.$emit('ripple-open')
    },
    close () {
      if (this.isExpanded) {
        this.$emit('ripple-close')
      }
    },
    handleClickOutside (evt) {
      if (this.isExpanded === true) {
        if (evt.target.tagName !== 'path') {
          this.$emit('ripple-close')
        }
      }
    },
  },
  destroyed () {
    document.removeEventListener('click', this.handleClickOutside)
  },
  mounted () {
    console.log('mounted from sbutton')
    console.log(this.isExpanded)
    setTimeout(() => {
      document.addEventListener('click', this.handleClickOutside)
    }, 250)
  }
}
</script>

<style lang="scss">
// @import './../../assets/scss/_button-float3.scss';
</style>