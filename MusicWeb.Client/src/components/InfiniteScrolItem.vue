<template>
  <div>
    <div v-if="page_name == 'ArtistList' || page_name == 'SongList'">
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
            <v-img
                class="pl-8"
                :src="`${server_url}/${item.image}`"
            >
            </v-img>
          </v-avatar>
        </div>
      </v-card>
    </div>
    <div
      v-else-if="
        page_name == 'Activities' &&
        (item.artist != null || item.album != null) &&
        item.userName == null &&
        item.posterId == null
      "
    >
      <v-card>
        <v-row class="pl-2 d-flex justify-space-between">
          <v-col lg="8" sm="8">
            <v-row align="center">
              <v-col lg="2" sm="2">
                <div class="post-thumb">
                    <v-img
                        v-if="item.image"
                        class="post-thumb-img"
                        :src="`${server_url}/${item.image}`"
                    >
                    </v-img>
                    <v-img
                        v-else
                        class="post-thumb-img"
                        :src="require(`@/assets/unknownUser.svg`)"
                    >
                    </v-img>
                </div>
              </v-col>
              <v-col lg="9" sm="9">
                <v-card-subtitle>
                  <p class="text-left">
                    <span
                      class="link-to-item"
                      @click="redirectToItem(item.artistId, 'Artist')"
                      >{{ item.artist }}</span
                    >
                    posted the new album
                  </p>
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
                    :src="`${server_url}/${item.albumImage}`"
                    @click="redirectToItem(item.albumId, 'Album')"
                    contain
                  />
                </div>
              </v-col>
              <v-col lg="8" sm="8">
                <v-card-title
                  justify="center"
                  class="text-h5 link-to-item"
                  v-text="item.album"
                  @click="redirectToItem(item.albumId, 'Album')"
                ></v-card-title>
                <v-card-subtitle>
                  <p class="text-left">
                    {{ moment(item.establishmentDate).format("YYYY") }}
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
          </v-col>
        </v-row>
        <v-row class="pl-5">
          <v-expansion-panels v-model="open_comments" enabled>
            <v-expansion-panel>
              <v-row class="d-flex justify-space-between">
                <v-col lg="3" sm="3" class="pt-4">
                  <v-btn  @click="likePost(item.id)">
                    <font-awesome-icon
                      :color="computed_item.isLiked ? '#485e7c' : '#fff'"
                      class="icon pa-1"
                      icon="thumbs-up"
                      size="2x"
                      outlined
                      fab
                    ></font-awesome-icon>
                    {{computed_item.totalLikes ? computed_item.totalLikes : ''}}
                  </v-btn>
                  <v-btn @click="toggleComments">
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
                    {{item.comments.length > 0 ? item.comments.length : ''}} comments
                  </v-expansion-panel-header>
                </v-col>
              </v-row>
              <v-row>
                <v-col lg="12">
                  <v-expansion-panel-content>
                    <v-text-field
                        placeholder="Add Comment..."
                        v-model="comment_input"
                        color="white"
                        @keyup.enter.exact="addComment(item.id)"
                    />
                    <div v-for="(comment, index) in item.comments" :key="index" class="comment-container">
                        <div class="thumb-img-container">
                        <!-- <v-img
                            v-if="participant.imagePath"
                            class="participant-thumb"
                            :src="`${server_url}/${participant.imagePath}`"
                        >
                        </v-img> -->
                        <v-img
                            class="comment-thumb"
                            :src="require(`@/assets/unknownUser.svg`)"
                        >
                        </v-img>
                        </div>
                        <div class="comment-content">
                            <div
                            class="comment-text"
                            >
                                <p
                                    class="comment-username"
                                >
                                    {{comment.userName}}
                                </p>
                                <p>
                                    {{ comment.text }}
                                </p>
                            </div>
                            <div class="comment-post-date">
                                <template>
                                {{ moment(comment.postDate).format("LLL") }}
                                </template>
                            </div>
                        </div>
                    </div>
                  </v-expansion-panel-content>
                </v-col>
              </v-row>
            </v-expansion-panel>
          </v-expansion-panels>
        </v-row>
      </v-card>
    </div>
    <div
      v-else-if="
        page_name == 'Activities' && item.artist == null && item.album == null
      "
    >
      <v-card>
        <v-row class="pl-2 d-flex justify-space-between">
          <v-col lg="8" sm="8">
            <v-row align="center">
              <v-col lg="2" sm="2">
                <div class="post-thumb">
                    <v-img
                        v-if="item.image"
                        class="post-thumb-img"
                        :src="`${server_url}/${item.image}`"
                    >
                    </v-img>
                    <v-img
                        v-else
                        class="post-thumb-img"
                        :src="require(`@/assets/unknownUser.svg`)"
                    >
                    </v-img>
                </div>
              </v-col>
              <v-col lg="9" sm="9">
                <v-card-subtitle>
                  <p class="text-left">{{ item.userName }}</p>
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
          <v-expansion-panels v-model="open_comments" enabled>
            <v-expansion-panel>
              <v-row class="d-flex justify-space-between">
                <v-col lg="3" sm="3" class="pt-4">
                  <v-btn @click="likePost(item.id)">
                    <font-awesome-icon
                      :color="computed_item.isLiked ? '#485e7c' : '#fff'"
                      class="icon pa-1"
                      icon="thumbs-up"
                      size="2x"
                      outlined
                      fab
                    ></font-awesome-icon>
                    {{computed_item.totalLikes ? computed_item.totalLikes : ''}}
                  </v-btn>
                  <v-btn @click="toggleComments">
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
                    {{item.comments.length > 0 ? item.comments.length : ''}} comments
                  </v-expansion-panel-header>
                </v-col>
              </v-row>
              <v-row>
                <v-col lg="12">
                  <v-expansion-panel-content>
                    <v-text-field
                        placeholder="Add Comment..."
                        v-model="comment_input"
                        color="white"
                        @keyup.enter.exact="addComment(item.id)"
                    />
                    <div v-for="(comment, index) in item.comments" :key="index" class="comment-container">
                        <div class="thumb-img-container">
                        <!-- <v-img
                            v-if="participant.imagePath"
                            class="participant-thumb"
                            :src="`${server_url}/${participant.imagePath}`"
                        >
                        </v-img> -->
                        <v-img
                            class="comment-thumb"
                            :src="require(`@/assets/unknownUser.svg`)"
                        >
                        </v-img>
                        </div>
                        <div class="comment-content">
                            <div
                            class="comment-text"
                            >
                                <p
                                    class="comment-username"
                                >
                                    {{comment.userName}}
                                </p>
                                <p>
                                    {{ comment.text }}
                                </p>
                            </div>
                            <div class="comment-post-date">
                                <template>
                                {{ moment(comment.postDate).format("LLL") }}
                                </template>
                            </div>
                        </div>
                    </div>
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
import { mapGetters } from "vuex";
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
      temp_item: this.item,
      open_comments: [],
      comment_input: ''
    };
  },
  props: {
    item: Object,
    page_name: String,
    redirect_module_name: String,
  },
  created() {
    if(this.item.establishmentDate == null || this.item.establishmentDate == ''){
        this.item.establishmentDate = this.item.createDate;
    }
    this.prepareDate();
  },
  computed: {
    ...mapGetters({
        server_url: "server_url", 
        account: "current_user"
    }),
    computed_item: {
         get(){
            return this.temp_item;
         },
         set(item){
            this.temp_item = item;
         }
    }
  },
  methods: {
    calculateAdditionTime() {
      let now_date = this.moment();
      let post_date = this.moment(this.item.establishmentDate);
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
      if (!type) {
        this.$router.push({
          name: `${this.redirect_module_name}`,
          params: { id: itemId },
        });
      } else {
        this.$router.push({
          name: type == "Album" ? "AlbumPage" : "ArtistPage",
          params: { id: itemId },
        });
      }
    },
    likePost(post_id){
        this.computed_item.totalLikes += 1;
        this.$emit("like-post", post_id);
    },
    toggleComments(){
        if(this.open_comments === 0){
            this.open_comments = undefined;
        } else {
            this.open_comments = 0;
        }
    },
    addComment(post_id){
        let new_comment = {
            userName: this.account.username,
            id: this.item.comments.length > 0 ? this.item.comments.at(-1).id + 1 : 1,
            postDate: this.moment(),
            postId: post_id,
            userId: this.account.id,
            text: this.comment_input
        };
        this.item.comments.push(new_comment);

        this.$emit("add-comment", new_comment);
        this.comment_input = '';
    }
  },
};
</script>

