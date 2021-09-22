<template>
    <v-app>
        <v-app-bar app color="primary" dark>
            <div class="d-flex align-center">
                <v-img
                    alt="Vuetify Logo"
                    class="shrink mr-2"
                    contain
                    src="https://cdn.vuetifyjs.com/images/logos/vuetify-logo-dark.png"
                    transition="scale-transition"
                    width="40"
                />

                <v-img
                    alt="Vuetify Name"
                    class="shrink mt-1 hidden-sm-and-down"
                    contain
                    min-width="100"
                    src="https://cdn.vuetifyjs.com/images/logos/vuetify-name-dark.png"
                    width="100"
                />
            </div>

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
        </v-app-bar>

        <v-main>
            <router-view />
        </v-main>
    </v-app>
</template>

<script>
export default {
    name: "App",
    data() {
        return {};
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
