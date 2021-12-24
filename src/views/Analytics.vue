<template>
  <Authenticated>
    <template v-slot:header>
        Analytics
    </template>

    <Graph/>

  </Authenticated>
</template>

<script>
import Authenticated from "./Layouts/Authenticated";
import Graph from "../components/Graph.vue";

export default {
  name: 'analytics',

  components: {
    Graph,
    Authenticated
  },

  data: () => ({})
}
</script>

<style scoped>

</style>