<style lang="less">
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
.v-expansion-panel::before {
  box-shadow: none;
}
.post-thumb {
  margin-left: 10px;
  margin-right: 10px;
}
.post-thumb-img{
  border-radius: 50%;
}
.comment-container {
  display: flex;
  align-items: flex-end;
  padding-left: 10px;

  .comment-content {
    display: flex;
    align-items: flex-start;
    justify-content: flex-start;
    flex-direction: column;
    flex-grow: 1;
  }

  .comment-thumb {
    width: 40px;
    height: 40px;
    border-radius: 50%;
    margin-right: 10px;
    margin-bottom: 10%;
  }

  .comment-text {
    background-color: rgb(44, 47, 51);
    overflow-wrap: break-word;
    text-align: left;
    white-space: pre-wrap;
    word-break: break-word;
    padding: 6px 10px;
    line-height: 14px;
    border-radius: 15px;
    margin: 5px 0 5px 0;
    max-width: 70%;
    border-bottom-left-radius: 0px;
  }
  .comment-text > p{
      color: #fff;
  }
  .comment-post-date {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    overflow-wrap: break-word;
    width: 100%;
    padding: 2px 7px;
    border-radius: 15px;
    margin: 0;
    max-width: 70%;
    font-size: 10px;
    color: #bdb8b8;
  }
}
</style>

