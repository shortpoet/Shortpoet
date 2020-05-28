<template>
  <section class="" id="pdf-socials">
    <ul class="list-inline list-social-icons mb-0 mt-0 mr-lg-2">
      <li
        class="social-item"
        v-for="(social, i) in socials"
        :key="i"
      >
        <a :href="social.url">
          <span :style="iconStyleObject" class="social-icon-layer fa-stack fa-lg">
            <i class="fa fa-circle fa-stack-2x"></i>
            <!-- <i :class="'fa fa-' + social.social + ' fa-stack-1x fa-inverse'"></i> -->
            <i :class="'social-icon ' + social.icon + ' fa-stack-1x fa-inverse'"></i>
          </span>
          <span style="font-family: 'Open Sans'; font-size: .55rem" v-if="!social.social.includes('website')" :class="urlClass">{{social.url}}</span>
          <span style="font-family: 'Open Sans'; font-size: .55rem" v-else :class="urlClass">https://shortpoet.com</span>
        </a>
      </li>
    </ul>
  </section>
</template>

<script>
export default {
  name: 'PDFSocials',
  components: {
  },
  props: {
  renderPDF: {
    type: Boolean,
    default: false
  }
},
  data () {
    return {
      socials: [
        {
          social: 'github',
          icon: 'fa fa-github',
          url: 'https://github.com/shortpoet',
          transform: 'shrink-5'
        },
        {
          social: 'linkedin',
          icon: 'fa fa-linkedin',
          url: 'https://www.linkedin.com/in/carlos-soriano-49aaa97/',
          transform: 'shrink-6 right-1'
        },
        {
          social: 'instagram',
          icon: 'fa fa-instagram',
          url: 'https://www.instagram.com/shortpoet/',
          transform: 'shrink-5 right-1'
        },
        {
          social: 'twitter',
          icon: 'fa fa-twitter',
          url: 'https://twitter.com/shortpoet3',
          transform: 'shrink-6'
        },
        {
          social: 'website',
          icon: 'fa fa-home',
          url: '/',
          transform: 'shrink-6 right-2.5'
        }
      ]
    }
  },
  computed: {
    urlClass () {
      return this.renderPDF ?
      'social-url d-inline'
      :
      'social-url d-none d-md-inline'
    },
    iconStyleObject () {
      return this.renderPDF ?
      {
        fontFamily: 'FontAwesome',
        fontSize: '.65rem'
      }
      :
      {
        fontFamily: 'FontAwesome',
        fontSize: '.85rem'
      }
    },
  },
  methods: {
  }
}
</script>
