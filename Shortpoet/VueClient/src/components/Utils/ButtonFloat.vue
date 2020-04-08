<template>
  <portal :to="target">
    <div v-if="href" type="input" :class="classObject">
      <a :href="href">
        <font-awesome-layers
          class="button-float-icon-layer fa-lg"
        >
          <font-awesome-icon class="button-float-icon-circle" size="2x" icon="circle" />
          <font-awesome-icon
            class="button-float-icon"
            size="2x"
            :transform="_icon.transform"
            :icon="_icon.icon"
          ></font-awesome-icon>
        </font-awesome-layers>
      </a>
    </div>
    <div v-if="pdfTarget" type="input" :class="classObject" @click="toPDF">
      <font-awesome-layers
        class="button-float-icon-layer fa-lg"
      >
        <font-awesome-icon class="button-float-icon-circle" size="2x" icon="circle" />
        <font-awesome-icon
          class="button-float-icon"
          size="2x"
          :transform="_icon.transform"
          :icon="_icon.icon"
        ></font-awesome-icon>
      </font-awesome-layers>
    </div>
  </portal>
</template>

<script>
import jsPDF from 'jspdf'
// using fork for now to solve this issue
// the changes i made with the icons as the deployed version still works
// https://github.com/niklasvh/html2canvas/issues/1868#issuecomment-599217709
import html2canvas from '@trainiac/html2canvas'

export default {
  name: 'ButtonFloat',
  components: {
  },
  props: {
    target: {
      type: String
    },
    href: {
      type: String,
      required: false
    },
    icon: {
      type: String
    },
    pdfTarget: {
      type: String
    }
    // handler: {
    //   type: Function,
    //   required: false
    // }
  },
  data () {
    return {
      iconMap: {
        pdf: {
          icon: 'file-pdf',
          transform: 'shrink-5 right-2.3'
        },
        save: {
          icon: 'save',
          transform: 'shrink-5 right-1'
        }
      }
    }
  },
  computed: {
    mobile () {
      return window.innerWidth < 768
    },
    classObject () {
      return {
        'button-float': true,
        'mobile': this.mobile
      }
    },
    _icon () {
      return this.iconMap[`${this.icon}`]
    }
  },
  methods: {
    toPDF () {
      // timeout is set to account for loading time i believe
      setTimeout(() => {
        console.log(this.target)
        html2canvas(document.getElementById(this.pdfTarget), {
          scale: 3,
          useCORS: true,
          allowTaint: true,
        }).then(canvas => {
          const image = canvas.toDataURL('image/jpeg', 1.0);
          const doc = new jsPDF('p', 'mm', 'a4');
          const pageWidth = doc.internal.pageSize.getWidth();
          const pageHeight = doc.internal.pageSize.getHeight();

          const widthRatio = pageWidth / canvas.width;
          const heightRatio = pageHeight / canvas.height;
          const ratio = widthRatio > heightRatio ? heightRatio : widthRatio;

          const canvasWidth = canvas.width * ratio;
          const canvasHeight = canvas.height * ratio;

          const marginX = (pageWidth - canvasWidth) / 2;
          const marginY = (pageHeight - canvasHeight) / 2;

          doc.addImage(image, 'JPEG', marginX, marginY, canvasWidth, canvasHeight, null, 'SLOW');
          doc.save(`Carlos_Soriano_${Date.now()}.pdf`);
        });
      }, 250);
    }
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

.mobile {
  font-size: 1rem;
  right: 2rem;
  bottom: 2rem;
}


</style>