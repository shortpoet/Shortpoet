<template>
  <div class="blog-wrapper">
    <BlogNav />
    <div class="blog-container">
      <UnitTestArticle />
    </div>
  </div>
</template>

<script>
import articles from '@/assets/articles.js'
import BlogNav from '@/components/Blog/BlogNav'
import UnitTestArticle from '@/components/Blog/Articles/learning-to-unit-test.md'
const md = require('markdown-it')({
  html: true,
  linkify: true,
  typographer: true
})
export default {
  name: 'Blog',
  components: {
    UnitTestArticle,
    BlogNav
  },
  computed: {
    title: () => articles[0].title,
    body: () => articles[0].body,
    _body: () => md.render(articles[0].body)
  },
  updated() {
    // this.$forceUpdate()
  }
}
</script>

<style lang="scss">
@import './../assets/scss/blog.scss';

</style>