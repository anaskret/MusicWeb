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
        <v-card-title>Log In</v-card-title>
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

          <div class="reset-password">
            <v-btn
              plain
              color="gray"
              class="md-4"
              width="40%"
              @click="redirectToPasswordReset"
            >
              Forgot Password?
            </v-btn>
          </div>
          <div class="btns mt-8">
            <v-btn
              outlined
              color="gray"
              type="submit"
              class="md-4"
              :disabled="this.isDisabled"
              :loading="is_logging"
              width="40%"
            >
              Log In
            </v-btn>
            <div></div>
            <v-btn class="mt-4" @click="register" outlined width="40%">
              Sign In
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
      is_logging: false,
      message: "",
      error: {},
      session_expired: "Session expired. Please login again.",
      connection_not_found: "Connection cannot be established.",
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
    if (this.$store.state.tokenExpired) {
      this.message = this.session_expired;
      this.$store.state.tokenExpired = false;
    } else if (this.$store.state.connectionError) {
      this.message = this.connection_not_found;
      this.$store.state.connectionError = false;
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
      !this.$v.account[field].required && errors.push("Field is required.");
      if (
        this.$v.account[field].maxLength != undefined &&
        this.$v.account[field].minLength != undefined
      ) {
        !this.$v.account[field].maxLength &&
          errors.push(
            `Field cannot be longer than ${this.$v.account[field].$params.maxLength.max} characters.`
          );
        !this.$v.account[field].minLength &&
          errors.push(
            `Field must contain at least ${this.$v.account[field].$params.minLength.min} characters.`
          );
      }
      if (this.$v.account[field].email != undefined) {
        !this.$v.account[field].email &&
          errors.push(
            `The field must be completed according to the template "example@ex.pl".`
          );
      }

      if (this.$v.account[field].maxValue != undefined) {
        !this.$v.account[field].maxValue &&
          errors.push(`Birth date cannot be in the future.`);
      }
      return errors;
    },
    validationStatus(validation) {
      return typeof validation != "undefined" ? validation.$error : false;
    },
    redirect() {
      this.$router.push({ name: "Activities" }).catch(() => {});
    },
    register() {
      this.$router.push({ name: "Register" });
    },
    redirectToPasswordReset() {
      this.$router.push({ name: "PasswordReset" });
    },
  },
  setup() {
    const onSubmit = function () {
      this.$v.$touch();
      if (this.$v.$pendding || this.$v.$error) {
        return;
      }
      this.is_logging = true;
      this.$store.dispatch("auth/login", this.account).then(
        () => {
          setTimeout(this.redirect, 250);
        },
        (error) => {
          if (
            error.response.status == 500 
          ) {
            this.is_logging = false;
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

<style scoped>
.btns {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.reset-password{
  display: flex;
  flex-direction: column;
  align-items: flex-end;
}
</style>
