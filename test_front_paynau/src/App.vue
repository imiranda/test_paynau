<template>  
  <PersonIndex />
</template>

<script>
import PersonIndex from './components/person.vue';

export default {
  name: 'App',
  components: {
    PersonIndex
  }
}
</script>

<style>
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    text-align: center;
    color: #2c3e50;
    margin-top: 60px;
  }
</style>
