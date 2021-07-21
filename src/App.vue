<template>
  <v-app>
    <v-navigation-drawer v-model="drawer" app>
      <v-sheet class="pa-4">
        <h2>House Chores</h2>
      </v-sheet>

      <v-divider></v-divider>

      <v-list>
        <v-list-item v-for="[icon, text, link] in links" :key="icon" link :href="[link]">
          <v-list-item-icon>
            <v-icon>{{ icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title>{{ text }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <v-container class="py-4 px-6" fluid>
        <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>
<script>
export default {
  name: 'App',

  data: () => ({
    drawer: null,
    links: [
      ['mdi-view-dashboard-variant', 'Chores', '/'],
      ['mdi-calendar-month', 'Calendar', '/calendar'],
      ['mdi-chart-areaspline-variant','Analytics', '/analytics'],
      ['mdi-cog', 'Settings', '/settings'],
    ],
  }),
};
</script>
