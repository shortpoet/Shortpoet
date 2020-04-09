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
        @toPage="toPage"
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
var FontFaceObserver = require('fontfaceobserver');
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
    toPage () {
      var vm = this;
      setTimeout(()=>{
        html2canvas(document.getElementById(vm.pdfTarget), {
          // width: '210mm',
          // height: '297mm',        
          // width: '595px',
          // height: '842px',
            useCORS: true,
            allowTaint: true,
        }).then(function(canvas) {
          var pdf = new jsPDF('p', 'pt', 'a4');

          for (var i = 0; i <= vm.pdfTarget.clientHeight/842; i++) {
              //! This is all just html2canvas stuff
              var srcImg  = canvas;
              var sX      = 0;
              var sY      = 842*i; // start 980 pixels down for every new page
              var sWidth  = 595;
              var sHeight = 842;
              var dX      = 0;
              var dY      = 0;
              var dWidth  = 595;
              var dHeight = 842;

              var onePageCanvas = document.createElement("canvas");
              onePageCanvas.setAttribute('width', 595);
              onePageCanvas.setAttribute('height', 842);
              var ctx = onePageCanvas.getContext('2d');
              // details on this usage of this function: 
              // https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API/Tutorial/Using_images#Slicing
              ctx.drawImage(srcImg,sX,sY,sWidth,sHeight,dX,dY,dWidth,dHeight);

              // document.body.appendChild(canvas);
              var canvasDataURL = onePageCanvas.toDataURL("image/jpeg", 1.0);

              var width         = onePageCanvas.width;
              var height        = onePageCanvas.clientHeight;

              //! If we're on anything other than the first page,
              // add another page
              if (i > 0) {
                pdf.addPage(595, 842); //8.5" x 11" in pts (in*72)
              }
              //! now we declare that we're working on that page
              pdf.setPage(i+1);
              //! now we add content to that page!
              pdf.addImage(canvasDataURL, 'JPEG', 0, 0, (width*.72), (height*.71), null, 'SLOW');
              // pdf.addImage(canvasDataURL, 'JPEG', marginX, marginY, canvasWidth, canvasHeight, null, 'SLOW');

          }
          //! after the for loop is finished running, we save the pdf.
          pdf.save(`Carlos_Soriano_${Date.now()}.pdf`);
        });
      }, 250);
    },
    toPDF() {
      const vm = this
      // close modal first
      vm.isModalVisible = false
      // timeout is set to account for loading time i believe
      var fontA = new FontFaceObserver('Open Sans');
      var fontB = new FontFaceObserver('Saira Extra Condensed');
      Promise.all([fontA.load(), fontB.load()]).then(function () {
        console.log('Family A & B have loaded');
        setTimeout(() => {
          console.log(vm.target)
          html2canvas(document.getElementById(vm.pdfTarget), {
            width: 810,
            height: 1100,
            scale: 5,
            useCORS: true,
            allowTaint: true,
          }).then(canvas => {
            const image = canvas.toDataURL('image/jpeg', 1.0);
            const doc = new jsPDF('p', 'mm', 'a4');
            const pageWidth = doc.internal.pageSize.getWidth();
            const pageHeight = doc.internal.pageSize.getHeight();

            console.log(pageWidth)
            console.log(pageHeight)

            const widthRatio = pageWidth / canvas.width;
            const heightRatio = pageHeight / canvas.height;
            const ratio = widthRatio > heightRatio ? heightRatio : widthRatio;

            console.log(canvas.width)
            console.log(canvas.height)

            console.log(widthRatio)
            console.log(widthRatio)
            

            const canvasWidth = canvas.width * ratio;
            const canvasHeight = canvas.height * ratio;

            console.log(canvasWidth)
            console.log(canvasHeight)

            const marginX = 0 //(pageWidth - canvasWidth) / 2;
            const marginY = 0 //(pageHeight - canvasHeight) / 2;
            
            console.log(marginX)
            console.log(marginY)

            console.log(image)

            doc.addImage(image, 'JPEG', marginX, marginY, canvasWidth, canvasHeight, null, 'SLOW');
            doc.save(`Carlos_Soriano_${Date.now()}.pdf`);
          });
        }, 250);
      });      
    }
  },
  mounted () {
  }
}
</script>

<style lang="scss">

</style>