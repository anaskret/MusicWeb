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
    path: "/artist/:id",
    name: "ArtistPage",
    //lazy load
    component: () => import("@/views/ArtistPage.vue"),
  },
  {
    path: "/register",
    name: "Register",
    //lazy load
    component: () => import("@/views/Register.vue"),
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue"),
  },
  {
    path: "/album/:id",
    name: "AlbumPage",
    component: () => import("@/views/AlbumPage.vue"),
  },
  {
    path: "/song/:id",
    name: "SongPage",
    component: () => import("@/views/SongPage.vue"),
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
