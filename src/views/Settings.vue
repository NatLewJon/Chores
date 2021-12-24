<template>
  <Authenticated>
    <template v-slot:header>
      Settings
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