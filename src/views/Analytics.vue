<template>
  <Authenticated>
    <template v-slot:header>
      <v-row class="mb-0 mt-1">
        <h2>Calendar</h2>
      </v-row>
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
