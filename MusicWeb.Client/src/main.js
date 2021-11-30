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
  faUser,
  faSearch,
  faCog,
  faCaretDown,
  faChevronCircleRight,
  faPen,
  faLock,
  faEnvelope,
  faImage,
  faThumbsUp,
  faComment,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import axios from "@/services/index.js";
import VueCompositionApi from "@vue/composition-api";
import moment from "moment";

const faIcons = [
  faHeart,
  faStar,
  faChevronDown,
  faChevronRight,
  faSignOutAlt,
  faUser,
  faSearch,
  faCog,
  faCaretDown,
  faChevronCircleRight,
  faPen,
  faLock,
  faEnvelope,
  faImage,
  faThumbsUp,
  faComment
];
faIcons.forEach((icon) => library.add(icon));

Vue.component("font-awesome-icon", FontAwesomeIcon);

Vue.config.productionTip = false;
axios.defaults.headers.common["Authorization"] = localStorage.getItem(
  "user-token"
)
  ? "Bearer " + localStorage.getItem("user-token")
  : "";
ApiService.init(store.state.serverUrl, `${store.state.serverUrl}/api`);
Vue.prototype.$http = axios;

Vue.use(Vuelidate);
Vue.use(VueCompositionApi);

moment.locale("pl");
Vue.prototype.moment = moment;

/** Vue Filters Start */
Vue.filter("truncate", function (text, length, suffix) {
  if (text.length > length) {
    return text.substring(0, length) + suffix;
  } else {
    return text;
  }
});
/** Vue Filters End */

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
