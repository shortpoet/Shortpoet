<template>
  <section class="resume-section mt-2 ml-3" id="interests">
    <div class="my-auto">
      <h4 class="mb-3">Interests</h4>
      <p class="mb-0">{{ interests }}</p>
    </div>
  </section>
</template>
<script>
export default {
  name: 'PDFInterests',
  props: {
    interests: {
      type: String
    }
  }
}
</script>

<style scoped>
#interests {
  align-items: center;
}
.short-poetry {
  height: 50%;
  width: 50%;  
}
.embed-container { position: relative; padding-bottom: 150%; height: 0; overflow: hidden; max-width: 100%; } 
.embed-container iframe, .embed-container object, .embed-container embed { position: absolute; top: 0; left: 0; width: 100%; height: 100%; }
</style>
