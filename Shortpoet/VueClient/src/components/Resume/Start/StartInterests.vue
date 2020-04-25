<template>
  <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="interests">
    <div class="my-auto">
      <h2 class="mb-4 mb-md-3">Interests</h2>
      <p class="mb-4">{{ interests }}</p>
    </div>
    <div class="short-poetry my-auto">
      <!-- <div class='embed-container'><iframe src='//instagram.com/p/BK2nW22Bg1l/embed/' frameborder='0' scrolling='no' allowtransparency='true'></iframe></div>     -->
      <div id="poem-container" class="mt-3 mt-md-0 mr-0 text-center">
        <img class="img-fluid img-profile rounded" :src="pic" alt="poem">
      </div>
    </div>
  </section>
</template>
<script>
export default {
  name: 'StartInterests',
  props: {
    interests: {
      type: String
    }
  },
  data () {
    return {
      pic: require('@/assets/poem.jpg'),
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
