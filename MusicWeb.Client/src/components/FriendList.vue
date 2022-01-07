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
                        <v-btn fab small class="friend-btn mr-1" @click="acceptRequest(user.id)">
                           <font-awesome-icon
                           class="icon"
                           icon="check"
                           size="1x"
                           outlined
                           color="green"
                           ></font-awesome-icon>
                        </v-btn>
                        <v-btn fab small class="friend-btn mr-4" @click="discardRequest(user.id)">
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
                        <div class="pending-status">
                           <v-badge
                              color="green"
                              content="Pending"
                           >
                              <span :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
                           </v-badge>
                        </div>
                     </template>
                     <template v-if="(user.sender || user.receiver) && user.requestAccepted">
                        <v-btn  plain @click="openChat(user)">
                           <span :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
                        </v-btn>
                     </template>
                     <span v-if="!user.sender && !user.requestAccepted" :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
               </v-list-item-subtitle>
            </v-list-item-content>
         </v-list-item>
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
import useChats from "@/modules/chats";
import { mapGetters, mapMutations } from "vuex";
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
       async openChat(user_id){
         await this.getChat(user_id);
         this.$emit("open-chat");
       },
        ...mapMutations([
            "setCurrentChat",
            "setParticipant"
        ])
   },
   watch: {
      account(){
         this.getFriendsList();
      }
   },
   setup() {
      const { getAccounts, getFriends, addFriendRequest, acceptFriendRequest, discardFriendRequest } = useAccounts();
      const { getChatByUserId, createNewChat } = useChats();

      const getFriendsList = async function () {
         let friend_requests = await getFriends(this.account.id).then((response) => response.data);
         getAccounts().then((response) => {
            this.users = response.filter(user => {
               if(user.id != this.account.id && this.account.id){
                  user.receiver = false;
                  user.sender = false;
                  const user_sent_request = friend_requests.find(function (request) 
                  {
                     if(request.createdByUserId == this.account.id && request.friendId == user.id)
                     {
                        return request;
                     }
                  }.bind(this));
                  const friend_sent_request = friend_requests.find(function (request) 
                  {
                     if(request.createdByUserId != this.account.id && request.userId == user.id)
                     {
                        return request;
                     }
                  }.bind(this));
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
                  this.$emit(
                  "show-alert",
                  `Friend added successfuly.`,
                  "success"
                  );
                  this.getFriendsList();
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

      const acceptRequest = function (id){
         this.friend_request.userId = this.account.id;
         this.friend_request.friendId = id;
         acceptFriendRequest(this.friend_request).then(
            (response) => {
               if (response.status == 200) {
                  this.$emit(
                  "show-alert",
                  `Friend accepted.`,
                  "success"
                  );
                  this.getFriendsList();
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

      const discardRequest = function (id){
         discardFriendRequest(this.account.id, id).then(
            (response) => {
               if (response.status == 200) {
                  this.$emit(
                  "show-alert",
                  `Friend discarded.`,
                  "success"
                  );
                  this.getFriendsList();
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
      const getChat = async function (friend){
         let chat = await getChatByUserId(this.account.id).then((response) => 
         {
            let chats = response.data;
            return chats.find(function (chat){
               if(chat.friendName == friend.username && chat.userName == this.account.username)
               {
                  return chat;
               } else if (chat.friendName == this.account.username && chat.userName == friend.username){
                   let tmp_full_name = chat.fullName;
                   chat.friendName = friend.username;
                   chat.userName = this.account.username;
                   chat.fullName = chat.friendFullName;
                   chat.friendFullName = tmp_full_name;
                   return chat;
               }
            }.bind(this));
               
         });
         if(chat){
             this.setCurrentChat(chat); 
            this.setParticipant(friend);
         } else {
             createNewChat({userId: this.account.id, friendId: friend.id}).then(response => {
                 if(response.status == 200){
                     getChat(friend);
                 }
             });
         }
      }

      return {
         getFriendsList,
         addFriend,
         acceptRequest,
         discardRequest,
         getChat
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
.pending-status{
   height: 48px;
   display: flex;
   align-items: center;
}
</style>