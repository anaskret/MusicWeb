<template>
  <v-app-bar
    v-if="!['Login', 'Register'].includes(this.$route.name)"
    app
    color="#2C2F33"
    shrink-on-scroll
    dense
    scroll-threshold="500"
    height="20%"
  >
    <div class="d-flex align-center">
      <v-img
        alt="MusicWeb"
        class="shrink"
        contain
        src="@/assets/logo-navbar.png"
        transition="scale-transition"
        width="150"
      />
    </div>
    <v-spacer></v-spacer>
    <template v-slot:extension>
      <v-tabs class="d-flex justify-center" v-model="active_tab">
        <v-tab v-for="tab of tabs" :key="tab.id" @click="tab.method">
          {{ tab.name }}
        </v-tab>
      </v-tabs>
    </template>
    <v-spacer></v-spacer>
    <SearchBar />
    <v-menu
      v-model="drawer"
      :close-on-content-click="false"
      :nudge-width="200"
      offset-y
    >
      <template v-slot:activator="{ on, attrs }">
        <v-btn
          class="mx-2"
          v-bind="attrs"
          v-on="on"
          small
          fab
          dark
          outlined
          @click.stop="drawer = !drawer"
        >
          <font-awesome-icon class="icon" icon="user" color="#white" />
        </v-btn>
      </template>

      <v-card color="#2C2F33">
        <v-list>
          <v-list-item>
            <v-list-item-avatar>
              <img src="@/assets/admin.jpg" alt="John" />
            </v-list-item-avatar>

            <v-list-item-content>
              <v-list-item-title
                >{{ account.firstname }}
                {{ account.lastname }}</v-list-item-title
              >
            </v-list-item-content>

            <v-list-item-action>
              <v-dialog v-model="settings_dialog" persistent max-width="600px">
                <template v-slot:activator="{ on, attrs }">
                  <v-btn v-bind="attrs" v-on="on" icon>
                    <font-awesome-icon
                      size="1x"
                      class="icon"
                      icon="cog"
                      color="#white"
                    />
                  </v-btn>
                </template>
                <v-tabs class="settingsDialog tabs" grow vertical>
                  <v-tab>
                    <font-awesome-icon
                      size="2x"
                      class="icon"
                      icon="lock"
                      color="#white"
                    />
                  </v-tab>
                  <v-tab>
                    <font-awesome-icon
                      size="2x"
                      class="icon"
                      icon="envelope"
                      color="#white"
                    />
                  </v-tab>
                  <v-tab>
                    <font-awesome-icon
                      size="2x"
                      class="icon"
                      icon="image"
                      color="#white"
                    />
                  </v-tab>

                  <v-tab-item>
                    <v-card flat class="settingsDialog">
                      <v-card-title>
                        <span class="text-h5">Zmień hasło</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12" md="12">
                              <v-text-field
                                class="p-4"
                                label="Stare Hasło"
                                v-model.trim="$v.oldPassword.$model"
                                :error-messages="oldPasswordErrors"
                                required
                                @input="$v.oldPassword.$touch()"
                                @blur="$v.oldPassword.$touch()"
                              ></v-text-field>
                              <v-text-field
                                class="p-4"
                                label="Nowe Hasło"
                                v-model.trim="$v.account.password.$model"
                                :error-messages="passwordErrors"
                                :counter="25"
                                required
                                @input="$v.account.password.$touch()"
                                @blur="$v.account.password.$touch()"
                              ></v-text-field>
                              <v-text-field
                                class="p-4"
                                label="Potwierdź hasło"
                                v-model.trim="$v.confirmPassword.$model"
                                :error-messages="confirmPasswordErrors"
                                :counter="25"
                                required
                                @input="$v.confirmPassword.$touch()"
                                @blur="$v.confirmPassword.$touch()"
                              ></v-text-field>
                            </v-col>
                          </v-row>
                        </v-container>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="settings_dialog = false"> Anuluj </v-btn>
                        <v-btn @click="updatePasswordDialog"> Zapisz </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-tab-item>
                  <v-tab-item>
                    <v-card flat class="settingsDialog">
                      <v-card-title>
                        <span class="text-h5">Zmień maila</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12" md="12">
                              <v-text-field
                                class="p-4"
                                label="Email"
                                v-model.trim="$v.account.email.$model"
                                :error-messages="emailErrors"
                                :counter="25"
                                required
                                @input="$v.account.email.$touch()"
                                @blur="$v.account.email.$touch()"
                              ></v-text-field>
                            </v-col>
                          </v-row>
                        </v-container>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="settings_dialog = false"> Anuluj </v-btn>
                        <v-btn @click="updateEmailDialog"> Zapisz </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-tab-item>
                  <v-tab-item>
                    <v-card flat class="settingsDialog">
                      <v-card-title>
                        <span class="text-h5">Zmień zdjęcie</span>
                      </v-card-title>
                      <v-card-text>
                        <!-- TODO Image Upload -->
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="settings_dialog = false"> Anuluj </v-btn>
                        <v-btn @click="settings_dialog = false"> Zapisz </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-tab-item>
                </v-tabs>
              </v-dialog>
            </v-list-item-action>
          </v-list-item>
        </v-list>

        <v-divider></v-divider>

        <v-card-actions>
          <v-btn @click="redirectToProfile" text>
            <span class="mr-2">Profil</span>
          </v-btn>
          <v-spacer></v-spacer>
          <v-btn @click="onLogout" text>
            <span class="mr-2">Wyloguj</span>
            <font-awesome-icon
              class="icon"
              icon="sign-out-alt"
              size="1x"
              color="#white"
            />
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-menu>
  </v-app-bar>
