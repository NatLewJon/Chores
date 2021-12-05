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
                    <h2 class="d-flex justify-center">Register</h2>
                    <form @submit.prevent="submit">
                        <v-text-field
                            label="Username"
                            prepend-icon="mdi-account-outline"
                            v-model="form.username"
                            hide-details="auto"
                            :error-messages="username_errors"
                            @input="$v.form.username.$touch()"
                            @blur="$v.form.username.$touch()"
                        ></v-text-field>
                        <v-text-field
                            label="First Name"
                            prepend-icon="mdi-card-account-details-outline"
                            v-model="form.first_name"
                            hide-details="auto"
                            :error-messages="first_name_errors"
                            @input="$v.form.first_name.$touch()"
                            @blur="$v.form.first_name.$touch()"
                        ></v-text-field>
                        <v-text-field
                            label="Last Name"
                            prepend-icon="mdi-card-account-details-outline"
                            v-model="form.last_name"
                            hide-details="auto"
                            :error-messages="last_name_errors"
                            @input="$v.form.last_name.$touch()"
                            @blur="$v.form.last_name.$touch()"
                        ></v-text-field>
                        <v-text-field
                            label="Password"
                            type="password"
                            prepend-icon="mdi-lock-outline"
                            v-model="form.password"
                            hide-details="auto"
                            :error-messages="password_errors"
                            @input="$v.form.password.$touch()"
                            @blur="$v.form.password.$touch()"
                        ></v-text-field>
                        <v-text-field
                            label="Confirm Password"
                            type="password"
                            prepend-icon="mdi-lock-outline"
                            v-model="form.confirm_password"
                            hide-details="auto"
                            :error-messages="confirm_password_errors"
                            @input="$v.form.confirm_password.$touch()"
                            @blur="$v.form.confirm_password.$touch()"
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
                            to="/login"
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
    import { required, minLength, sameAs } from 'vuelidate/lib/validators';

    export default {
        name: 'Register.vue',

        components: {
            Guest,
        },

        data: () => ({
            api_url: 'https://localhost:44372',
            form: {
                username: '',
                first_name: '',
                last_name: '',
                password: '',
                confirm_password: '',
            },
        }),
        validations: {
            form: {
                username: {
                    required,
                    minLength: minLength(4),
                    //Custom validation checking the new username doesn't match any existing ones
                    isUnique(username) {
                        for (let index in this.Users) {
                            if (username === this.Users[index].username) {
                                return false;
                            }
                        }
                        return true;
                    },
                },
                first_name: { required },
                last_name: { required },
                password: { required, minLength: minLength(6) },
                confirm_password: {
                    required,
                    sameAsPassword: sameAs('password'),
                    minLength: minLength(6),
                },
            },
        },
        computed: {
            //Errors to show for each of the validations
            username_errors() {
                const errors = [];
                if (!this.$v.form.username.$dirty) return errors;
                !this.$v.form.username.isUnique &&
                    errors.push('Username must be unique');
                !this.$v.form.username.minLength &&
                    errors.push('Username must be at least 4 characters');
                !this.$v.form.username.required &&
                    errors.push('Username is required');
                return errors;
            },
            first_name_errors() {
                const errors = [];
                if (!this.$v.form.first_name.$dirty) return errors;
                !this.$v.form.first_name.required &&
                    errors.push('First name is required');
                return errors;
            },
            last_name_errors() {
                const errors = [];
                if (!this.$v.form.last_name.$dirty) return errors;
                !this.$v.form.last_name.required &&
                    errors.push('Last name is required');
                return errors;
            },
            password_errors() {
                const errors = [];
                if (!this.$v.form.password.$dirty) return errors;
                !this.$v.form.password.minLength &&
                    errors.push('Password must be at least 6 characters');
                !this.$v.form.password.required &&
                    errors.push('Password is required');
                return errors;
            },
            confirm_password_errors() {
                const errors = [];
                if (!this.$v.form.confirm_password.$dirty) return errors;
                !this.$v.form.confirm_password.minLength &&
                    errors.push('Password must be at least 6 characters');
                !this.$v.form.confirm_password.sameAsPassword &&
                    errors.push('Passwords must match');
                !this.$v.form.confirm_password.required &&
                    errors.push('Confirm password is required');
                return errors;
            },
        },
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
                        this.$router.push('/');
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