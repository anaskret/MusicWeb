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
            label="Type Username"
            prepend-icon="mdi-account"
            type="text"
            v-model.trim="$v.account.username.$model"
            :error-messages="userNameErrors"
            :counter="16"
            required
            @input="$v.account.username.$touch()"
            @blur="$v.account.username.$touch()"
          ></v-text-field>

          <div class="btns mt-8">
            <v-btn
              outlined
              color="gray"
              type="submit"
              class="md-4"
              :loading="is_sending"
              width="40%"
            >
              Reset Password
            </v-btn>
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
import { required, minLength, maxLength } from "vuelidate/lib/validators";
import Account from "@/models/Account";
import useAccounts from "@/modules/accounts";
export default {
  name: "PasswordReset",
  data() {
    return {
      account: new Account(),
      is_sending: false,
      message: "",
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
  },
  validations: {
    account: {
      username: {
        required,
        minLength: minLength(5),
        maxLength: maxLength(16),
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
            `Field can't be longer than ${this.$v.account[field].$params.maxLength.max} characters.`
          );
        !this.$v.account[field].minLength &&
          errors.push(
            `Field must have at least ${this.$v.account[field].$params.minLength.min} characters.`
          );
      }
      return errors;
    },
    validationStatus(validation) {
      return typeof validation != "undefined" ? validation.$error : false;
    },
    redirect() {
      window.setTimeout(() => {
          this.$router.push({ name: "Login" }).catch(() => {});
      }, 500);
    },
    goBackToLoginPage() {
      this.$router.push({ name: "Login" });
    },
  },
  setup() {
    const { resetPassword } = useAccounts();

    const onSubmit = function () {
      this.$v.$touch();
      if (this.$v.$pendding || this.$v.$error) {
        return;
      }
      this.is_sending = true;
      resetPassword({userName: this.account.username}).then(
         (response) => {
            if (response.status == 200) {
               this.$emit(
               "show-alert",
               `New password has been sent to your Mailbox.`,
               "success"
               );
               this.redirect();
            } else {  
               this.is_sending = false;
               this.$emit(
               "show-alert",
               `Something went wrong. Error ${response.status}`,
               "error"
               );
            }
         },
         (error) => { 
            this.is_sending = false;
            this.$emit(
               "show-alert",
               `Something went wrong. ${error.response.status} ${error.response.data}`,
               "error"
            );
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
