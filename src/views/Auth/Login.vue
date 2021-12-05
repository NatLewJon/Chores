<template>
    <Guest>
        <v-card
            class="d-flex align-center overflow-hidden"
            flat
            height="100vh"
        >
            <v-card
                class="mx-auto"
                flat
            >
                <h1 class="d-flex justify-center">Chores</h1>
                <v-card
                    class="px-4 py-4 mt-4"
                    width="25vw"
                    elevation="4"
                >
                    <h2 class="d-flex justify-center">Log In</h2>
                    <form @submit.prevent="submit">
                        <v-text-field
                            label="Username"
                            v-model="form.username"
                            prepend-icon="mdi-account-outline"
                            hide-details="auto"
                            :error-messages="usernameErrors"
                            @input="$v.form.username.$touch()"
                            @blur="$v.form.username.$touch()"
                        ></v-text-field>
                        <v-text-field
                            label="Password"
                            prepend-icon="mdi-lock-outline"
                            type="password"
                            v-model="form.password"
                            hide-details="auto"
                            :error-messages="passwordErrors"
                            @input="$v.form.password.$touch()"
                            @blur="$v.form.password.$touch()"
                        ></v-text-field>
                        <v-btn
                            class="mt-2"
                            block
                            color="success"
                            type="submit"
                            dark
                        >
                            <v-icon>
                                mdi-login
                            </v-icon>
                            Log in
                        </v-btn>
                        <router-link
                            class="d-flex justify-center pt-2"
                            to="/register"
                        >
                            Dont have an account?
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
    import router from '../../router';
    import { required } from 'vuelidate/lib/validators';

    export default {
        name: 'Login',

        components: {
            Guest,
        },

        data: () => ({
            api_url: 'https://localhost:44372',
            form: {
                username: '',
                password: '',
            },
        }),
        validations: {
            form: {
                username: { required },
                password: { required },
            },
        },
        computed: {
            usernameErrors() {
                const errors = [];
                if (!this.$v.form.username.$dirty) return errors;
                !this.$v.form.username.required &&
                    errors.push('Username is required');
                return errors;
            },
            passwordErrors() {
                const errors = [];
                if (!this.$v.form.password.$dirty) return errors;
                !this.$v.form.password.required &&
                    errors.push('Password is required');
                return errors;
            },
        },
        methods: {
            submit() {
                axios({
                    method: 'post',
                    url: this.api_url + '/api/Authenticate/login',
                    data: this.form,
                })
                    .then(response => {
                        localStorage.setItem('token', response.data.token);
                        router.push('/');
                    })
                    .catch(error => {
                        console.log(error);
                    });
            },
        },
    };
</script>