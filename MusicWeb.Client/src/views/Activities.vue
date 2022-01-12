<template>
  <InfiniteScrollList
    :items="posts"
    :scroll_settings="scroll_settings"
    :getPagedItemList="getPagedPostList"
    :filterList="filterList"
    :intersection_active="intersection_active"
    @set-filters="setFilters"
    :redirect_module_name="redirect_module_name"
    :module_name="module_name"
    v-on="$listeners"
    @like-post="likeUserPost"
  />
</template>

<script>
import useAccounts from "@/modules/accounts";
import InfiniteScrollList from "@/components/InfiniteScrollList";
import { mapGetters, mapMutations } from "vuex";
import moment from "moment";
import usePosts from "@/modules/posts";
export default {
  name: "Activities",
  components: {
    InfiniteScrollList,
  },
  data() {
    return {
      posts: [],
      filters: {},
      scroll_settings: {
        page: 0,
        records_quantity: 3,
        page_initialize_date: ""
      },
      intersection_active: true,
      redirect_module_name: "",
      last_search: "",
      module_name: "Activities",
    };
  },
  computed: {
      ...mapGetters({
         account: "current_user",
      }),
  },
  methods: {
    ...mapMutations(["setCurrentUser"]),
    parseDate(date) {
      return this.moment(date).format();
    },
    filterList() {
      this.posts = [];
      this.scroll_settings.page = 0;
      this.intersection_active = true;
    },
    setFilters(filters) {
      this.filters = filters;
    },
  },
  mounted() {
      this.scroll_settings.page_initialize_date = moment().format();
      this.setCurrentUser();
  },
  setup() {
    const { getPaged } = useAccounts();
    const { likePost } = usePosts();

    const getPagedPostList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPaged(
          this.account.id,
          this.scroll_settings.page_initialize_date,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity
        )
          .then((response) => {
            if (response.length > 0) {
              response.forEach((item) => {
                return this.posts.push(item);
              });
            } else {
              this.intersection_active = false;
            }
          })
          .catch((err) => {
            console.log(err);
          });
        this.scroll_settings.page++;
      }
    };
    const likeUserPost = function (post_id) {
        likePost({userId: this.account.id, postId: post_id}).then(
            (response) => {
               if (response.status == 200) {
                  this.$emit(
                  "show-alert",
                  `Post liked.`,
                  "success"
                  );
                  this.getPagedPostList();
               } else {
                  this.$emit(
                  "show-alert",
                  `Something went wrong. Error ${response.status}`,
                  "error"
                  );
               }
            },
            (error) => {
               this.$emit(
                  "show-alert",
                  `Something went wrong. ${error.response.status} ${error.response.data}`,
                  "error"
               );
            }
         );
    }

    return {
      getPagedPostList,
      likeUserPost
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
