<template>
  <div class="blog-wrapper">
    <BlogNav />
    <div class="blog-container">
      <!-- <BlogArticle 
        :title="'test title'"
      /> -->
      <ul>
        <li>
          <router-link to="/blog/learning-to-unit-test-en">Learning To Unit Test</router-link>
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import BlogNav from '@/components/Blog/BlogNav'
// import BlogArticle from '@/components/Blog/BlogArticle'

export default {
  name: 'Blog',
  components: {
    BlogNav,
    // BlogArticle
  },
  computed: {
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