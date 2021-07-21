<template>
  <div class="kanban">
    <h2>Chores</h2>
    <v-row class="mb-6">
      <v-col v-for="[column] in columns" :key="column" class="px-1">
        <v-subheader class="pa-0">{{ column }}</v-subheader>
        <v-sheet color="grey lighten-2" class="pa-1" height="80vh" rounded>

        </v-sheet>
      </v-col>
    </v-row>
  </div>
</template>

<script>
  export default {
    name: 'Kanban',

    components: {
    },

    data: () => ({
      drawer: null,
      columns: [
        ['Todo'],
        ['In Progress'],
        ['Done'],
      ],
    }),
  }
</script>
