<template>
    <v-navigation-drawer
        v-model="friend_list_visability"
        class="friend-list-container"
        absolute
        temporary
      >
      <v-list>
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
            <v-list-item-content>
               <v-list-item-title>
                  <template v-if="!user.is_friend">   
                     <v-btn fab class="friend-btn mr-1">
                        <font-awesome-icon
                        class="icon"
                        icon="check"
                        size="1x"
                        outlined
                        color="green"
                        ></font-awesome-icon>
                     </v-btn>
                     <v-btn fab class="friend-btn mr-4" >
                        <font-awesome-icon
                        class="icon"
                        icon="times"
                        size="1x"
                        outlined
                        color="#bc0000"
                        ></font-awesome-icon>
                     </v-btn>
                  </template>
                  <template v-else>
                     <v-btn fab class="friend-btn mr-4" >
                        <font-awesome-icon
                        class="icon"
                        icon="plus"
                        size="1x"
                        outlined
                        color="#485e7c"
                        ></font-awesome-icon>
                     </v-btn>
                  </template>
                  <span :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
               </v-list-item-title>
            </v-list-item-content>
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
            <v-list-item-content>
               <v-list-item-title>
                  <span :title="`${user.firstname} ${user.lastname}`">{{user.firstname}} {{user.lastname}}</span>
               </v-list-item-title>
            </v-list-item-content>
         </v-list-item>
        </v-list>
         <v-pagination
            v-model="page"
            class="pagination"
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
         users: []
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
   watch: {
      account(){
         this.getFriendsList();
      }
   },
   setup() {
      const { getAccounts, getFriends } = useAccounts();

      const getFriendsList = function () {
         let friends = [];
         getFriends(this.account.id).then((response) => {
            friends = response.data.map(friend => friend.friendId);
         });
         getAccounts().then((response) => {
            this.users = response.filter(user => {
               if(user.id != this.account.id && this.account.id){
                  user.is_friend = false;
                  if(friends.find(friend_id => friend_id == user.id) != null){
                     user.is_friend = true;
                  }
                  return user;
               }
            });
         });
      }

      return {
         getFriendsList
      }
   }
};
</script>
<style scoped>
.friend-list-container{
   width: 360px!important;
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
</style>