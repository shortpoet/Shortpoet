<template>
  <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="awards">
    <div class="my-auto">
      <h2 class="mb-5">Natural Languages</h2>
      <ul class="fa-ul mb-0">
        <li
          v-for="(lang, i) in awards"
          :key="i"
        >
          <i :class=" lang.type + 'language-icon fa-li fa fa-flag'"></i>
          {{ recase(lang.type) }}: {{ lang.languages }}
          </li>
        <li>
          <i class="award icon fa-li fa fa-trophy"></i>
          Certified Interpreter</li>
      </ul>
    </div>
  </section>
</template>

<script>
import _recase from '@/utils/recase.js'
export default {
  name: 'StartAwards',
  props: {
    awards: {
      type: Array,
      default: () => []
    }
  },
  methods: {
    recase(input) {
      return _recase(input)
    }
  }
}
</script>

<style scoped>

</style>