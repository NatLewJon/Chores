<template>
    <Guest>
        <v-card
            class="d-flex align-center overflow-hidden"
            color="grey lighten-4"
            flat
            height="100vh"
        >
            <v-card
                class="mx-auto"
                flat
                color="grey lighten-4"
            >
                <h1 class="d-flex justify-center">Chores</h1>
                <v-card
                    class="px-4 py-4 mt-4"
                    width="25vw"
                    elevation="4"
                >
                    <h2 class="d-flex justify-center">Register</h2>
                    <form @submit.prevent="submit">
                        <v-text-field
                            label="Username"
                            :rules="rules"
                            prepend-icon="mdi-account-outline"
                            v-model="form.username"
                            hide-details="auto"
                        ></v-text-field>
                        <v-text-field
                            label="First Name"
                            :rules="rules"
                            prepend-icon="mdi-card-account-details-outline"
                            v-model="form.first_name"
                            hide-details="auto"
                        ></v-text-field>
                        <v-text-field
                            label="Last Name"
                            :rules="rules"
                            prepend-icon="mdi-card-account-details-outline"
                            v-model="form.last_name"
                            hide-details="auto"
                        ></v-text-field>
                        <v-text-field
                            label="Password"
                            :rules="rules"
                            type="password"
                            prepend-icon="mdi-lock-outline"
                            v-model="form.password"
                            hide-details="auto"
                        ></v-text-field>
                        <v-text-field
                            label="Confirm Password"
                            :rules="rules"
                            type="password"
                            prepend-icon="mdi-lock-outline"
                            v-model="form.confirm_password"
                            hide-details="auto"
                        ></v-text-field>
                        <v-btn
                            class="mt-2"
                            block
                            color="success"
                            type="submit"
                            dark
                        >
                            Register
                        </v-btn>
                        <router-link
                            class="d-flex justify-center pt-2"
                            to="/register"
                        >
                            Already have an account?
                        </router-link>
                    </form>
                </v-card>
            </v-card>
        </v-card>
    </Guest>
</template>

<script>
    import Guest from '../Layouts/Guest';
    import axios from 'axios';

    export default {
        name: 'Register.vue',

        components: {
            Guest,
        },

        data: () => ({
            rules: [
                value => !!value || 'Required.',
                value => (value && value.length >= 3) || 'Min 3 Characters',
            ],
            api_url: 'https://localhost:44372',
            form: {
                username: '',
                first_name: '',
                last_name: '',
                password: '',
                confirm_password: '',
            },
        }),

        methods: {
            submit() {
                if (this.form.confirm_password !== this.form.password) {
                    return;
                }

                axios({
                    method: 'post',
                    url: this.api_url + '/api/Authenticate/register',
                    data: this.form,
                })
                    .then(response => {
                        console.log(response);
                    })
                    .catch(error => {
                        console.log(error);
                    });
            },
        },
    };
</script>

<style scoped>
</style>