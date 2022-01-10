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
        class="shrink link-to-item"
        contain
        src="@/assets/logo-navbar.png"
        transition="scale-transition"
        width="150"
        @click="redirectToActivities"
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
              <img
                v-if="current_user.imagePath"
                :src="`${server_url}/${current_user.imagePath}`"
                :alt="`${current_user.firstname}`"
              />
              <img
                v-else
                src="@/assets/defaut_user.png"
                :alt="`${current_user.firstname}`"
              />
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
                        <span class="text-h5">Change Password</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12" md="12">
                              <v-text-field
                                class="p-4"
                                label="Old Password"
                                v-model.trim="$v.oldPassword.$model"
                                :error-messages="oldPasswordErrors"
                                required
                                @input="$v.oldPassword.$touch()"
                                @blur="$v.oldPassword.$touch()"
                                :type="show_old_password ? 'text' : 'password'"
                                :append-icon="show_old_password ? 'mdi-eye' : 'mdi-eye-off'"
                                @click:append="show_old_password = !show_old_password"
                              ></v-text-field>
                              <v-text-field
                                class="p-4"
                                label="New Password"
                                v-model.trim="$v.account.password.$model"
                                :error-messages="passwordErrors"
                                :counter="25"
                                required
                                @input="$v.account.password.$touch()"
                                @blur="$v.account.password.$touch()"
                                :type="show_new_password ? 'text' : 'password'"
                                :append-icon="show_new_password ? 'mdi-eye' : 'mdi-eye-off'"
                                @click:append="show_new_password = !show_new_password"
                              ></v-text-field>
                              <v-text-field
                                class="p-4"
                                label="Confirm Password"
                                v-model.trim="$v.confirmPassword.$model"
                                :error-messages="confirmPasswordErrors"
                                :counter="25"
                                required
                                @input="$v.confirmPassword.$touch()"
                                @blur="$v.confirmPassword.$touch()"
                                :type="show_confirm_password ? 'text' : 'password'"
                                :append-icon="show_confirm_password ? 'mdi-eye' : 'mdi-eye-off'"
                                @click:append="show_confirm_password = !show_confirm_password"
                              ></v-text-field>
                            </v-col>
                          </v-row>
                        </v-container>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="settings_dialog = false"> Close </v-btn>
                        <v-btn @click="updatePasswordDialog"> Send </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-tab-item>
                  <v-tab-item>
                    <v-card flat class="settingsDialog">
                      <v-card-title>
                        <span class="text-h5">Change Email</span>
                      </v-card-title>
                      <v-card-text>
                        <v-container>
                          <v-row>
                            <v-col cols="12" md="12">
                              <v-text-field
                                class="p-4"
                                label="Email"
                                v-model.trim="$v.email.$model"
                                :error-messages="emailErrors"
                                :counter="25"
                                required
                                @input="$v.email.$touch()"
                                @blur="$v.email.$touch()"
                              ></v-text-field>
                            </v-col>
                          </v-row>
                        </v-container>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="settings_dialog = false"> Close </v-btn>
                        <v-btn @click="updateEmailDialog"> Send </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-tab-item>
                  <v-tab-item>
                    <v-card flat class="settingsDialog">
                      <v-card-title>
                        <span class="text-h5">Change Photo</span>
                      </v-card-title>
                      <v-card-text>
                        <div class="uploader">
                          <v-file-input
                            label="File input"
                            prepend-icon="mdi-camera"
                            @change="fileChange"
                          ></v-file-input>
                        </div>
                      </v-card-text>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn @click="settings_dialog = false"> Close </v-btn>
                        <v-btn @click="updateImageDialog"> Send </v-btn>
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
import { mapGetters } from "vuex";
import {
  required,
  minLength,
  maxLength,
  email,
  sameAs,
} from "vuelidate/lib/validators";
import { mapMutations } from "vuex";
export default {
  name: "Navbar",
  components: {
    SearchBar,
  },
  data() {
    return {
      drawer: null,
      group: null,
      settings_dialog: false,
      oldPassword: "",
      confirmPassword: "",
      email: "",
      active_tab: 0,
      tabs: [
        { id: 0, name: "Activities", method: this.redirectToActivities },
        { id: 1, name: "Ranking", method: this.redirectToRankList },
        { id: 2, name: "Base", method: this.redirectToArtistList },
      ],
      files: new FormData(),
      file: {},
      account: {},
      show_old_password: false,
      show_new_password: false,
      show_confirm_password: false,
    };
  },
  computed: {
    ...mapGetters({
      current_user: "current_user",
      server_url: "server_url",
    }),
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
    },
    email: {
      email,
      required,
      minLength: minLength(8),
      maxLength: maxLength(25),
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
    ...mapMutations(["setCurrentUser"]),
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
      this.$router.push({ name: "RankingPage" });
    },
    prepareErrorArray(field) {
      const errors = [];
      if (field == "oldPassword") {
        if (!this.$v.oldPassword.$dirty) return errors;
        !this.$v.oldPassword.required && errors.push("Field required.");
      } else if (field == "confirmPassword") {
        if (!this.$v.confirmPassword.$dirty) return errors;
        !this.$v.confirmPassword.required && errors.push("Field required.");

        if (this.$v.confirmPassword.sameAsPassword != undefined) {
          !this.$v.confirmPassword.sameAsPassword &&
            errors.push(`Field must be same as "New Password"`);
        }
      } else if(field == "email"){
        if (this.$v.email.email != undefined) {
          !this.$v.email.email &&
            errors.push(
              `You must fill field like on example "example@ex.pl".`
            );
        }
      } else {
        if (!this.$v.account[field].$dirty) return errors;
        !this.$v.account[field].required && errors.push("Field required.");
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
    updateImageDialog() {
      this.settings_dialog = false;
      this.updateImage();
    },
    fileChange(file) {
      if (file != null && file != "") {
        this.getBase64(file).then((res) => {
          let start = res.search(",");
          this.file.imageBytes = res.substr(start + 1, res.length);
        });
      }
    },
    getBase64(file) {
      return new Promise(function (resolve, reject) {
        let reader = new FileReader();
        let imgResult = "";
        reader.readAsDataURL(file);
        reader.onload = function () {
          imgResult = reader.result;
        };
        reader.onerror = function (error) {
          reject(error);
        };
        reader.onloadend = function () {
          resolve(imgResult);
        };
      });
    },
    clearSettings() {
      this.account = this.current_user;
      this.account.password = "";
      this.oldPassword = "";
      this.confirmPassword = "";
      this.$v.$touch();
    },
  },
  watch: {
    $route(to, from) {
      if (from.path === "/" && to.path === "/activities") {
        this.setCurrentUser();
      }
      if (to.name === "Activities") {
        this.active_tab = 0;
      } else if (to.name === "RankListPage") {
        this.active_tab = 1;
      } else if (to.name == "ArtistListPage" || to.name === "ArtistPage") {
        this.active_tab = 2;
      }
    },
    current_user(){
      this.account = this.current_user;
    }
  },
  setup() {
    const { updateAccountPassword, updateAccountEmail, updateAccountImage } =
      useAccounts();

    const onLogout = function () {
      this.$store.dispatch("auth/logout");
    };

    const updatePassword = function () {
      this.account.id = this.current_user.id;
      this.account.oldPassword = this.oldPassword;
      this.account.newPassword = this.account.password;
      this.account.confirmPassword = this.confirmPassword;
      updateAccountPassword(this.account).then(
        (response) => {
          if (response.status == 200) {
            this.$emit("show-alert", "Data updated successfuly.", "success");
            this.clearSettings();
          } else {
            this.$emit(
              "show-alert",
              `Something went wrong. Error ${response.status}`,
              "error"
            );
            this.clearSettings();
          }
        },
        (error) => {
          this.$emit(
            "show-alert",
            `Something went wrong. ${error.response.status} ${error.response.data}`,
            "error"
          );
          this.clearSettings();
        }
      );
    };

    const updateEmail = function () {
      this.account.id = this.current_user.id;
      this.account.email = this.email;
      updateAccountEmail(this.account).then(
        (response) => {
          if (response.status == 200) {
            this.$emit("show-alert", "Data updated successfuly.", "success");
            this.clearSettings();
          } else {
            this.$emit(
              "show-alert",
              `Something went wrong. Error ${response.status}`,
              "error"
            );
            this.clearSettings();
          }
        },
        (error) => {
          this.$emit(
            "show-alert",
            `Something went wrong. ${error.response.status} ${error.response.data}`,
            "error"
          );
          this.clearSettings();
        }
      );
    };

    const updateImage = function () {
      this.file.userid = this.current_user.id;
      this.file.imagePath = "/Users/";
      updateAccountImage(this.file).then(
        (response) => {
          if (response.status == 200) {
            this.$emit("show-alert", "Data updated successfuly.", "success");
            this.clearSettings();
            this.$router.go();
          } else {
            this.$emit(
              "show-alert",
              `Something went wrong. Error ${response.status}`,
              "error"
            );
            this.clearSettings();
          }
        },
        (error) => {
          this.$emit(
            "show-alert",
            `Something went wrong. ${error.response.status} ${error.response.data}`,
            "error"
          );
          this.clearSettings();
        }
      );
    };

    return {
      onLogout,
      updatePassword,
      updateEmail,
      updateImage,
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
