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
        @to-pdf="savePDF"
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
import { colorLog } from '@/utils/colorLog'
import { log } from '@/utils/colorLog'
// log('blue', 'test')
import jsPDF from 'jspdf'
// using fork for now to solve this issue
// the changes i made with the icons as the deployed version still works
// https://github.com/niklasvh/html2canvas/issues/1868#issuecomment-599217709
import html2canvas from '@trainiac/html2canvas'
// import html2canvas from 'html2canvas'
const FontFaceObserver = require('fontfaceobserver');

// https://stackoverflow.com/questions/38975138/is-using-async-in-settimeout-valid
// let wait = ms => new Promise(resolve => setTimeout(resolve, ms));

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
      canvas: null
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
    /* istanbul ignore next */
    toCanvas () {
      html2canvas(document.getElementById(this.pdfTarget), {
          allowTaint: true,
        }).then(canvas => {
          document.body.appendChild(canvas);
        })
    },
    async checkFonts () {
      var fontA = new FontFaceObserver('Open Sans')
      var fontB = new FontFaceObserver('Saira Extra Condensed')
      // must return otherwise load order is not correct
      try {
        return Promise.all([fontA.load(), fontB.load()]).then(function () {
          console.log('Family A & B have loaded')
        })
      }
      catch {err => console.log(err)}
    },
    async getCanvas (options) {
      log('green', 'about to getCanvas')
      const vm = this
      const target = document.getElementById(vm.pdfTarget)
      try {
        let canvas = html2canvas(target, {
          ...options
        })
        return canvas
      }
      catch {err => console.log(err)}
    },
    getDataURL (canvas) {
      // first one is significantly faster
      // second makes mage unresponsive for like 3 secs
      // go unit tests!
      return canvas.toDataURL('image/jpeg', 1.0);
      // return canvas.toDataURL('image/png');
    },
    // close modal first
    // [Vue warn]: Method "isModalVisible" has type "boolean" in the component definition. Did you reference the function correctly?      this.closeModal()
    // [Vue warn]: Method "isModalVisible" has already been defined as a data property.
    // vm.isModalVisible = false
    // vm.closeModal()
    // both threw those warning but only in test
    // realized that the click event on the modal buttons 
    // bubbled up to parent backdrop div that closes on click
    // which is why the modal tests had that double event that had me wondering
    // seems then no need to call close from here which makes sense as far as separation of concerns i guess
    //
    // setting width and height cuts it off at the "one page mark"
    // width: 810,
    // height: 1100,
    createDoc (canvas) {
      const doc = new jsPDF('p', 'mm', 'a4');
      // log('green', doc.internal)
      const pageWidth = doc.internal.pageSize.getWidth();
      const pageHeight = doc.internal.pageSize.getHeight();
      // log('cyan', pageWidth, pageHeight)
      // log('cyan', pageHeight)
      const widthRatio = pageWidth / canvas.width;
      const heightRatio = pageHeight / canvas.height;
      const ratio = widthRatio > heightRatio ? heightRatio : widthRatio;
      // log('blue', ratio)
      const canvasWidth = canvas.width * ratio;
      const canvasHeight = canvas.height * ratio;
      const marginX = 0 //(pageWidth - canvasWidth) / 2;
      const marginY = 0 //(pageHeight - canvasHeight) / 2;
      // log('red', doc)
      return {
        doc,
        marginX,
        marginY,
        canvasWidth,
        canvasHeight
      }
    },
    async setCanvas(options, callback) {
      log('green', 'about to start setCanvas')
      const vm = this
      await vm.checkFonts()
      colorLog('fonts have been checked', 'violet')
      log('blue', 'fonts have been checked')
      setTimeout(async () => {
        try {
          const canvas = await vm.getCanvas(options)
          log('red', 'canvas')
          log('yellow', 'after timeout')
          console.log(canvas)
          this.canvas = canvas
          callback()
        }
        catch(err) {
          console.log(err)
        }
      }, 250);
      log('red', 'last line of setCanvas')
    },
    async toPDF(canvas) {
      const vm = this
      try {
        const image = vm.getDataURL(canvas)
        const { doc, marginX, marginY, canvasWidth, canvasHeight } = vm.createDoc(canvas)
        doc.addImage(image, 'JPEG', marginX, marginY, canvasWidth, canvasHeight, null, 'SLOW');
        return doc
      }
      catch(err) {
        console.log(err)
      }
    },
    async savePDF() {
      const vm = this
      log('blue', 'savePDF from Button Float')
      const options = {
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }
      try {
        const callback = async () => {
          const doc = await vm.toPDF(this.canvas)
          log('green', 'before save')
          // log('green', doc)
          const fileName = `Carlos_Soriano_${Date.now()}.pdf`
          doc.save(fileName);
          return {
            doc,
            fileName
          }
          // return Promise.resolve({
          //   doc,
          //   fileName
          // })
        }
        log('cyan', 'about to do callback')
        vm.setCanvas(options, callback)
      }
      catch(err) {
        console.log(err)
      }
    },
    // https://stackoverflow.com/questions/24069124/how-to-save-a-image-in-multiple-pages-of-pdf-using-jspdf
    // https://stackoverflow.com/questions/19272933/jspdf-multi-page-pdf-with-html-renderer/34934497#34934497
    // insterstingly this used to work even when pdf was not reassigned to paginated
    // eg 
    // vm.paginate(target, canvas, pdf);
    // paginated.save(`Carlos_Soriano_${Date.now()}.pdf`);
    // vm.$emit('toPDF', false);
    async toPage () {
      const vm = this
      const options = {
        width: 810,
        scale: 5,
        useCORS: true,
        allowTaint: true,
      }
      vm.$emit('to-render-pdf', true)
      const callback = async () => {
        var pdf = new jsPDF('p', 'pt', 'a4');
        const paginated = vm.paginate(this.canvas, pdf);
        paginated.save(`Carlos_Soriano_${Date.now()}.pdf`);
        vm.$emit('to-render-pdf', false)
      }
      vm.setCanvas(options, callback)
    },
    paginate (canvas, pdf) {
      const vm = this
      const imgData = vm.getDataURL(canvas)
      const imgWidth = 595
      const pageHeight = 842
      let imgHeight = canvas.height * imgWidth / canvas.width;
      let heightLeft = imgHeight
      pdf.addImage(imgData, 'PNG', 0, 0, imgWidth, imgHeight, null, 'SLOW')
      heightLeft -= pageHeight
      let secondHalf = heightLeft - imgHeight
      pdf.addPage()
      // TODO
      // add multiple page logic
      pdf.addImage(imgData, 'PNG', 0, secondHalf, imgWidth, imgHeight, null, 'SLOW')
      return pdf
    }
  },
  mounted () {
  }
}
</script>

<style lang="scss">

</style>