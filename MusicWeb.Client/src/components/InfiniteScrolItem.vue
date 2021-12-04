<template>
  <div>
    <div v-if="page_name == 'ArtistList'">
      <v-card @click="redirectToItem(item.id)">
        <div class="d-flex flex-no-wrap justify-space-between">
          <div>
            <v-card-title class="text-h5" v-text="item.name"></v-card-title>

            <v-card-subtitle
              ><p>
                {{ moment(item.establishmentDate).format("L") }}
              </p></v-card-subtitle
            >

            <v-card-actions>
              <v-btn
                class="ml-2 mt-3"
                fab
                icon
                height="40px"
                right
                width="40px"
              >
                <font-awesome-icon
                  class="icon"
                  icon="chevron-right"
                  size="2x"
                />
              </v-btn>
            </v-card-actions>
          </div>

          <v-avatar class="ma-3" size="125" tile>
            <v-img :src="require(`@/assets/judgement.svg`)"></v-img>
          </v-avatar>
        </div>
      </v-card>
    </div>
    <div v-else-if="page_name == 'Activities' && (item.artist != null || item.album != null) && item.userName == null && item.posterId == null">
      <v-card>
        <v-row class="pl-2 d-flex justify-space-between">
          <v-col lg="8" sm="8">
            <v-row align="center">
              <v-col lg="2" sm="2">
                <div>
                  <v-img
                    :src="require('@/assets/BandPhoto.svg')"
                    contain
                    class="pl-8"
                  />
                </div>
              </v-col>
              <v-col lg="9" sm="9">
                <v-card-subtitle>
                  <p class="text-left"><span class="link-to-item" @click="redirectToItem(item.artistId, 'Artist')">{{item.artist}}</span> posted the new album</p>
                </v-card-subtitle>
              </v-col>
            </v-row>
          </v-col>
          <v-col lg="3" sm="3">
            <v-card-subtitle>
              <p class="text-right">
                {{ time_from_addition }}
              </p>
            </v-card-subtitle>
          </v-col>
        </v-row>
        <v-row class="pl-2 d-flex justify-space-between">
          <v-col lg="8" sm="8">
            <v-row>
              <v-col lg="4" sm="4">
                <div>
                  <v-img
                    class="link-to-item"
                    :src="require('@/assets/naturaldisaster.svg')"
                    @click="redirectToItem(item.albumId, 'Album')"
                    contain
                  />
                </div>
              </v-col>
              <v-col lg="8" sm="8">
                <v-card-title
                  justify="center"
                  class="text-h5  link-to-item"
                  v-text="item.album"
                  @click="redirectToItem(item.albumId, 'Album')"
                ></v-card-title>
                <v-card-subtitle>
                  <p class="text-left">
                    {{ moment(item.createDate).format("YYYY") }}
                  </p>
                  <p class="text-left">Genre</p>
                </v-card-subtitle>
              </v-col>
            </v-row>
          </v-col>
          <v-col lg="4" sm="4">
            <div class="ratings pt-4">
              <font-awesome-icon
                class="icon pr-2"
                v-for="(star, index) in stars"
                :key="index"
                icon="star"
                size="2x"
                :color="star.color"
              ></font-awesome-icon>
            </div>
            <div class="ratings pt-4">
              <p class="ratings-thumbs">200</p>
              <font-awesome-icon
                class="icon pa-1"
                icon="thumbs-up"
                size="2x"
              ></font-awesome-icon>
            </div>
          </v-col>
        </v-row>
        <v-row class="pl-5">
          <v-expansion-panels enabled>
            <v-expansion-panel>
              <v-row class="d-flex justify-space-between">
                <v-col lg="3" sm="3" class="pt-4">
                  <v-btn>
                    <font-awesome-icon
                      class="icon pa-1"
                      icon="thumbs-up"
                      size="2x"
                      outlined
                      fab
                    ></font-awesome-icon>
                  </v-btn>
                  <v-btn>
                    <font-awesome-icon
                      class="icon pa-1"
                      icon="comment"
                      size="2x"
                      outlined
                      fab
                    ></font-awesome-icon>
                  </v-btn>
                </v-col>
                <v-col lg="3" sm="3">
                  <v-expansion-panel-header hide-actions class="justify-end">
                    2 comments
                  </v-expansion-panel-header>
                </v-col>
              </v-row>
              <v-row>
                <v-col lg="12">
                  <v-expansion-panel-content>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed
                    do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                    Ut enim ad minim veniam, quis nostrud exercitation ullamco
                    laboris nisi ut aliquip ex ea commodo consequat.
                  </v-expansion-panel-content>
                </v-col>
              </v-row>
            </v-expansion-panel>
          </v-expansion-panels>
        </v-row>
      </v-card>
    </div>
    <div v-else-if="page_name == 'Activities' && item.artist == null && item.album == null">
      <v-card>
        <v-row class="pl-2 d-flex justify-space-between">
          <v-col lg="8" sm="8">
            <v-row align="center">
              <v-col lg="2" sm="2">
                <div>
                  <v-img
                    :src="require('@/assets/BandPhoto.svg')"
                    contain
                    class="pl-8"
                  />
                </div>
              </v-col>
              <v-col lg="9" sm="9">
                <v-card-subtitle>
                  <p class="text-left">{{item.userName}}</p>
                </v-card-subtitle>
              </v-col>
            </v-row>
          </v-col>
          <v-col lg="3" sm="3">
            <v-card-subtitle>
              <p class="text-right">
                {{ time_from_addition }}
              </p>
            </v-card-subtitle>
          </v-col>
        </v-row>
        <v-row class="pl-2 d-flex justify-start">
          <v-col lg="10" sm="10">
                <v-card-title
                  justify="center"
                  class="text-h5"
                  v-text="item.text"
                ></v-card-title>
            </v-col>
        </v-row>
        <v-row class="pl-5">
          <v-expansion-panels enabled>
            <v-expansion-panel>
              <v-row class="d-flex justify-space-between">
                <v-col lg="3" sm="3" class="pt-4">
                  <v-btn>
                    <font-awesome-icon
                      class="icon pa-1"
                      icon="thumbs-up"
                      size="2x"
                      outlined
                      fab
                    ></font-awesome-icon>
                  </v-btn>
                  <v-btn>
                    <font-awesome-icon
                      class="icon pa-1"
                      icon="comment"
                      size="2x"
                      outlined
                      fab
                    ></font-awesome-icon>
                  </v-btn>
                </v-col>
                <v-col lg="3" sm="3">
                  <v-expansion-panel-header hide-actions class="justify-end">
                    2 comments
                  </v-expansion-panel-header>
                </v-col>
              </v-row>
              <v-row>
                <v-col lg="12">
                  <v-expansion-panel-content>
                    Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed
                    do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                    Ut enim ad minim veniam, quis nostrud exercitation ullamco
                    laboris nisi ut aliquip ex ea commodo consequat.
                  </v-expansion-panel-content>
                </v-col>
              </v-row>
            </v-expansion-panel>
          </v-expansion-panels>
        </v-row>
      </v-card>
    </div>
  </div>
