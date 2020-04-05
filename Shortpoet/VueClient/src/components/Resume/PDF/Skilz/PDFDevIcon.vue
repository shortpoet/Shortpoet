<template>
  <div class="">
    <i v-if="!isImage" :class="'devicons ' + source"></i>
    <img v-else class="vue-devicon" :src="source"/>
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
      console.log(this.source.match(/svg|jpg|png|jpeg/g) !== null)
      return this.source.match(/svg|jpg|png|jpeg/g) !== null
    }
  },
  methods: {
  },
  mounted () {
  }
}
</script>
