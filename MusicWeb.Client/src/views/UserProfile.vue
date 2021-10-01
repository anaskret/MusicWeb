<template>
    <v-container fluid class="py-16">
        <v-row justify="center">
            <v-col md="3" sm="6">
                <div>
                    <v-img :src="require('@/assets/BandPhoto.svg')" contain />
                </div>
            </v-col>
            <v-col md="7" sm="12">
                <v-row class="d-flex align-items-center">
                    <v-col lg="12" sm="7">
                        <div class="d-flex">
                            <div>
                                <h1
                                    class="
                                        text-uppercase
                                        display-3
                                        font-weight-bold
                                    "
                                >
                                    Anathema
                                </h1>
                            </div>
                            <v-btn
                                outlined
                                color="grey"
                                height="30px"
                                class="text-uppercase align-self-center ml-16"
                                >Ustawienia
                            </v-btn>
                        </div>
                    </v-col>
                </v-row>
                <v-row>
                    <v-col md="12" class="rating">
                        <!-- TODO Style => bootstrap class -->
                        <div>
                            <p>Dodaj do ulubionych</p>
                            <p>
                                <font-awesome-icon
                                    class="icon"
                                    icon="heart"
                                    size="2x"
                                    color="#865e61"
                                ></font-awesome-icon>
                                <span>199 osób</span> dodało do ulubionych
                            </p>
                        </div>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
export default {
    name: "Header",
    props: {
        artist: {
            type: Object,
            default: () => ({}),
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
        };
    },
};
</script>

<style scoped>
.rating {
    display: flex;
    justify-content: space-between;
}
</style>
