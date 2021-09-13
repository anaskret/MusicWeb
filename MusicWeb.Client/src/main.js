import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import ApiService from "./services/apiServices";
import Vuelidate from "vuelidate";
import { library } from "@fortawesome/fontawesome-svg-core";
import {
    faHeart,
    faStar,
    faChevronDown,
    faChevronRight,
    faSignOutAlt,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import axios from "axios";
import VueCompositionApi from "@vue/composition-api";

library.add(faHeart);
library.add(faStar);
library.add(faChevronDown);
library.add(faChevronRight);
library.add(faSignOutAlt);

Vue.component("font-awesome-icon", FontAwesomeIcon);

Vue.config.productionTip = false;

const url = "http://localhost:5000";
ApiService.init(url, `${url}/api`);
Vue.prototype.$http = axios;

Vue.use(Vuelidate);
Vue.use(VueCompositionApi);

new Vue({
    router,
    store,
    vuetify,
    render: (h) => h(App),
}).$mount("#app");
