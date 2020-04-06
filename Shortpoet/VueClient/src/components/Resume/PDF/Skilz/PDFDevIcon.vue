<template>
  <div class="">
    <i v-if="!isImage" :class="source"></i>
    <img v-else :class="imgClass" :src="source"/>
    <span v-if="name" :class="devicon-name">{{ name }}</span>
  </div>
</template>

<script>

export default {
  name: 'PDFDevIcon',
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
      console.log(this.source)
      console.log(this.source.match(/svg|jpg|png|jpeg/g) !== null)
      return this.source.match(/svg|jpg|png|jpeg/g) !== null
    },
    imgClass () {
      return this.source.includes('vue') ? 'vue-devicon' : 'd3-devicon'
    }
  },
  methods: {
  },
  mounted () {
  }
}
</script>