</template>

<script>
import useAccounts from "@/modules/accounts";
import SearchBar from "@/components/SearchBar";
import Account from "@/models/Account";
import {
  required,
  minLength,
  maxLength,
  email,
  sameAs,
} from "vuelidate/lib/validators";
export default {
  name: "Navbar",
  components: {
    SearchBar,
  },
  data() {
    return {
      user_id: localStorage.getItem("user-id"),
      drawer: null,
      group: null,
      settings_dialog: false,
      account: new Account(),
      oldPassword: "",
      confirmPassword: "",
      active_tab: 0,
      tabs: [
        { id: 0, name: "Activities", method: this.redirectToActivities },
        { id: 1, name: "Ranking", method: this.redirectToRankList },
        { id: 2, name: "Base", method: this.redirectToArtistList },
      ],
    };
  },
  computed: {
    isDisabled() {
      return this.$v.$invalid;
    },
    oldPasswordErrors() {
      return this.prepareErrorArray("oldPassword");
    },
    passwordErrors() {
      return this.prepareErrorArray("password");
    },
    confirmPasswordErrors() {
      return this.prepareErrorArray("confirmPassword");
    },
    emailErrors() {
      return this.prepareErrorArray("email");
    },
  },
  validations: {
    account: {
      password: {
        required,
        minLength: minLength(8),
        maxLength: maxLength(25),
      },
      email: {
        email,
        required,
        minLength: minLength(8),
        maxLength: maxLength(25),
      },
    },
    oldPassword: {
      required,
    },
    confirmPassword: {
      required,
      sameAsPassword: sameAs(function () {
        return this.account.password;
      }),
    },
  },
  methods: {
    redirectToProfile() {
      this.drawer = !this.drawer;
      this.$router.push({ name: "UserProfile" });
    },
    redirectToArtistList() {
      this.$router.push({ name: "ArtistListPage" });
    },
    redirectToActivities() {
      this.$router.push({ name: "Activities" });
    },
    redirectToRankList() {
      this.$router.push({ name: "RankListPage" });
    },
    prepareErrorArray(field) {
      const errors = [];
      if (field == "oldPassword") {
        if (!this.$v.oldPassword.$dirty) return errors;
        !this.$v.oldPassword.required && errors.push("Pole jest wymagane.");
      } else if (field == "confirmPassword") {
        if (!this.$v.confirmPassword.$dirty) return errors;
        !this.$v.confirmPassword.required && errors.push("Pole jest wymagane.");

        if (this.$v.confirmPassword.sameAsPassword != undefined) {
          !this.$v.confirmPassword.sameAsPassword &&
            errors.push(`Pole musi być takie same jak pole "Hasło".`);
        }
      } else {
        if (!this.$v.account[field].$dirty) return errors;
        !this.$v.account[field].required && errors.push("Pole jest wymagane.");
        if (
          this.$v.account[field].maxLength != undefined &&
          this.$v.account[field].minLength != undefined
        ) {
          !this.$v.account[field].maxLength &&
            errors.push(
              `Pole nie może być dłuższe niż ${this.$v.account[field].$params.maxLength.max} znaków.`
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
      }
      return errors;
    },
    updatePasswordDialog() {
      this.settings_dialog = false;
      this.updatePassword();
    },
    updateEmailDialog() {
      this.settings_dialog = false;
      this.updateEmail();
    },
    clearSettings() {
      this.account = new Account();
      this.oldPassword = "";
      this.confirmPassword = "";
    },
  },
  watch: {
    $route(to, from) {
      if (from.path === "/" && to.path === "/artists") {
        this.getAccount();
      }
      if (to.path === "/activities") {
        this.active_tab = 0;
      } else if (to.path === "/artists") {
        this.active_tab = 2;
      }
    },
  },
  created() {
    if (!["Login", "Register"].includes(this.$route.name)) {
      this.getAccount();
    }
  },
  setup() {
    const { getAccountById, updateAccountPassword, updateAccountEmail } =
      useAccounts();

    const onLogout = function () {
      this.$store.dispatch("auth/logout");
    };

    const getAccount = function () {
      getAccountById(this.user_id).then((response) => {
        this.account = response;
      });
    };

    const updatePassword = function () {
      this.account.id = this.user_id;
      this.account.oldPassword = this.oldPassword;
      this.account.newPassword = this.account.password;
      this.account.confirmPassword = this.confirmPassword;
      updateAccountPassword(this.account).then(
        (response) => {
          if (response.status == 200) {
            this.$emit(
              "show-alert",
              "Dane zostały zaktualizowane pomyślnie.",
              "success"
            );
            this.clearSettings();
          } else {
            this.$emit(
              "show-alert",
              `Nie udało się zaktualizować. Błąd ${response.status}`,
              "error"
            );
            this.clearSettings();
          }
        },
        (error) => {
          this.$emit(
            "show-alert",
            `Nie udało się zaktualizować. ${error.response.status} ${error.response.data}`,
            "error"
          );
          this.clearSettings();
        }
      );
    };

    const updateEmail = function () {
      this.account.id = this.user_id;
      updateAccountEmail(this.account).then(
        (response) => {
          if (response.status == 200) {
            this.$emit(
              "show-alert",
              "Dane zostały zaktualizowane pomyślnie.",
              "success"
            );
            this.clearSettings();
          } else {
            this.$emit(
              "show-alert",
              `Nie udało się zaktualizować. Błąd ${response.status}`,
              "error"
            );
            this.clearSettings();
          }
        },
        (error) => {
          this.$emit(
            "show-alert",
            `Nie udało się zaktualizować. ${error.response.status} ${error.response.data}`,
            "error"
          );
          this.clearSettings();
        }
      );
    };

    return {
      onLogout,
      getAccount,
      updatePassword,
      updateEmail,
    };
  },
};
</script>

<style scoped>
* >>> .v-toolbar__content {
  align-items: center !important;
}
.settingsDialog {
  background: #1e1e1e;
}
.tabs {
  min-height: 365px;
}
</style>
