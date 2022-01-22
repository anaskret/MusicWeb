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
    path: "/artists/:type?",
    name: "ArtistListPage",
    component: () => import("@/views/ArtistListPage.vue"),
  },
  {
    path: "/albums/:type?",
    name: "AlbumListPage",
    component: () => import("@/views/AlbumListPage.vue"),
  },
  {
    path: "/albumreviews",
    name: "AlbumReviewListPage",
    component: () => import("@/views/AlbumReviewListPage.vue"),
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
  {
    path: "/songs/:type?",
    name: "SongListPage",
    component: () => import("@/views/SongListPage.vue"),
  },
  {
    path: "/activities",
    name: "Activities",
    component: () => import("@/views/Activities.vue"),
  },
  {
    path: "/songreview/:id",
    name: "SongReviewPage",
    component: () => import("@/views/ReviewPage"),
  },
  {
    path: "/albumreview/:id",
    name: "AlbumReviewPage",
    component: () => import("@/views/ReviewPage"),
  },
  {
    path: "/songreviews",
    name: "SongReviewListPage",
    component: () => import("@/views/SongReviewListPage.vue"),
  },
  {
    path: "/ranking/artists",
    name: "ArtistRankingPage",
    component: () => import("@/views/ArtistRankingPage.vue"),
  },
  {
    path: "/ranking/albums",
    name: "AlbumRankingPage",
    component: () => import("@/views/AlbumRankingPage.vue"),
  },
  {
    path: "/ranking/songs",
    name: "SongRankingPage",
    component: () => import("@/views/SongRankingPage.vue"),
  },
  {
    path: "/passwordreset",
    name: "PasswordReset",
    component: () => import("@/views/PasswordReset.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  const publicPages = ["/", "/register", "/passwordreset"];
  const authRequired = !publicPages.includes(to.path);
  const loggedIn = localStorage.getItem("user-token");

  if (authRequired && !loggedIn) {
    return next("/");
  }

  next();
});

export default router;
