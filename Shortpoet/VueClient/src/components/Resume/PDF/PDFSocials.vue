<template>
  <section class="" id="pdf-socials">
    <ul class="list-inline list-social-icons mb-0 mt-0">
      <li
        :style="{fontFamily: 'FontAwesome'}"
        class="social-item"
        v-for="(social, i) in socials"
        :key="i"
      >
        <a :href="social.url">
            <span class="social-icon-layer fa-stack fa-lg">
            <i class="fa fa-circle fa-stack-2x"></i>
            <!-- <i :class="'fa fa-' + social.social + ' fa-stack-1x fa-inverse'"></i> -->
            <i :class="'social-icon ' + social.icon + ' fa-stack-1x fa-inverse'"></i>
          </span>
          <span class="social-url d-none d-md-inline">{{social.url}}</span>
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
            icon: 'fa fa-globe',
            url: 'https://shortpoet.com',
            transform: 'shrink-6 right-2.5'
          }
        ]
      }
    },
    computed: {
    }
}
</script>
