<template>
  <!-- TODO set fontFamily only on icon not text - only req'd on pdf -->
  <section class="resume-section pl-3 pl-lg-5 py-1 d-flex d-column" id="start-socials">
    <div class="my-auto">
      <ul class="list-inline list-social-icons mb-0 mt-0">
        <li
          :style="{fontFamily: 'FontAwesome'}"
          class="social-item list-inline-item "
          v-for="(social, i) in socials"
          :key="i"
        >
          <a :href="social.url">
             <span class="fa-stack fa-lg">
              <i class="fa fa-circle fa-stack-2x"></i>
              <!-- <i :class="'fa fa-' + social.social + ' fa-stack-1x fa-inverse'"></i> -->
              <i :class="social.icon + ' fa-stack-1x fa-inverse'"></i>
            </span>
          </a>
        </li>
      </ul>
    </div>
  </section>
</template>

<script>
export default {
    name: 'StartSocials',
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
            social: 'file-pdf',
            icon: 'far fa-file-pdf-o',
            url: window.location.protocol + '//' + window.location.host + '/pdf',
            // for router-link version to test built dist
            // url: '/pdf',
            transform: 'shrink-6 right-2.5'
          }
        ]
      }
    },
    computed: {
    }
}
</script>
