<template>
<!-- https://dev.to/vycoder/creating-a-simple-blog-using-vue-with-markdown-2omd -->
<div class="article-wrapper">
  <nav class="nav">
    <ul class="nav">
      <li class="nav-item dropdown">
          <router-link class="nav-link dropdown-toggle" data-toggle="dropdown" to="" role="button" aria-haspopup="true" aria-expanded="false">Languages</router-link>
          <div class="dropdown-menu">
            <router-link class="dropdown-item" to="/blog/learning-to-unit-test-en">English</router-link>
            <router-link class="dropdown-item" to="/blog/learning-to-unit-test-es">Spanish</router-link>
          </div>
        </li>      
    </ul>
  </nav>
  <p>Test Article</p>
  <div class="article-container">
    <component :is="selectedArticle" />
  </div>
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
      const english = () => import('./../../components/Blog/Articles/learning-to-unit-test-en.md')
      const spanish = () => import('./../../components/Blog/Articles/learning-to-unit-test-es.md')
      return this.language === 'en' ? english : spanish
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