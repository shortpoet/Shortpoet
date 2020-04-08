<template>
  <section class="resume-section mt-3" id="awards">
    <div class="my-auto">
      <h4 class="mb-3">Natural Languages &amp; Certifications</h4>
      <ul class="fa-ul mb-0">
        <li
          v-for="(lang, i) in awards"
          :key="i"
          class="mb-1"
        >
          <i :class="lang.type + ' language-icon fa fa-flag fa-li'"></i>
          <span class="mb-5">{{ `${lang.languages} (${recase(lang.type)})` }} </span>
        </li>
        <li>
          <i class="award-icon fa fa-trophy fa-li"></i>
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
