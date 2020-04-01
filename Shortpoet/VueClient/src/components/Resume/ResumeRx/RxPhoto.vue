<template>
  <img
    class="rounded object-cover mr-4"
    :src="pic"
    alt="Resume Photograph"
    style="{ width: '120px', height: '120px' }"
  />
</template>

<script>
export default {
  name: 'RxPhoto',
  props: {
    pic: {
      type: Array,
      default: () => []
    }
  },
  methods: {
  }
}
</script>

<style scoped>

</style>