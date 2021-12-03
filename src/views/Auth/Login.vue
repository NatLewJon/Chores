<template>
  <Guest>
    <v-card class="d-flex align-center overflow-hidden" color="grey lighten-4" flat height="100vh">
      <v-card class="mx-auto" flat color="grey lighten-4">
      <h1 class="d-flex justify-center">Chores</h1>
        <v-card class="px-4 py-4 mt-4" width="25vw" elevation="4" >
          <h2 class="d-flex justify-center">Log In</h2>
          <v-text-field
              label="Username"
              :rules="rules"
              hide-details="auto"
          ></v-text-field>
          <v-text-field
              label="Password"
              :rules="rules"
              type="password"
              hide-details="auto"
          ></v-text-field>
          <v-btn class="mt-2" block color="green" dark>
            <v-icon>
              mdi-login
            </v-icon>
            Log in
          </v-btn>
        </v-card>
      </v-card>
    </v-card>
  </Guest>
</template>

<script>
import Guest from "../Layouts/Guest";

export default {
  name: "Login",

  components: {
    Guest
  },

  data: () => ({
    rules: [
      value => !!value || 'Required.',
      value => (value && value.length >= 3) || 'Min 3 characters',
    ],
  }),
}
</script>