<template>
    <v-navigation-drawer
        v-model="friend_list_visability"
        class="friend-list-container"
        absolute
        temporary
        hide-overlay
      >
      <v-list>
          <v-list-item>
        <v-list-item-title>
            <h1>
                Friends
            </h1>
        </v-list-item-title>
          </v-list-item>
        <v-divider></v-divider>
         <v-list-item v-for="(user, index) in visibleUsers" :key="index">
            <v-list-item-avatar>
               <v-img
                  v-if="user.imagePath"
                  :src="`${server_url}/${user.imagePath}`"
                  :alt="`${user.firstname}`"
                  class="rounded-circle"
               />
               <v-img
                  v-else
                  src="@/assets/defaut_user.png"
                  :alt="`${user.firstname}`"
                  class="rounded-circle"
               />
            </v-list-item-avatar>
            <v-list-item-content class="open-chat-button">
               <v-list-item-subtitle>
                     <template v-if="user.receiver && !user.requestAccepted">   
                        <v-btn fab small class="friend-btn mr-1">
                           <font-awesome-icon
                           class="icon"
                           icon="check"
                           size="1x"
                           outlined
                           color="green"
                           ></font-awesome-icon>
                        </v-btn>
                        <v-btn fab small class="friend-btn mr-4" >
                           <font-awesome-icon
                           class="icon"
                           icon="times"
                           size="1x"
                           outlined
                           color="#bc0000"
                           ></font-awesome-icon>
                        </v-btn>
                     </template>
                     <template v-else-if="!user.receiver && !user.sender">
                        <v-btn fab small class="friend-btn mr-4" @click="addFriend(user.id)">
                           <font-awesome-icon
                           class="icon"
                           icon="plus"
                           size="1x"
                           outlined
                           color="#485e7c"
                           ></font-awesome-icon>
                        </v-btn>
                     </template>
                     <template v-else-if="user.sender && !user.requestAccepted">
                        <v-btn plain @click="openChat">
                           <v-badge
                              color="green"
                              content="Pending"
                           >
                              <span :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
                           </v-badge>
                        </v-btn>
                     </template>
                     <v-btn v-if="!user.sender" plain @click="openChat">
                        <span :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
                     </v-btn>
               </v-list-item-subtitle>
            </v-list-item-content>
         </v-list-item>
         <v-divider></v-divider>
         
         <!-- TODO accepted Friends list -->
         <!-- <v-list-item v-for="(user, index) in visibleUsers" :key="index">
            <v-list-item-avatar>
               <v-img
                  v-if="user.imagePath"
                  :src="`${server_url}/${user.imagePath}`"
                  :alt="`${user.firstname}`"
                  class="rounded-circle"
               />
               <v-img
                  v-else
                  src="@/assets/defaut_user.png"
                  :alt="`${user.firstname}`"
                  class="rounded-circle"
               />
            </v-list-item-avatar>
            <v-list-item-content>
               <v-list-item-subtitle>
                  <span :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
               </v-list-item-subtitle>
            </v-list-item-content>
         </v-list-item> -->
        </v-list>
         <v-pagination
            v-model="page"
            class="pagination"
            circle
            :length="Math.ceil(users.length/per_page)"
            :total-visible="5"
         ></v-pagination>
      </v-navigation-drawer>
</template>

<script>
import useAccounts from "@/modules/accounts";
import { mapGetters } from "vuex";
export default {
   name: "FriendList",
   data() {
      return {
         page: 1,
         per_page: 10,
         users: [],
         friend_request: {}
      }
   },
   props: {
      drawer: {
         required: true,
      },
   },
   computed: {
      ...mapGetters({
         account: "current_user",
         server_url: "server_url",
      }),
      friend_list_visability: {
         get(){
            return this.drawer;
         },
         set(drawer){
            this.$emit("update-drawer", drawer);
         }
      },
      visibleUsers () {
         return this.users.slice((this.page - 1)* this.per_page, this.page* this.per_page)
      }
   },
   methods: {
       openChat(){
         this.$emit("open-chat");
       },
   },
   watch: {
      account(){
         this.getFriendsList();
      }
   },
   setup() {
      const { getAccounts, getFriends, addFriendRequest } = useAccounts();

      const getFriendsList = function () {
         let friend_requests = [];
         getFriends(this.account.id).then((response) => {
            friend_requests = response.data;
         });
         getAccounts().then((response) => {
            this.users = response.filter(user => {
               if(user.id != this.account.id && this.account.id){
                  user.receiver = false;
                  user.sender = false;
                  const user_sent_request = friend_requests.find(request => request.createdByUserId == this.account.id);
                  const friend_sent_request = friend_requests.find(request => request.createdByUserId != this.account.id && request.userId == this.account.id);
                  if(user_sent_request){
                     user.sender = true;
                     user.requestAccepted = user_sent_request.isAccepted;
                  } else if (!user_sent_request && friend_sent_request){
                     user.receiver = true;
                     user.requestAccepted = friend_sent_request.isAccepted;
                  }
                  return user;
               }
            });
         });
      }
      
      const addFriend = function (id) {
      this.friend_request.userId = this.account.id;
      this.friend_request.friendId = id;
      addFriendRequest(this.friend_request).then(
        (response) => {
          if (response.status == 200) {
            // TODO change button to observed, get userobservedartist
            this.$emit(
              "show-alert",
              `Friend added successfuly.`,
              "success"
            );
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
    };

      return {
         getFriendsList,
         addFriend
      }
   }
};
</script>
<style scoped>
.friend-list-container{
   width: 400px!important;
}
* >>> .v-navigation-drawer__content{
   position: relative;
   height: 100vh;
}
.pagination {
   display: flex;
  position: absolute;
  justify-content: flex-end;
  align-items: flex-start;
  width: 100%;
  bottom: 1rem;
  z-index: 1;
}
.open-chat-button{
   height: 48px;
}
</style>