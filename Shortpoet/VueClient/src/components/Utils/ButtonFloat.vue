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
    <div v-if="pdfTarget" type="input" :class="classObject" @click="showModal">
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
    <div class="modal-slot">
      <Modal
        v-show="isModalVisible"
        @close="closeModal"
        @toPDF="toPDF"
        @toCanvas="toCanvas"
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
    </div>
  </portal>
</template>

<script>
import Modal from '@/components/Utils/Modal'

import jsPDF from 'jspdf'
// using fork for now to solve this issue
// the changes i made with the icons as the deployed version still works
// https://github.com/niklasvh/html2canvas/issues/1868#issuecomment-599217709
import html2canvas from '@trainiac/html2canvas'
// import html2canvas from 'html2canvas'

export default {
  name: 'ButtonFloat',
  components: {
    Modal
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
      },
      isModalVisible: false,
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
    showModal() {
      this.isModalVisible = true
    },
    closeModal() {
      this.isModalVisible = false
    },
    toCanvas () {
      html2canvas(document.getElementById(this.pdfTarget), {
          // scale: 5,
          // useCORS: true,
          allowTaint: true,
        }).then(canvas => {
          console.log(canvas)
          // var _canvas = document.createElement('canvas');
          document.body.appendChild(canvas);
        })
    },
    toPDF() {
      // close modal first
      this.isModalVisible = false
      // timeout is set to account for loading time i believe
      setTimeout(() => {
        console.log(this.target)
        html2canvas(document.getElementById(this.pdfTarget), {
          scale: 5,
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

</style>