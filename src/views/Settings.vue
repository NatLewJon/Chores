<template>
  <Authenticated>
    <template v-slot:header>
      <v-row class="mb-0 mt-1">
        <h2>Calendar</h2>
      </v-row>
    </template>

  </Authenticated>
</template>

<script>
import Authenticated from "./Layouts/Authenticated";

export default {
  name: 'Settings',

  components: {
    Authenticated
  },

}
</script>