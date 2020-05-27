<template>
<!-- https://dev.to/vycoder/creating-a-simple-blog-using-vue-with-markdown-2omd -->
<div class="article-wrapper">
  <div class="article-container">
    <component :is="selectedArticle" />
  </div>
</div>
  
</template>

<script>
export default {
  name: 'BlogArticle',
  computed: {
    selectedArticle: () => ''
  }

}
</script>

<style>

</style>