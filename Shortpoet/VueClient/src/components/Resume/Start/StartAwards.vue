<template>
  <section class="resume-section p-3 p-lg-5 d-flex flex-column" id="awards">
    <div class="my-auto">
      <h2 class="mb-4 mb-md-3">Natural Languages</h2>
      <ul class="fa-ul mb-0">
        <li
          v-for="(lang, i) in awards"
          :key="i"
        >
          <font-awesome-icon
            :class="lang.type + ' language-icon fa-li'" 
            :icon="['fa', 'flag']"
          ></font-awesome-icon>
          <span class="mb-5">{{ `${lang.languages} (${recase(lang.type)})` }} </span>
          </li>
        <li>
          <font-awesome-icon
            class="award-icon fa-li"
            :icon="['fa', 'trophy']"
          ></font-awesome-icon>
          Certified Interpreter
        </li>
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