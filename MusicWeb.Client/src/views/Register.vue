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
        <div v-if="message" class="py-6" justify="center">
          <h5 class="text-center">
            {{ message }}
          </h5>
        </div>
        <v-card-title class="mt-10">Zarejestruj się</v-card-title>
        <form @submit.prevent="onSubmit">
          <v-text-field
            class="p-4"
            label="Podaj login*"
            prepend-icon="mdi-account"
            type="text"
            v-model.trim="$v.account.username.$model"
            :error-messages="userNameErrors"
            :counter="16"
            required
            validate-on-blur
            @blur="$v.account.username.$touch()"
          ></v-text-field>
          <v-text-field
            class="p-4"
            label="Podaj hasło*"
            prepend-icon="mdi-lock"
            type="password"
            v-model.trim="$v.account.password.$model"
            :error-messages="passwordErrors"
            :counter="25"
            required
            @input="$v.account.password.$touch()"
            @blur="$v.account.password.$touch()"
          ></v-text-field>
          <v-text-field
            class="p-4"
            label="Podaj Imię*"
            prepend-icon="mdi-lock"
            type="text"
            v-model.trim="$v.account.firstname.$model"
            :error-messages="firstNameErrors"
            :counter="12"
            required
            @input="$v.account.firstname.$touch()"
            @blur="$v.account.firstname.$touch()"
          ></v-text-field>
          <v-text-field
            class="p-4"
            label="Podaj Nazwisko*"
            prepend-icon="mdi-lock"
            type="text"
            v-model.trim="$v.account.lastname.$model"
            :error-messages="lastNameErrors"
            :counter="20"
            required
            @input="$v.account.lastname.$touch()"
            @blur="$v.account.lastname.$touch()"
          ></v-text-field>
          <v-text-field
            class="p-4"
            label="Podaj Email*"
            prepend-icon="mdi-lock"
            type="text"
            v-model.trim="$v.account.email.$model"
            :error-messages="emailErrors"
            :counter="25"
            required
            @input="$v.account.email.$touch()"
            @blur="$v.account.email.$touch()"
          ></v-text-field>
          <v-menu
            v-model="isDatePicker"
            :close-on-content-click="false"
            :nudge-right="40"
            transition="scale-transition"
            offset-y
            min-width="auto"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-text-field
                class="p-4"
                label="Podaj Datę Urodzenia*"
                prepend-icon="mdi-calendar"
                v-model.trim="$v.account.birthdate.$model"
                :error-messages="birthDateErrors"
                readonly
                required
                @input="$v.account.birthdate.$touch()"
                @blur="$v.account.birthdate.$touch()"
                v-bind="attrs"
                v-on="on"
              ></v-text-field>
            </template>
            <v-date-picker
              v-model.trim="$v.account.birthdate.$model"
              @input="isDatePicker = false"
            ></v-date-picker>
          </v-menu>
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
            <v-btn @click="clear" class="mr-4" outlined> Wyczyść </v-btn>
            <v-btn @click="redirect" class="mr-4" outlined> Zaloguj </v-btn>
          </div>
        </form>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { required, minLength, maxLength, email } from "vuelidate/lib/validators";
import Account from "@/models/Account";
export default {
  name: "Register",
  data() {
    return {
      account: new Account(),
      isLogging: false,
      message: "",
      errorThrowed: false,
      isDatePicker: false,
      error: {},
    };
  },
  computed: {
    isDisabled() {
      return this.$v.$invalid;
    },
    userNameErrors() {
      return this.prepareErrorArray("username");
    },
    passwordErrors() {
      return this.prepareErrorArray("password");
    },
    firstNameErrors() {
      return this.prepareErrorArray("firstname");
    },
    lastNameErrors() {
      return this.prepareErrorArray("lastname");
    },
    emailErrors() {
      return this.prepareErrorArray("email");
    },
    birthDateErrors() {
      return this.prepareErrorArray("birthdate");
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
    account: {
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
      firstname: {
        required,
        minLength: minLength(3),
        maxLength: maxLength(12),
      },
      lastname: {
        required,
        minLength: minLength(3),
        maxLength: maxLength(20),
      },
      email: {
        email,
        required,
        minLength: minLength(8),
        maxLength: maxLength(25),
      },
      birthdate: {
        required,
        maxValue: (value) => value < new Date().toISOString(),
      },
    },
  },
  methods: {
    clear() {
      this.$v.$reset();
      this.account = new Account();
      this.message = "";
    },
    redirect() {
      this.$router.push({ name: "Login" });
    },
    prepareErrorArray(field) {
      const errors = [];
      if (!this.$v.account[field].$dirty) return errors;
        !this.$v.account[field].required && errors.push("Pole jest wymagane.");
      if(this.$v.account[field].maxLength != undefined && this.$v.account[field].minLength != undefined){
          !this.$v.account[field].maxLength &&
        errors.push(
            `Pole nie może być dłuższy niż ${this.$v.account[field].$params.maxLength.max} znaków.`
        );
      !this.$v.account[field].minLength &&
        errors.push(
            `Pole musi mieć przynajmniej ${this.$v.account[field].$params.minLength.min} znaków.`
        );
     }
        if(this.$v.account[field].email != undefined){
            !this.$v.account[field].email &&
                errors.push(
                    `Pole musi być uzupełnione według szablonu "example@ex.pl".`
                );
        }

        if(this.$v.account[field].maxValue != undefined){
            !this.$v.account[field].maxValue &&
                errors.push(
                    `Data urodzenia nie może być w przyszłości.`
                );
        }
      return errors;
    },
  },
  setup() {
    const onSubmit = function () {
      this.$v.$touch();
      if (this.$v.$pendding || this.$v.$error) {
        return;
      }
      console.log(this.account);
      this.$store.dispatch("auth/register", this.account).then(
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

          else if (error.response.status == 400){
              this.message = error.response.data;
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
