<template>
  <div class="blog-wrapper">
    <BlogNav />
    <div class="blog-container">
      <BlogList v-if="blogRoot" />
      <router-view v-else />
    </div>
  </div>
</template>

<script>
import BlogNav from '@/components/Blog/BlogNav'
import BlogList from '@/components/Blog/BlogList'

export default {
  name: 'Blog',
  components: {
    BlogNav,
    BlogList
  },
  computed: {
    blogRoot() {
      console.log(this.$route)
      return this.$route.path === '/blog/'
    }
  },
  mounted() {
    console.log(this)
    // this.$forceUpdate()
  }
}
</script>

<style lang="scss">
@import './../assets/scss/blog.scss';

</style>