<template>
  <Authenticated>
    <template v-slot:header>
      Calendar
    </template>



  </Authenticated>
</template>

<script>
import Authenticated from "./Layouts/Authenticated";

export default {
  name: "Calendar",

  components: {
    Authenticated
  }
}
</script>

<style scoped>

</style>
