<template>
  <div>
    <v-dialog
        v-model="dialog"
        width="500"
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn
            class="mx-2"
            dark
            color="success"
            v-bind="attrs"
            v-on="on"
        >
          <v-icon dark>
            mdi-plus
          </v-icon>
          New Board
        </v-btn>
      </template>

      <v-card>
        <v-card-title class="text-h5 grey lighten-2">
          Add Board
        </v-card-title>

        <form @submit.prevent="submit">
          <v-container>
              <v-text-field label="Title" v-model="kanban_title" required></v-text-field>
              <v-text-field
                  label="Column Name"
                  append-outer-icon="mdi-plus"
                  v-model="column_name"
                  @click:append-outer="addColumn"
              ></v-text-field>

              <v-divider v-if="columns.length > 0"></v-divider>
              <v-list max-height="200" class="overflow-y-auto py-0">
                <v-list-item-group multiple>
                  <template>
                    <v-list-item v-for="column in this.columns" :key="column.position">
                      <template dense>
                        <v-list-item-content>
                          <v-list-item-title>{{ column.name }}</v-list-item-title>
                        </v-list-item-content>

                        <v-list-item-action class="my-1" @click="removeColumn(column.position)">
                          <v-btn fab elevation="0" small color="white">
                            <v-icon color="red">
                              mdi-trash-can
                            </v-icon>
                          </v-btn>
                        </v-list-item-action>
                      </template>
                    </v-list-item>
                  </template>
                </v-list-item-group>
              </v-list>

          </v-container>

          <v-divider></v-divider>

          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
                color="success"
                text
                @click="createBoard"
            >
              Create
            </v-btn>
          </v-card-actions>
        </form>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: "AddBoard.vue",

        data() {
            return {
                api_url: 'https://localhost:44372',
                dialog: false,
                iconIndex: 0,
                kanban_title: "",
                column_name: "",
                columns: []
            }
        },

        methods: {
            submit() {
                console.log(this.form);
                this.dialog = false;
            },
            addColumn() {
                if (this.column_name === "") {
                    return;
                }

                var name_column = {
                      "name": this.column_name,
                      "position": this.columns.length + 1
                }
                this.columns.push(name_column);
                this.column_name = "";
            },
            removeColumn(position) {
                this.columns.forEach((column, index) => {
                    if (column.position === position) {
                        this.columns.splice(index, 1);
                    }
                })

                this.columns.forEach((column) => {
                    if (column.position > position) {
                        column.position = column.position - 1;
                    }
                })
            },
            createBoard() {
                if (this.kanban_title === "" || this.columns.length === 0) {
                    return;
                }

                axios.post(this.api_url+'/api/Kanbans', {
                    "title": this.kanban_title,
                    "columns": this.columns
                }).then(response => {
                    console.log(response);
                }).catch(error => {
                    console.log(error);
                });
            }
        },
    }
</script>

<style scoped>

</style>