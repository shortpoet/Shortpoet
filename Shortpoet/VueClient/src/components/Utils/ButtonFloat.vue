<template>
  <portal :to="target">
    <div v-if="href" type="input" :class="classObject" @click="onClick">
      <a :href="href">
        <font-awesome-layers
          class="button-float-icon-layer fa-lg"
        >
          <font-awesome-icon class="button-float-icon-circle" size="2x" icon="circle" />
          <font-awesome-icon
            class="button-float-icon"
            size="2x"
            :transform="_icon.transform"
            :icon="_icon.icon"
          ></font-awesome-icon>
        </font-awesome-layers>
      </a>
    </div>
    <div v-else type="input" :class="classObject" @click="onClick">
      <font-awesome-layers
        class="button-float-icon-layer fa-lg"
      >
        <font-awesome-icon class="button-float-icon-circle" size="2x" icon="circle" />
        <font-awesome-icon
          class="button-float-icon"
          size="2x"
          :transform="_icon.transform"
          :icon="_icon.icon"
        ></font-awesome-icon>
      </font-awesome-layers>
    </div>
  </portal>
</template>

<script>
export default {
  name: 'ButtonFloat',
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
    onClick: {
      type: Function,
      required: false,
      default: () => {}
    }
  },
  data () {
    return {
      iconMap: {
        pdf: {
          icon: 'file-pdf',
          transform: 'shrink-5 right-2.3'
        },
        save: {
          icon: 'save',
          transform: 'shrink-5 right-1'
        }
      }
    }
  },
  computed: {
    mobile () {
      return window.innerWidth < 768
    },
    classObject () {
      return {
        'button-float': true,
        'mobile': this.mobile
      }
    },
    _icon () {
      return this.iconMap[`${this.icon}`]
    }
  },
  methods: {
  },
  mounted () {
  }
}
</script>

<style lang="scss">
.button-float {
  z-index: 1;
  position: fixed;
  right: 4rem;
  bottom: 3rem;
  opacity: 50%;
  .button-float-icon-circle {
    color: $gray-500;
  }
  font-size: 1.5rem;
  .button-float-icon-layer {
  }
  .button-float-icon {
    color: $white;
  }
}

.mobile {
  font-size: 1rem;
  right: 2rem;
  bottom: 2rem;
}


</style>