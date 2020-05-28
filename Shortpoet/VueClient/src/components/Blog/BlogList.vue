<template>
<!-- https://dev.to/vycoder/creating-a-simple-blog-using-vue-with-markdown-2omd -->

  <div class="blog-list">
    <ul>
      <li>
        <router-link to="/blog/learning-to-unit-test-en">Learning To Unit Test</router-link>
      </li>
    </ul>
  </div>
  
</template>

<script>
export default {
  name: 'BlogArticle',
  props: {
    language: String
  },
  computed: {
    // incorrect
    // selectedArticle: () => import('./../../components/Blog/Articles/')
    // correct
    selectedArticle: function () {
      console.log(this.language)
      // const title = 'learning-to-unit-test'
      // const articlePath = `./../../components/Blog/Articles/${title}.md`
      // console.log(articlePath)
      return () => import('./../../components/Blog/Articles/learning-to-unit-test.md')
      // return () => import(articlePath)
    }
  },
  mounted() {
    console.log('mounted from blogarticle')
    console.log(this.$route)
  }
}
</script>

<style>

</style>