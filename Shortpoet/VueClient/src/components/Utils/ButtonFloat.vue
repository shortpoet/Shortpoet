<template>
  <portal to="pdf-button-float">
    <div type="input" class="button-float">
      <a href="/pdf">
        <font-awesome-layers
          class="button-float-icon-layer fa-lg"
          @click="toPDF"
        >
          <font-awesome-icon class="button-float-icon-circle" size="2x" icon="circle" />
          <font-awesome-icon
            class="button-float-icon"
            size="2x"
            transform="shrink-5 right-2.5"
            icon="file-pdf"
          ></font-awesome-icon>
        </font-awesome-layers>
      </a>
    </div>
  </portal>
</template>

<script>
export default {
  name: 'ButtonFloat',
  components: {
  },
  props: {
    target: {
      type: String
    }
  },
  data () {
    return {
    }
  },
  computed: {
  },
  methods: {
  },
  mounted () {
  }
}
</script>

<style lang="scss">
.button-float {
  z-index: 1;
  position: fixed;
  right: 4rem;
  bottom: 3rem;
  opacity: 50%;
  .button-float-icon-circle {
    color: $gray-500;
  }
  font-size: 1.5rem;
  .button-float-icon-layer {
  }
  .button-float-icon {
    color: $white;
  }
}


</style>