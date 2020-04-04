<template>
  <hr 
    :style="styleObject"
  />
  <!-- <hr /> -->
</template>
<script>
export default {
  name: 'PDFBorder',
  props: {
    size: {
      type: Number,
      default: 1
    },
    color: {
      type: String,
      default: null
    },
  },
  computed: {
    styleObject () {
      if (this.color ) {
        return {
          borderWidth: .25*(this.size) + 'rem',
          color: this.color
        }
      } else {
        return {
          borderWidth: .25*(this.size) + 'rem'
        }
      }
    }
  }
}
</script>
<style scoped lang="scss">
  hr {
    border: .25rem solid;
    border-radius: .25rem;
    color: $primary;
    margin: 0rem 2rem 0rem 2rem;
  }

  // // this apparently makes a box
  // hr {
  //   height: 1rem;
  //   width: 1rem;
  //   border: .25rem solid;
  //   border-radius: .25rem;
  //   color: $primary;
  //   margin: 0rem 2rem 0rem 2rem;
  // }
</style>