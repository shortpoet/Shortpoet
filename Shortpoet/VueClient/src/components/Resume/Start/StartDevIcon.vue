<template>
  <div class="">
    <i v-if="!isImage" :class="source"></i>
    <img v-else :class="imgClass" :src="source"/>
    <span v-if="name" class="devicon-name">{{ name }}</span>
  </div>
</template>

<script>

export default {
  name: 'StartDevIcon',
  props: {
    source: {
      type: String
    },
    name: {
      type: String,
      default: null
    }
  },
  components: {
  },
  data () {
    return {
    }
  },
  computed: {
    isImage () {
      return this.source.match(/svg|jpg|png|jpeg/g) !== null
    },
    imgClass () {
      if (this.source.includes('vue')) {
        return 'vue-devicon'
      } else if (this.source.includes('d3')) {
        return 'd3-devicon'
      } else {
        return 'tableau-devicon'
      }
    }
  },
  methods: {
  },
  mounted () {
  }
}
</script>
