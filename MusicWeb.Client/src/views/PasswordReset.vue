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
        <v-card-title>Reset Password</v-card-title>
        <form @submit.prevent="onSubmit">
          <v-text-field
            class="p-4"
            label="Type E-mail"
            prepend-icon="mdi-account"
            type="text"
            v-model.trim="$v.account.email.$model"
            :error-messages="emailErrors"
            :counter="16"
            required
            @input="$v.account.email.$touch()"
            @blur="$v.account.email.$touch()"
          ></v-text-field>

          <div class="btns mt-8">
            <v-btn class="mt-4" @click="goBackToLoginPage" outlined width="40%">
              Log In
            </v-btn>
          </div>
        </form>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { required, email } from "vuelidate/lib/validators";
import Account from "@/models/Account";
export default {
  name: "PasswordReset",
  data() {
    return {
      account: new Account(),
      is_logging: false,
      message: "",
      error: {},
    };
  },
  computed: {
    isDisabled() {
      return this.$v.$invalid;
    },
    emailErrors() {
      return this.prepareErrorArray("email");
    },
  },
  validations: {
    account: {
      email: {
        required,
        email
      },
    },
  },
  methods: {
    prepareErrorArray(field) {
      const errors = [];
      if (!this.$v.account[field].$dirty) return errors;
      !this.$v.account[field].required && errors.push("Field is required.");
      if (this.$v.account[field].email != undefined) {
        !this.$v.account[field].email &&
          errors.push(
            `The field must be completed according to the template "example@ex.pl".`
          );
      }
      return errors;
    },
    validationStatus(validation) {
      return typeof validation != "undefined" ? validation.$error : false;
    },
    redirect() {
      this.message = "New password has been sent to your Mailbox.";
      window.setTimeout(() => {
          this.$router.push({ name: "Login" }).catch(() => {});
      }, 1000);
    },
    goBackToLoginPage() {
      this.$router.push({ name: "Login" });
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
            error.response.status == 500 &&
            error.response.data == "Wrong username/password"
          ) {
            this.is_logging = false;
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
