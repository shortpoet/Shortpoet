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
          <span v-if="!social.social.includes('website')" class="social-url d-none d-md-inline">{{social.url}}</span>
          <span v-else class="social-url d-none d-md-inline">https://shortpoet.com</span>
        </a>
      </li>
      <li>
        <button
          type="button"
          class="btn"
          @click="showModal"
        >
          Open Modal!
        </button>

        <Modal
          v-show="isModalVisible"
          @close="closeModal"
        >
          <!-- <template v-slot:header>
            <h1>Test Header</h1>
          </template>
          <template v-slot:body>
            <h1>Test Body</h1>
          </template>
          <template v-slot:footer>
            <h1>Test Footer</h1>
          </template> -->
        </Modal>
      </li>        
    </ul>
  </section>
</template>

<script>
import Modal from '@/components/Utils/Modal'
export default {
  name: 'PDFSocials',
  components: {
    Modal
  },
  props: {
  },
  data () {
    return {
      isModalVisible: false,
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
          url: '/',
          transform: 'shrink-6 right-2.5'
        }
      ]
    }
  },
  computed: {
  },
  methods: {
    showModal() {
      this.isModalVisible = true;
    },
    closeModal() {
      this.isModalVisible = false;
    }
  }
}
</script>
