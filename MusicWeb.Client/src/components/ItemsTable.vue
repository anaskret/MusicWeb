<template>
<v-row justify="center">
  <v-col lg="10" class="mb-10">
    <div v-if="type=='song'" class="d-flex flex-row mb-5">
      <h1>Your songs</h1>
      <v-btn class="mt-2 ml-10" outlined @click="redirectToItem()">Add new song</v-btn>
    </div>
    <div v-if="type=='album'" class="d-flex flex-row mb-5">
      <h1>Your albums</h1>
      <v-btn class="mt-2 ml-10" outlined @click="redirectToItem()">Add new album</v-btn>
    </div>
     <v-simple-table>
      <thead>
      <tr>
        <th v-for="(column, index) in columns_list" :key="index">{{column}}</th>
      </tr>
        </thead>
        <tbody>
          <tr v-for="(item, index) in items" :key="index">
          <td><div>
          <v-img :src="require('@/assets/BandPhoto.svg')" style = "width: 50px;"/>
        </div></td>
          <td>{{ item.name }}</td>
          <td>{{ item.releaseDate }}</td>
          <td v-if="type == 'album'">{{ item.duration }}</td>
          <td v-else-if="type == 'song'">{{ item.length }}</td>
          <td v-if="type == 'album'"><span @click="redirectToItem(item.id)">      
            <font-awesome-icon
            class="icon pa-1"
            icon="edit"
            size="2x"
            outlined></font-awesome-icon></span>  
            <span @click="deleteAlbumItem(item.id)" v-on="on">
            <font-awesome-icon
            class="icon pa-1"
            icon="trash"
            size="2x"
            outlined></font-awesome-icon></span>
            </td>
          <td v-if="type == 'song'"><span @click="redirectToItem(item.id)">      
            <font-awesome-icon
            class="icon pa-1"
            icon="edit"
            size="2x"
            outlined></font-awesome-icon></span>  
            <span @click="deleteSongItem(item.id)" v-on="on">
            <font-awesome-icon
            class="icon pa-1"
            icon="trash"
            size="2x"
            outlined></font-awesome-icon></span>
            </td>
          <!-- <td v-if="type == 'song'"><a @click="redirectToItem(item.id)">Edit</a> / <a @click="deleteSongItem(item.id)" v-on="on">Delete</a></td> -->
        </tr>
        </tbody>
          </v-simple-table>
          </v-col>
          </v-row>
</template>

<script>
import useAlbums from "@/modules/albums";
import useSongs from "@/modules/songs";

export default ({
  name: "ItemsTable",
    props: {
    items: Array,
    columns_list: Array,
    module_name: String,
    type: String,
    getArtist: Function,
  },
  methods: {
    redirectToItem(itemId) {
      debugger;
      this.$router.push({ name: "ManageArtistPage", params: { type: this.type, id: itemId } });
    },
    redirectToList(item_id) {
      debugger;
      this.$router.push({ name: "ManageArtistPage", params: { id: item_id } });
    },
    deleteAlbumItem(id) {
      this.deleteArtistAlbum(id);
    },
    deleteSongItem(id) {
      this.deleteArtistSong(id);
    }
  }, 
  setup() {
    const { deleteAlbum } = useAlbums();
    const { deleteSong } = useSongs();

    const deleteArtistAlbum = function (id) {
      deleteAlbum(id).then((response) => {
            if (response.status == 200) {
              this.getArtist();
              this.$emit("show-alert", "Album deleted.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Error while removing album. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while removing album.  ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      };
    const deleteArtistSong = function (id) {
      deleteSong(id).then((response) => {
            if (response.status == 200) {
              this.getArtist();
              this.$emit("show-alert", "Song deleted.", "success");
            } else {
              this.$emit(
                "show-alert",
                `Error while removing song. Error ${response.status}`,
                "error"
              );
            }
          },
          (error) => {
            this.$emit(
              "show-alert",
              `Error while removing song.  ${error.response.status} ${error.response.data}`,
              "error"
            );
          }
        );
      };
    
    return {
      deleteArtistAlbum,
      deleteArtistSong,
    }
  }
});
</script>
<style lang="scss" scoped>
.icon {
  cursor: pointer;
}
</style>
