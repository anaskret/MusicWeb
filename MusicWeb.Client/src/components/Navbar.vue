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
      <v-tabs class="d-flex justify-center">
        <v-tab color="#white" @click="redirectToArtistList">
          Baza
          <font-awesome-icon class="icon" icon="caret-down" color="#white"
        /></v-tab>
        <v-tab>
          Ranking
          <font-awesome-icon class="icon" icon="caret-down" color="#white"
        /></v-tab>
        <v-tab>Aktywność</v-tab>
      </v-tabs>
    </template>
    <v-spacer></v-spacer>
    <v-btn class="mx-2" small fab dark outlined>
      <font-awesome-icon class="icon" icon="search" color="#white" />
      <!-- TODO Animated searchbar -->
    </v-btn>
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
              <v-btn :class="fav ? 'red--text' : ''" icon @click="fav = !fav">
                <font-awesome-icon
                  size="1x"
                  class="icon"
                  icon="cog"
                  color="#white"
                />
              </v-btn>
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
export default {
  name: "Navbar",
  data() {
    return {
      drawer: null,
      group: null,
      fav: false,
      account: {},
    };
  },
  methods: {
    redirectToProfile() {
      this.drawer = !this.drawer;
      this.$router.push({ name: "UserProfile" });
    },
    redirectToArtistList() {
      this.$router.push({ name: "ArtistListPage" });
    },
  },
  watch: {
    $route(to, from) {
      if (from.path === "/" && to.path === "/artists") {
        this.getAccount();
      }
    },
  },
  created() {
    if (!["Login", "Register"].includes(this.$route.name)) {
      this.getAccount();
    }
  },
  setup() {
    const { getById } = useAccounts();

    const onLogout = function () {
      this.$store.dispatch("auth/logout");
    };

    const getAccount = function () {
      getById(localStorage.getItem("user-id")).then((response) => {
        this.account = response;
      });
    };

    return {
      onLogout,
      getAccount,
    };
  },
};
</script>

<style scoped>
* >>> .v-toolbar__content {
  align-items: center !important;
}
</style>
