<template>
  <div>
    <v-row v-if="page_name == 'ArtistList' || page_name == 'SongList' || page_name == 'AlbumList' || page_name == 'ArtistFavoriteList' || page_name == 'ArtistObservedList' || page_name == 'AlbumFavoriteList' || page_name == 'SongFavoriteList'">
      <v-col lg="12">
      <v-card @click="redirectToItem(item.id)">
        <div class="d-flex">
          <div>
             <v-avatar class="ma-3" size="125" tile>
            <v-img
                v-if="item.imagePath == null || item.imagePath == ''"
                :src="require(`@/assets/unknownUser.svg`)"
                :alt="`${item.name}`"
                style = "width: 50px;"
                contain
            />
            <v-img
                    v-else-if="item.imagePath.slice(0, 4) == 'http'"
                    :src="`${item.imagePath}`"
                    :alt="`${item.name}`"
                    style = "width: 50px;"
                    contain
            />
            <v-img
                    v-else
                    :src="`${server_url}/${item.imagePath}`"
                    :alt="`${item.name}`"
                    style = "width: 50px;"
                    contain
            />
          </v-avatar>
          <v-card-subtitle>
            <div class="d-flex flex-row">
            <div class="d-flex flex-row"><font-awesome-icon
                  class="star icon pr-2"
                  icon="star"
                  size="2x"
                  color="#868263"
                ></font-awesome-icon>
                <h4 class="mt-1">{{item.rating}}</h4></div> 
              
            <div class="d-flex flex-row ml-3"><font-awesome-icon
                  class="star icon pr-2"
                  icon="heart"
                  size="2x"
                  color="#865e61"
                ></font-awesome-icon>
                <h4 class="mt-1">{{item.favoriteCount}}</h4></div> 
              
              </div>
          </v-card-subtitle
            >
        </div>
        <div>
          <v-card-title class="text-h5">{{item.name}}</v-card-title>
          <v-card-subtitle v-if="page_name == 'SongList' || page_name == 'AlbumList'" class="font-thin font-italic" >by {{item.artistName}}</v-card-subtitle>
          <p v-if="page_name == 'AlbumList' || page_name == 'AlbumFavoriteList'" class="ml-3">{{ item.description | truncate(reviewTextLength, "...") }}</p>
          <p v-else-if="page_name == 'SongList' || page_name == 'SongFavoriteList'" class="ml-3">{{ item.text | truncate(reviewTextLength, "...") }}</p>
          <p v-else-if="page_name == 'ArtistList' || page_name == 'ArtistFavoriteList'" class="ml-3">{{ item.description | truncate(reviewTextLength, "...") }}</p>
        </div>
      </div>

      </v-card>
    </v-col>
  </v-row>
    <v-row v-else-if="page_name == 'AlbumReviewList' || page_name == 'SongReviewList'">
      <v-col lg="12">
      <v-card @click="redirectToItem(item.id)">
        <div class="d-flex">
          <div>
            <v-avatar class="ma-3" size="125" tile> 
            <!-- <v-img
                class="pl-8"
                :src="`${server_url}/${item.image}`"
            >
            </v-img> -->
              <v-img :src="require('@/assets/band_logo.jpg')" style = "width: 50px;"/>
            </v-avatar>
          <v-card-subtitle>
            <h4>{{item.name}} - {{item.artist}}</h4>
            <p>
              {{ moment(item.establishmentDate).format("L") }}
            </p>
              
          </v-card-subtitle
            >
        </div>
        <div>
          <v-card-title class="text-h5" v-text="item.title"></v-card-title>
          <v-card-subtitle class="font-thin font-italic" >by {{item.userName}}</v-card-subtitle>
          <p>{{ item.content | truncate(reviewTextLength, "...") }}</p>
        </div>
      </div>

      </v-card>
    </v-col>
  </v-row>
    <div
      v-else-if="
        page_name == 'Activities' &&
        (item.artist != null || item.album != null) &&
        item.userName == null &&
        item.posterId == null
      "
    >
      <v-card>
        <v-row class="pl-2">
            <v-col lg="2" sm="2">
                <div class="post-thumb">
                    <v-img
                        v-if="item.image == null || item.image == ''"
                        :src="require(`@/assets/unknownUser.svg`)"
                        :alt="`${item.name}`"
                        class="post-thumb-img"
                        style="cursor:pointer;"
                        @click="redirectToItem(item.artistId, 'Artist')"
                        contain
                    />
                    <v-img
                        v-else-if="item.image.slice(0, 4) == 'http'"
                        :src="`${item.image}`"
                        :alt="`${item.name}`"
                        class="post-thumb-img"
                        style="cursor:pointer;"
                        @click="redirectToItem(item.artistId, 'Artist')"
                        contain
                    />
                    <v-img
                        v-else
                        :src="`${server_url}/${item.image}`"
                        :alt="`${item.name}`"
                        class="post-thumb-img"
                        style="cursor:pointer;"
                        @click="redirectToItem(item.artistId, 'Artist')"
                        contain
                    />
                </div>
            </v-col>
            <v-col sm="8" md="7" lg="8">
            <v-card-subtitle class="aritist-post-title">
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
            <v-col sm="2" md="3" lg="2" class="d-none d-md-block">
                <v-card-subtitle>
                <p class="text-right">
                    {{ time_from_addition }}
                </p>
                </v-card-subtitle>
            </v-col>
        </v-row>
        <v-row class="pl-2 d-flex justify-space-between">
          <v-col lg="8">
            <v-row>
              <v-col lg="4">
                <div>
                  <v-img
                    class="link-to-item"
                    :src="`${server_url}/${item.albumImage}`"
                    @click="redirectToItem(item.albumId, 'Album')"
                    contain
                  />
                  
                    <v-img
                        v-if="item.albumImage == null || item.albumImage == ''"
                        :src="require(`@/assets/unknownUser.svg`)"
                        @click="redirectToItem(item.albumId, 'Album')"
                        :alt="`${item.name}`"
                        class="link-to-item"
                        contain
                    />
                    <v-img
                        v-else-if="item.albumImage.slice(0, 4) == 'http'"
                        :src="`${item.albumImage}`"
                        @click="redirectToItem(item.albumId, 'Album')"
                        :alt="`${item.name}`"
                        class="link-to-item"
                        contain
                    />
                    <v-img
                        v-else
                        :src="`${server_url}/${item.albumImage}`"
                        @click="redirectToItem(item.albumId, 'Album')"
                        :alt="`${item.name}`"
                        class="link-to-item"
                        contain
                    />
                </div>
              </v-col>
              <v-col lg="8">
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
                  <p class="text-left">Rock</p>
                </v-card-subtitle>
              </v-col>
            </v-row>
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
                <v-col lg="3">
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
      comment_input: '', 
      reviewTextLength: 400,
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
.v-responsive__content{
  width: auto!important;;
}
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
@media (max-width: 600px){
    .post-thumb{
        max-width: 40%;
    }
    .aritist-post-title{
        position: absolute;
        top: 4%;
        left: 24%;
    }
}
@media (max-width: 410px){
    .aritist-post-title{
        top: 2%;
    }
}
</style>

