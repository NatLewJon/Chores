<template>
  <div >
    <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn
            class="mx-2"
            fab
            dark
            small
            color="grey"
            v-bind="attrs"
            v-on="on"
        >
            <v-icon dark>
                mdi-plus
            </v-icon>
        </v-btn>
      </template>

      <v-card>
        <v-card-title class="text-h5 grey lighten-2">
          Add Chore
        </v-card-title>

        <v-container>
        <v-text-field label="Title"></v-text-field>

        <v-text-field label="Description"></v-text-field>
        </v-container>
        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            text
            @click="dialog = false"
          >
            Add
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>


<script>
  export default {
    data () {
      return {
        dialog: false,
      }
    },
  }
</script>