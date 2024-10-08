<template>
    <div class="modal fade" id="userModal" aria-labelledby="userModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="userModalToggleLabel">Usuario</h5>
            <button type="button" class="btn-close" @click="modalInactive()"></button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="createUser">
              <div class="mb-3">
                <label class="col-form-label">Nombre:</label>
                <input type="text" class="form-control" id="name" v-model="userobj.fullname">
              </div>
              <div class="mb-3">
                <label class="col-form-label">Telefono:</label>
                <input type="text" class="form-control" id="telephone" v-model="userobj.telephone">
              </div>
              <div class="mb-3">
                <label class="col-form-label">Email:</label>
                <input type="email" class="form-control" id="email" v-model="userobj.email">
              </div>
              <div class="mb-3">
                <label class="col-form-label">Nacimiento:</label>
                <input type="date" class="form-control" id="email" v-model="userobj.borndate">
              </div>
              <div class="mb-3">
                <label class="col-form-label">Estado:</label>
                <select class="form-select" id="enabled" v-model="enabledValue">
                  <option value="true">Habilitado</option>
                  <option value="false">Deshabilitado</option>
                </select>
              </div>
              <button type="submit" class="btn btn-success">Enviar</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>

  import { Modal } from 'bootstrap';
  import Swal from 'sweetalert2';

  export default {
    props: [ 'showModal', 'hide', 'getUsers', 'user' ],
    name: 'Person-Form',
    data() {
      return {
        modalInstance: null,
      }
    },
    watch: {
      showModal(newValue) {
        if (newValue === true) {
          this.modalActive();
        }
      }
    },
    computed: {
      userobj() {
        return this.user
      },
      enabledValue: {
        get() { return this.userobj.enabled ? 'true' : 'false'},
        set(val) {this.userobj.enabled = (val == 'true')}
      },
    },
    methods: {
      createUser() {

        console.log(this.userobj);        

        if (this.userobj.fullname == '' || this.userobj.telefone == '' || this.userobj.email == '' || this.userobj.borndate == '') {
            Swal.fire({
              title: 'Error',
              text: 'Revisa los valores del formulario',
              icon: 'warning'
            });
            return;
        }

        if (this.userobj.id == 0) { // create
          this.$axios.post('/api/persons', this.userobj)
            .then(() => {
              // Recargar la lista de usuarios
              this.getUsers();
              this.modalInactive();
              // Mostrar mensaje de éxito
              Swal.fire({
                title: 'Informacion',
                text: 'Usuario creado exitosamente',
                icon: 'info'
              })
            })
            .catch(error => {
              console.error(error);
              Swal.fire({
                title: 'Error',
                text: 'Hemos tenido un error intente mas adelante',
                icon: 'warning'
              })
            });
        } else { // update
          this.$axios.put(`/api/persons/${this.userobj.id}`, this.userobj)
            .then(() => {
              // Recargar la lista de usuarios
              this.getUsers();
              this.modalInactive();
              // Mostrar mensaje de éxito
              Swal.fire({
                title: 'Informacion',
                text: 'Usuario actualizado exitosamente',
                icon: 'info'
              })
            })
            .catch(error => {
              console.error(error);
              Swal.fire({
                title: 'Error',
                text: 'Hemos tenido un error intente mas adelante',
                icon: 'warning'
              })
            });
        }
      },
      modalActive: function () { 
        this.modalInstance = new Modal(document.getElementById('userModal'), {backdrop: 'static'});
        this.modalInstance.show();
      },
      modalInactive: function () { 
        this.modalInstance.hide();
        this.hide();
      },
    }
  }
  </script>