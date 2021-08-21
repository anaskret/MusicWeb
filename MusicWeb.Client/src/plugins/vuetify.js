import Vue from "vue";
import Vuetify from "vuetify/lib/framework";

Vue.use(Vuetify);

export default new Vuetify({
    theme: {
        dark: true,
        themes: {
            light: {
                primary: "#3a4b63",
            },
            dark: {
                primary: "#3a4b63",
            },
        },
    },
});
