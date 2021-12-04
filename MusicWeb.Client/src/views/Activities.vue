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
  />
</template>

<script>
import useAccounts from "@/modules/accounts";
import InfiniteScrollList from "@/components/InfiniteScrollList";

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
      },
      intersection_active: true,
      redirect_module_name: "",
      last_search: "",
      module_name: "Activities",
      user_id: localStorage.getItem("user-id"),
    };
  },
  methods: {
    parseDate(date) {
      return this.moment.utc(date).format();
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

  setup() {
    const { getPaged } = useAccounts();

    const getPagedPostList = function (entries, observer, is_intersecting) {
      if (is_intersecting) {
        getPaged(
        this.user_id,
          this.scroll_settings.page,
          this.scroll_settings.records_quantity,
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

    return {
      getPagedPostList,
    };
  },
};
</script>

<style scoped>
.theme--light.v-card {
  background-color: #f5f5f5;
}
</style>
