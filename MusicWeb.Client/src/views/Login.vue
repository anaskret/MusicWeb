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
        <v-card-title>Zaloguj się</v-card-title>
        <form @submit.prevent="onSubmit">
          <v-text-field
            class="p-4"
            label="Podaj login"
            prepend-icon="mdi-account"
            type="text"
            v-model.trim="$v.account.username.$model"
            :error-messages="userNameErrors"
            :counter="16"
            required
            @input="$v.account.username.$touch()"
            @blur="$v.account.username.$touch()"
          ></v-text-field>
          <v-text-field
            class="p-4"
            label="Podaj hasło"
            prepend-icon="mdi-lock"
            type="password"
            v-model.trim="$v.account.password.$model"
            :error-messages="passwordErrors"
            :counter="25"
            required
            @input="$v.account.password.$touch()"
            @blur="$v.account.password.$touch()"
          ></v-text-field>

          <div class="btns mt-8">
            <v-btn
              outlined
              color="gray"
              type="submit"
              class="md-4"
              :disabled="this.isDisabled"
              :loading="isLogging"
              width="40%"
            >
              Zaloguj się
            </v-btn>
            <div></div>
            <v-btn class="mt-4" @click="register" outlined width="40%">
              Zarejestruj
            </v-btn>
          </div>
        </form>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { required, minLength, maxLength } from "vuelidate/lib/validators";
import Account from "@/models/Account";
export default {
  name: "Login",
  data() {
    return {
      account: new Account(),
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
    userNameErrors() {
      return this.prepareErrorArray("username");
    },
    passwordErrors() {
      return this.prepareErrorArray("password");
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
    },
  },
  methods: {
    prepareErrorArray(field) {
      const errors = [];
      if (!this.$v.account[field].$dirty) return errors;
      !this.$v.account[field].required && errors.push("Pole jest wymagane.");
      if (
        this.$v.account[field].maxLength != undefined &&
        this.$v.account[field].minLength != undefined
      ) {
        !this.$v.account[field].maxLength &&
          errors.push(
            `Pole nie może być dłuższy niż ${this.$v.account[field].$params.maxLength.max} znaków.`
          );
        !this.$v.account[field].minLength &&
          errors.push(
            `Pole musi mieć przynajmniej ${this.$v.account[field].$params.minLength.min} znaków.`
          );
      }
      if (this.$v.account[field].email != undefined) {
        !this.$v.account[field].email &&
          errors.push(
            `Pole musi być uzupełnione według szablonu "example@ex.pl".`
          );
      }

      if (this.$v.account[field].maxValue != undefined) {
        !this.$v.account[field].maxValue &&
          errors.push(`Data urodzenia nie może być w przyszłości.`);
      }
      return errors;
    },
    validationStatus(validation) {
      return typeof validation != "undefined" ? validation.$error : false;
    },
    redirect() {
      this.$router
        .push({ name: "ArtistListPage"})
        .catch(() => {});
    },
    register() {
      this.$router.push({ name: "Register" });
    },
  },
  setup() {
    const onSubmit = function () {
      this.$v.$touch();
      if (this.$v.$pendding || this.$v.$error) {
        return;
      }
      this.$store.dispatch("auth/login", this.account).then(
        () => {
          this.isLogging = true;
          setTimeout(this.redirect, 500);
        },
        (error) => {
          if (
            error.response.status == 500 &&
            error.response.data == "Wrong username/password"
          ) {
            this.isLogging = false;
            this.message = "Niepoprawny login lub hasło!";
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

<style scoped>
.btns {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>
