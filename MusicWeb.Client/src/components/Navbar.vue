<template>
  <v-app-bar
    v-if="this.$route.name != 'Login'"
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
        <v-tab color="#white">
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
              <img src="https://cdn.vuetifyjs.com/images/john.jpg" alt="John" />
            </v-list-item-avatar>

            <v-list-item-content>
              <v-list-item-title>John Leider</v-list-item-title>
              <v-list-item-subtitle>Founder of Vuetify</v-list-item-subtitle>
            </v-list-item-content>

            <v-list-item-action>
              <v-btn :class="fav ? 'red--text' : ''" icon @click="fav = !fav">
                <v-icon>mdi-heart</v-icon>
              </v-btn>
            </v-list-item-action>
          </v-list-item>
        </v-list>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>

          <v-btn
            v-if="this.$store.state.auth.status.loggedIn"
            @click="onLogout"
            text
          >
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
export default {
  name: "Navbar",
  data() {
    return {
      drawer: null,
      group: null,
      fav: false,
    };
  },
  setup() {
    const onLogout = function () {
      this.$store.dispatch("auth/logout");
    };

    return {
      onLogout,
    };
  },
};
</script>
