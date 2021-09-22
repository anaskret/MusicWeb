<template>
    <v-container fluid>
        <v-row justify="center">
            <v-col class="mt-6" lg="4" sm="6">
                <div justify="center" align="center">
                    <v-img
                        lazy-src="@/assets/logo2-lazy.png"
                        src="@/assets/logo2.png"
                        max-width="50%"
                    ></v-img>
                </div>
                <v-card v-if="message" class="col-md-4">
                    <v-card-subtitle
                        ><h5 class="text-center">
                            {{ message }}
                        </h5></v-card-subtitle
                    >
                </v-card>
                <v-card-title class="mt-10">Zarejestruj się</v-card-title>
                <form @submit.prevent="onSubmit">
                    <v-text-field
                        class="p-4"
                        label="Podaj login"
                        prepend-icon="mdi-account"
                        type="text"
                        v-model.trim="$v.user.username.$model"
                        :error-messages="usernameErrors"
                        :counter="16"
                        required
                        @input="$v.user.username.$touch()"
                        @blur="$v.user.username.$touch()"
                    ></v-text-field>
                    <v-text-field
                        class="p-4"
                        label="Podaj hasło"
                        prepend-icon="mdi-lock"
                        type="password"
                        v-model.trim="$v.user.password.$model"
                        :error-messages="passwordErrors"
                        :counter="25"
                        required
                        @input="$v.user.password.$touch()"
                        @blur="$v.user.password.$touch()"
                    ></v-text-field>

                    <div class="btns mt-8">
                        <v-btn
                            outlined
                            color="gray"
                            type="submit"
                            class="px-5 mr-4"
                            :disabled="this.isDisabled"
                        >
                            Zarejestruj
                            <v-progress-circular
                                v-if="isLogging"
                                :size="20"
                                indeterminate
                                color="#3a4b63"
                                class="ml-2"
                            ></v-progress-circular>
                        </v-btn>
                        <v-btn @click="clear" class="mr-4" outlined>
                            Wyczyść
                        </v-btn>
                        <v-btn @click="redirect" class="mr-4" outlined>
                            Zaloguj
                        </v-btn>
                    </div>
                </form>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
import { required, minLength, maxLength } from "vuelidate/lib/validators";
import User from "@/models/User";
export default {
    name: "Register",
    data() {
        return {
            user: new User(),
            isLogging: false,
            message: "",
            errorThrowed: false,
            error: {},
        };
    },
    computed: {
        isDisabled() {
            return this.$v.$invalid;
        },
        usernameErrors() {
            const errors = [];
            if (!this.$v.user.username.$dirty) return errors;
            !this.$v.user.username.required &&
                errors.push("Pole jest wymagane.");
            !this.$v.user.username.maxLength &&
                errors.push(`Login nie może być dłuższy niż
                                ${this.$v.user.username.$params.maxLength.max}
                                liter.`);
            !this.$v.user.username.minLength &&
                errors.push(`Login musi mieć przynajmniej
                                ${this.$v.user.username.$params.minLength.min}
                                liter.`);
            return errors;
        },
        passwordErrors() {
            const errors = [];
            if (!this.$v.user.password.$dirty) return errors;
            !this.$v.user.password.required &&
                errors.push("Pole jest wymagane.");
            !this.$v.user.password.maxLength &&
                errors.push(`Hasło nie może być dłuższy niż
                                ${this.$v.user.password.$params.maxLength.max}
                                znaków.`);
            !this.$v.user.password.minLength &&
                errors.push(`Hasło musi mieć przynajmniej
                                ${this.$v.user.password.$params.minLength.min}
                                znaków.`);
            return errors;
        },
        loggedIn() {
            return this.$store.state.auth.status.loggedIn;
        },
    },
    created() {
        if (this.loggedIn) {
            this.redirect();
        }
    },
    validations: {
        user: {
            username: {
                required,
                minLength: minLength(5),
                maxLength: maxLength(16),
            },
            password: {
                required,
                minLength: minLength(8),
                maxLength: maxLength(25),
            },
        },
    },
    methods: {
        clear() {
            this.$v.$reset();
            this.user.username = "";
            this.user.password = "";
            this.message = "";
        },
        validationStatus(validation) {
            return typeof validation != "undefined" ? validation.$error : false;
        },
        redirect() {
            this.$router.push({ name: "Login" });
        },
    },
    setup() {
        const onSubmit = function () {
            this.$v.$touch();
            if (this.$v.$pendding || this.$v.$error) {
                return;
            }
            console.log(this.user);
            this.$store.dispatch("auth/register", this.user).then(
                () => {
                    this.isLogging = true;
                    setTimeout(this.redirect, 500);
                },
                (error) => {
                    if (
                        error.response.status == 500 &&
                        error.response.data ==
                            "User creation failed! Please check user details and try again."
                    ) {
                        this.isLogging = false;
                        this.message =
                            "Nie udało się utworzyć użytkownika! Sprawdź poprawność danych.";
                    }
                }
            );
        };

        return {
            onSubmit,
        };
    },
};
</script>