</template>

<script>
export default {
  name: "InfiniteScrolItem",
  data() {
    return {
      time_from_addition: 0,
      stars: [
        { color: "white" },
        { color: "white" },
        { color: "white" },
        { color: "white" },
        { color: "gray" },
      ],
    };
  },
  props: {
    item: Object,
    page_name: String,
    redirect_module_name: String,
  },
  created() {
    this.prepareDate();
  },
  methods: {
    calculateAdditionTime() {
      let now_date = this.moment();
      let post_date = this.moment(this.item.createDate);
      let duration = this.moment.duration(now_date.diff(post_date));
      duration = duration._data;
      let result = "";
      if (duration.years) {
        result = this.setTimeDuration(duration.years, "year", duration.days);
      } else if (duration.days > 0) {
        result = this.setTimeDuration(duration.days, "day", duration.hours);
      } else if (duration.hours > 0) {
        result = this.setTimeDuration(duration.hours, "hour", duration.minutes);
      } else if (duration.minutes > 0) {
        result = this.setTimeDuration(
          duration.minutes,
          "minute",
          duration.seconds
        );
      }

      return result ? `${result} ago` : "now";
    },
    setTimeDuration(timestamp, timestamp_name, next_timestamp) {
      let result = `${timestamp} ${timestamp_name}s`;
      if (timestamp == 1) {
        result = `one ${timestamp_name}`;
      } else if (next_timestamp && timestamp == 1) {
        result = `over one ${timestamp_name}`;
      } else if (next_timestamp && timestamp != 1) {
        result = `over ${timestamp} ${timestamp_name}s`;
      }
      return result;
    },
    prepareDate() {
      this.time_from_addition = this.calculateAdditionTime();
    },
    redirectToItem(itemId, type = null) {
      if(!type){
        this.$router.push({
          name: `${this.redirect_module_name}`,
          params: { id: itemId },
        });
      } else {
        this.$router.push({ name: type == 'Album' ? "AlbumPage" : "ArtistPage", params: { id: itemId } });
      }
    }
  },
};
</script>

<style scoped>
.ratings {
  display: flex;
  justify-content: flex-end;
  align-items: center;
}
.ratings-thumbs {
  display: flex;
  align-items: center;
  margin-bottom: 0;
  margin-top: 5%;
  margin-right: 4%;
}
p {
  margin-bottom: 0;
}
.v-expansion-panel::before{
  box-shadow: none;
}
</style>
