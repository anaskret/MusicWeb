<template>
    <v-container>
        <v-row class="text-center" justify="center">
            <v-row justify="center">
                <v-col class="my-6" lg="4" sm="6">
                    <v-card>
                        <v-img
                            :src="require('../assets/BandPhoto.svg')"
                            class="mx-1"
                            contain
                            width="402"
                            height="395"
                        />
                    </v-card>
                </v-col>

                <v-col class="my-9" lg="4" sm="6">
                    <v-card>
                        <h1
                            class="
                                display-3
                                font-weight-bold
                                mb-14
                                text-left text-uppercase
                                artist-title
                            "
                        >
                            Anathema
                        </h1>
                        <p class="
                                mb-8
                                text-left
                            ">
                            Dodaj do ulubionych:
                        </p>
                        <p class="
                                mb-8
                                text-left
                            ">
                            <font-awesome-icon icon="heart" size="2x" color="#865e61" /> <span>199 osób</span> dodało do ulubionych
                        </p>
                    </v-card>
                </v-col>
                <v-col class="mt-14" lg="3" sm="12">
                    <v-card>
                        <v-btn
                            outlined
                            color="grey"
                            height="30px"
                            class="text-uppercase mb-16"
                            >Obserwuj</v-btn
                        >
                        <p class="
                                mb-8
                                text-left
                            ">
                            Oceń artystę:
                        </p>
                        <p class="
                                mb-8
                                text-left
                            ">
                            <font-awesome-icon v-for="(star, index) in stars" :key="index" icon="star" size="2x" :color="star.color" />
                            <span>5.0</span>
                        </p>
                    </v-card>
                </v-col>
                
            </v-row>
            <v-col class="mb-5" cols="9">
                <v-card>
                    <h2 class="headline font-weight-bold mb-3">What's next?</h2>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
export default {
    name: "Header",

    data: () => ({
        stars: [
            {color: '#868263'},
            {color: '#868263'},
            {color: '#868263'},
            {color: '#868263'},
            {color: 'gray'},
        ]
    }),
};
</script>

<style scoped>
v-btn {
    border: 1px solid gray;
    color: red;
}
.artist-title{
    letter-spacing: 5px!important;
}
p{
    color: gray;
}
p>span{
    color: #EBEBF2;
    padding-bottom: 1px;
}
v-card{
    box-shadow: 0px red;
}

</style>
