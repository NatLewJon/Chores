<template>
    <div>
        <v-navigation-drawer
            v-model="drawer"
            app
        >
            <v-sheet class="pa-4">
                <h2>House Chores</h2>
            </v-sheet>

            <v-divider></v-divider>

            <v-list>
                <v-list-item
                    v-for="[icon, text, link] in links"
                    :key="icon"
                    link
                    :href="[link]"
                >
                    <v-list-item-icon>
                        <v-icon>{{ icon }}</v-icon>
                    </v-list-item-icon>

                    <v-list-item-content>
                        <v-list-item-title>{{ text }}</v-list-item-title>
                    </v-list-item-content>
                </v-list-item>
            </v-list>

            <template v-slot:append>
                <div class="pa-2">
                    <v-btn
                        block
                        color="error"
                        dark
                        @click="logout"
                    >
                        <v-icon>
                            mdi-logout
                        </v-icon>
                        Logout
                    </v-btn>
                </div>
            </template>
        </v-navigation-drawer>

        <v-main>
            <v-container
                class="px-6 py-0"
                fluid
            >
                <slot
                    class="mx-4"
                    name="header"
                />

                <slot />
            </v-container>
        </v-main>
    </div>
</template>

<script>
    export default {
        name: 'Authenticated.vue',

        data: () => ({
            drawer: null,
            links: [
                ['mdi-view-dashboard-variant', 'Chores', '/'],
                ['mdi-calendar-month', 'Calendar', '/calendar'],
                ['mdi-chart-areaspline-variant', 'Analytics', '/analytics'],
                ['mdi-cog', 'Settings', '/settings'],
            ],
        }),
        //pointless comment on a pointless line
        methods: {
            logout() {
                localStorage.clear();
                this.$router.push('/login');
            },
        },
    };
</script>

<style scoped>
</style>