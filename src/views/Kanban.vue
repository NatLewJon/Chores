<template>
  <div class="kanban">
    <h2>Chores</h2>
    <v-row class="mb-6">
      <v-col v-for="column in columns" :key="column.columnId" class="px-1">
        <v-subheader class="pa-0">{{ column.columnName }}</v-subheader>
        <v-sheet color="grey lighten-2" class="pa-1" height="80vh" 
          @drop="onDrop($event,column.columnId)"
          @dragover.prevent
          @dragenter.prevent  rounded
        >
          
          <v-sheet 
          color="grey"
          class="mb-6"
          v-for="item in listGet(column.columnId)" 
          :key="item.title" 
          draggable
          @dragstart="startDrag($event, item)"
          >
            {{item.title}}

          </v-sheet>

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

    methods:{
      listGet(id){
          return this.items.filter(item => item.list === id)
      },
      startDrag(evt, item){
        evt.dataTransfer.dropEffect = 'move'
        evt.dataTransfer.effectAllowed = 'move'
        evt.dataTransfer.setData('itemID', item.id)
      },
      onDrop(evt, list){
        const itemID = evt.dataTransfer.getData('itemID')
        const item = this.items.find(item => item.id == itemID)
        item.list = list
      }
    },

    data: () => ({
      drawer: null,
      columns: [
        {
          columnName:"Todo",
          columnId:1
        },
        {
          columnName:"In Progress",
          columnId:2
        },
        {
          columnName:"Done",
          columnId:3,
        },
      ],
      items: [
        {
          id:0,
          title: "Item 1",
          list: 1
        },
        {
          id:1,
          title:"Item 2",
          list:2
        },
        {
          id:2,
          title:"Item 2",
          list:2
        }
      ]
      
    }),
  }
</script>
