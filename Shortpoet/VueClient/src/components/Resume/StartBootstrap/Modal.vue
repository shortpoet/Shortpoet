<script>
//https://alligator.io/vuejs/vue-modal-component/

  export default {
    name: 'Modal',
    methods: {
      close() {
        this.$emit('close');
      },
      toPDF() {
        this.$emit('toPDF');
      },
      toCanvas() {
        this.$emit('toCanvas');
      }
    },
  };
</script>
<template>
  <transition name="modal-fade">
    <div class="custom-modal-backdrop">
      <div class="custom-modal"
        role="dialog"
        aria-labelledby="modalTitle"
        aria-describedby="modalDescription"
      >
        <header
          class="custom-modal-header"
          id="modalTitle"
        >
          <slot name="header">
            <h4 class="mr-auto">Save to PDF</h4>
            <button
              type="button"
              class="btn-ex"
              @click="close"
              aria-label="Close modal"
            >
              <font-awesome-icon icon="times" />
            </button>
          </slot>
        </header>
        <section
          class="custom-modal-body"
          id="modalDescription"
        >
          <slot name="body">
            <p>
              This does not <em>download</em> a file in the traditional sense where it is retrieved from a data server. 
              It is generated fresh by your browser based on a <b>snapshot</b> of this page as you see it. 
              As such, if not used from a full-sized screen, the rendering will not be in A4 page size format.
            </p>          
          </slot>
        </section>
        <footer class="custom-modal-footer">
          <slot name="footer">
            <div class="button-drawer d-flex flex-row justify-content-around">
              <div>
                <button
                  type="button"
                  class="btn-save"
                  @click="toPDF"
                  aria-label="Close modal"
                >
                  Save me!
                </button>
              </div>
              <div>
                <button
                  type="button"
                  class="btn-save"
                  @click="toCanvas"
                  aria-label="Close modal"
                >
                  Canvas me!
                </button>
              </div>
              <div>
                <button
                  type="button"
                  class="btn-close"
                  @click="close"
                  aria-label="Close modal"
                >
                  Close me!
                </button>
              </div>
            </div>
          </slot>
        </footer>
      </div>
    </div>
  </transition>
</template>
<style lang="scss">
$forest-green:   #0B6623 !default;
$royal-purple:  #562088 !default;
$orange:  #BD5D38 !default;
$primary: $royal-purple !default;

.custom-modal-backdrop {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: rgba(0, 0, 0, 0.3);
  display: flex;
  justify-content: center;
  align-items: center;
  z-index: 1000;
}

.custom-modal {
  background: #FFFFFF;
  box-shadow: 2px 2px 20px 1px;
  /* overflow-x: auto; */
  display: flex;
  flex-direction: column;
  max-width: 15rem;
}

.custom-modal-header {
  margin: 1.5rem 1.5rem 0rem 1.5rem;
  display: flex;
    border-bottom: 1px solid #eeeeee;
  /* justify-content: space-between; */
}

.custom-modal-body {
  /* position: relative; */
  margin: 1.5rem 1.5rem 1.5rem 1.5rem;
}

.custom-modal-footer {
  margin: 0rem 1.5rem 1.5rem 1.5rem;
  padding: 1.5rem 0rem 0rem 0rem;
  border-top: 1px solid #eeeeee;
  /* display: flex; */
  /* justify-content: flex-end; */
}


.button-drawer {
  display: flex;
  /* justify-content: space-around; */
}

.btn-ex {
  border: none;
  font-size: 1rem;
  padding: 0rem 0rem 0rem 0rem;
  margin: 0rem 0rem .5rem 0rem;
  cursor: pointer;
  font-weight: bold;
  color: #4AAE9B;
  background: transparent;
}

.btn-save {
  color: white;
  background: $forest-green;
  border: 1px solid $forest-green;
  border-radius: 2px;
}
.btn-close {
  color: white;
  background: $primary;
  border: 1px solid $primary;
  border-radius: 2px;
}

</style>
