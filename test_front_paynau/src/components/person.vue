<template>
    <div class="container">
        <div>
            <button class="btn btn-success" @click="newUser()"><i class="fa-solid fa-plus"></i> Agregar Usuario</button>
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Telefono</th>
                    <th>Email</th>
                    <th>Nacimiento</th>
                    <th>Estado</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-if="users.length == 0">
                    <td colspan="7">En estos momentos no tenemos datos para mostrar</td>
                </tr>
                <tr v-for="user in users" :key="user.id">
                    <td>{{ user.id }}</td>
                    <td>{{ user.fullname }}</td>
                    <td>{{ user.telephone }}</td>
                    <td>{{ user.email }}</td>
                    <td>{{ user.borndate }}</td>
                    <td>
                        <span v-if="user.enabled == true" class="badge rounded-pill bg-success">Habilitado</span>
                        <span v-else class="badge rounded-pill bg-danger">Deshabilitado</span>
                    </td>
                    <td>
                        <button class="btn btn-primary me-1" @click="editUser(user)"><i class="fa-solid fa-pen"></i> Editar</button>
                        <button class="btn btn-danger" @click="deleteUser(user.id)"><i class="fa-solid fa-xmark"></i> Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <Personform @closeModal="showModal = false" :showModal="showModal" :getUsers="getUsers" :hide="hide" :user="currentUser" />
    </div>
</template>
	
<script>
    import Swal from 'sweetalert2';
    import moment from 'moment';
    import Personform from './personform.vue';

    export default {
        name: 'Person-Index',
        data() {
            return {
                users: [],
                currentUser: {id: 0, fullname: '', telephone: '', email: '', borndate: '', enabled: false},
                showModal: false
            }
        },
        components: {
            Personform
        },
        mounted() {
            this.getUsers()
        },
        methods: {
            show() {
                this.showModal = true;
            },
            hide() {
                this.showModal = false;
            },
            newUser() {
                this.currentUser = {id: 0, fullname: '', telephone: '', email: '', borndate: '', enabled: false};
                this.show();
            },
            editUser(user) {
                this.currentUser = { ...user, borndate: moment(user.borndate, "DD/MM/YYYY").format("YYYY-MM-DD")};
                console.log(this.currentUser);                
                this.show();
            },
            deleteUser(id) {
                // Lógica para eliminar un usuario
                Swal.fire({
                    title: '¿Estás seguro?',
                    text: "Esta acción no se puede deshacer",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Sí, bórralo',
                    cancelButtonText: 'Cancelar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        this.$axios.delete(`/api/persons/${id}`)
                            .then(() => {
                                // Recargar la lista de usuarios
                                this.getUsers();
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
                });
            },
            getUsers() {
                this.$axios.get('/api/persons')
                    .then(response => {
                        this.users = response.data.map((user) => ({ ...user, borndate: moment(user.borndate).format('DD/MM/YYYY')}));
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
        }
    }
</script>