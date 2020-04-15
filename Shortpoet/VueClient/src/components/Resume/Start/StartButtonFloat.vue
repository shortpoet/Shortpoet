<template>
  <portal :to="target">
      <!-- div containing all elements hidden at first -->
      <div :class="rippleContainer">
        <div :class="rippleMask">
          <div class="ripple-content">
            <slot name="ripple-content">
              Check out the other layout by clicking the pdf icon.
            </slot>
          </div>
        </div>
        <div :class="iconHalo">
          <div class="icon-circle">
            <font-awesome-icon
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
      this.$emit('ripple')
    }
  },
  mounted () {
  }
}
</script>

<style lang="scss">
// @import './../../assets/scss/_button-float3.scss';
</style>