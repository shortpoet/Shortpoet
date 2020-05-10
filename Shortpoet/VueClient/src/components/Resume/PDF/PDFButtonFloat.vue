<template>
  <portal :to="target">
    <!-- 
      * previously had this selector to unify the components - split after styling diverged
      * v-if="href" 
      * v-if="pdfTarget"
    </div> -->
    <div type="input" :class="classObject" @click="showModal">
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
      <PDFModal
        v-show="isModalVisible"
        @close="closeModal"
        @to-pdf="toPDF"
        @to-page="toPage"
        @to-canvas="toCanvas"
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
      </PDFModal>
    </div>
  </portal>
</template>

<script>
import PDFModal from '@/components/Resume/PDF/PDFModal'

import jsPDF from 'jspdf'
// using fork for now to solve this issue
// the changes i made with the icons as the deployed version still works
// https://github.com/niklasvh/html2canvas/issues/1868#issuecomment-599217709
import html2canvas from '@trainiac/html2canvas'
// import html2canvas from 'html2canvas'
var FontFaceObserver = require('fontfaceobserver');
export default {
  name: 'PDFButtonFloat',
  components: {
    PDFModal
  },
  props: {
    target: {
      type: String
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
          allowTaint: true,
        }).then(canvas => {
          console.log(canvas)
          document.body.appendChild(canvas);
        })
    },
    toPage () {
      const vm = this;
      vm.isModalVisible = false;
      let target = document.getElementById(vm.pdfTarget);
      var fontA = new FontFaceObserver('Open Sans');
      var fontB = new FontFaceObserver('Saira Extra Condensed');
      vm.$emit('to-pdf', true);
      Promise.all([fontA.load(), fontB.load()]).then(function () {
        console.log('Family A & B have loaded');
        setTimeout(()=>{
          html2canvas(target, {
            width: 810,
            scale: 5,
            useCORS: true,
            allowTaint: true,
          }).then(function(canvas) {
            var pdf = new jsPDF('p', 'pt', 'a4');
            console.log(target.clientHeight);
            console.log(canvas, pdf)
            // https://stackoverflow.com/questions/24069124/how-to-save-a-image-in-multiple-pages-of-pdf-using-jspdf
            // https://stackoverflow.com/questions/19272933/jspdf-multi-page-pdf-with-html-renderer/34934497#34934497
            vm.paginate(target, canvas, pdf);
            pdf.save(`Carlos_Soriano_${Date.now()}.pdf`);
            vm.$emit('toPDF', false);
          });
        }, 250);
      });
    },
    paginate (target, canvas, pdf) {
      const imgData = canvas.toDataURL('image/png');
      const imgWidth = 595; 
      const pageHeight = 842;  
      let imgHeight = canvas.height * imgWidth / canvas.width;
      let heightLeft = imgHeight;
      pdf.addImage(imgData, 'PNG', 0, 0, imgWidth, imgHeight, null, 'SLOW');
      heightLeft -= pageHeight;
      let secondHalf = heightLeft - imgHeight
      pdf.addPage();
      pdf.addImage(imgData, 'PNG', 0, secondHalf, imgWidth, imgHeight, null, 'SLOW');
      return pdf;
    },
    toPDF() {
      const vm = this;
      // close modal first
      vm.isModalVisible = false;
      // timeout is set to account for loading time i believe
      var fontA = new FontFaceObserver('Open Sans');
      var fontB = new FontFaceObserver('Saira Extra Condensed');
      Promise.all([fontA.load(), fontB.load()]).then(function () {
        console.log('Family A & B have loaded');
        setTimeout(() => {
          console.log(vm.target)
          html2canvas(document.getElementById(vm.pdfTarget), {
            // setting width and height cuts it off at the "one page mark"
            // width: 810,
            // height: 1100,
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
            const marginX = 0 //(pageWidth - canvasWidth) / 2;
            const marginY = 0 //(pageHeight - canvasHeight) / 2;
            doc.addImage(image, 'JPEG', marginX, marginY, canvasWidth, canvasHeight, null, 'SLOW');
            doc.save(`Carlos_Soriano_${Date.now()}.pdf`);
          });
        }, 250);
      });      
    },
  },
  mounted () {
  }
}
</script>

<style lang="scss">

</style>