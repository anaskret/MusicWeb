import Vue from "vue";
import VueRouter from "vue-router";
import Login from "@/views/Login.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Login",
    component: Login,
  },
  {
    path: "/register",
    name: "Register",
    //lazy load
    component: () => import("@/views/Register.vue"),
  },
  {
    path: "/artist/:id",
    name: "ArtistPage",
    component: () => import("@/views/ArtistPage.vue"),
  },
  {
    path: "/profile",
    name: "UserProfile",
    component: () => import("@/views/UserProfile.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  const publicPages = ["/", "/register"];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem("user-token");

  if (authRequired && !loggedIn) {
    return next("/");
  }

  next();
});

export default router;
