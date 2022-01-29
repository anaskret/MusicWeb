<template>
  <v-container fluid>
    <v-row justify="center">
      <v-col class="py-lg-9 pr-lg-10 col-12 col-md-3">
        <span class="border-right border-dark"></span>
        <h1 class="title font-weight-bold pb-lg-5">Info</h1>
        <div v-if="module_name == 'Artist'">
          <p>
            Establishment Date:
            <span>{{ moment(parent.establishmentDate).format("L") }}</span>
          </p>
          <p>
            Origin:
            <span>
              {{ parent.country }}
            </span>
          </p>
          <p>
            Music Genre:
            <span v-for="(genre, index) in parent.genres" :key="index">
              {{ genre
              }}<span v-if="index != parent.genres.length - 1">,</span></span
            >
          </p>
          <p v-if="parent.bandId == null">
            Participants:
            <span v-for="(member, index) in parent.members" :key="index">
              {{ member
              }}<span v-if="index != parent.members.length - 1">,</span></span
            >
          </p>
        </div>
        <div v-else-if="module_name == 'Album'">
          <p>
            Artist:
            <span>{{ parent.artist.name }}</span>
          </p>
          <p>
            Release Date:
            <span>{{ moment(parent.releaseDate).format("L") }} </span>
          </p>
          <p>
            Duration:
            <span>{{ parent.duration }} mins</span>
          </p>
          <p>
            Music Genre:
            <span>{{ parent.albumGenre.name }}</span>
          </p>
        </div>
        <div v-else-if="module_name == 'Song'">
          <p>
            Album
            <span>{{ parent.album.name }} - {{ parent.composer.name }} </span>
          </p>
          <p>
            Release Date:
            <span>{{ moment(parent.releaseDate).format("L") }} </span>
          </p>
          <p>
            Duration:
            <span>{{ parent.duration }} mins</span>
          </p>
          <p>
            Position:
            <span>{{ parent.positionOnAlbum }}</span>
          </p>
        </div>
      </v-col>
      <v-col class="col-12 col-md-3">
        <h1 class="pb-lg-5">{{ description_title }}</h1>
        <div class="description-container" v-if="description_truncate" >
            <p class="text-justify">
            {{ parent.description | truncate(350, "...") }}
            </p>
            <v-btn @click="description_truncate = !description_truncate">
                <font-awesome-icon
                    class="icon pa-1"
                    icon="chevron-down"
                    size="2x"
                    outlined
                ></font-awesome-icon>
            </v-btn>
        </div>
        <div class="description-container" v-else>
            <p class="text-justify">
            {{ parent.description }}
            </p>
            <v-btn @click="description_truncate = !description_truncate">
                <font-awesome-icon
                    class="icon pa-1"
                    icon="chevron-up"
                    size="2x"
                    outlined
                ></font-awesome-icon>
            </v-btn>
        </div>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "InfoSection",
  props: {
    parent: {
      type: Object,
      default: () => ({}),
    },
    module_name: {
      type: String,
    },
    description_title: {
      type: String,
      default: "Description",
    },
  },
  data() {
    return {
      stars: [
        { color: "#868263" },
        { color: "#868263" },
        { color: "#868263" },
        { color: "#868263" },
        { color: "gray" },
      ],
      description_truncate: true
    };
  },
};
</script>

<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Montserrat:wght@100;200;300;400;500;700&display=swap");
.artist-title {
  letter-spacing: 5px;
  font-size: 3.2rem;
}
.align-center {
  display: flex;
  align-items: center;
}
template {
  font-family: "Montserrat";
}
p {
  font-size: 1rem;
  color: gray;
}
p > span {
  color: #ebebf2;
  padding-bottom: 1px;
}
.feature-text {
  font-size: 1rem;
}
.description-container{
    display: flex;
    flex-direction: column;
}
</style>