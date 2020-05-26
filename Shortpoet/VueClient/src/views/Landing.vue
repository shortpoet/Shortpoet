<template>
  <main>
    <div class="landing-container">

      <div class="title-bar">carlos@shortpoet: ~</div>

      <div class="code-container">
        <div @click="navigate('/resume')" class="clickable-area">
          <p>> cd Resume</p>
          <p>></p>
          <p>></p>
          <p>></p>
        </div>
        <div @click="navigate('/blog')" class="clickable-area">
          <p>> cd Blog</p>
          <p>></p>
          <p>></p>
          <p>></p>
        </div>
      </div>
    </div>

    <pre>
      <code>
        *cd => change directory / navigate
      </code>
    </pre>

  </main>
</template>

<script>
export default {
  name: 'Landing',
  components: {
    
  },
  methods: {
    navigate(route) {
      this.$router.push(route)
    }
  }
}
</script>

<style lang="scss">
@import './../assets/scss/landing.scss';

</style>