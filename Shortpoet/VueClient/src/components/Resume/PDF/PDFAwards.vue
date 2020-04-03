<template>
  <section class="resume-section" id="awards">
    <div class="my-auto">
      <h4 class="mb-3">Spoken Languages &amp; Certifications</h4>
      <ul class="fa-ul mb-0">
        <li
          v-for="(lang, i) in awards"
          :key="i"
          class="mb-1"
        >
          <font-awesome-icon
            :class="lang.type + ' language-icon fa-li'" 
            :icon="['fa', 'flag']"
          ></font-awesome-icon>
          <span class="mb-5">{{ recase(lang.type) }}: {{ lang.languages }}</span>
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
  name: 'PDFAwards',
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
