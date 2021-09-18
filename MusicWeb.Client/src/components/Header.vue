<template>
    <v-container fluid>
        <v-row justify="center">
            <v-col class="mt-6" lg="3" sm="6">
                <v-card>
                    <v-img
                        :src="require('@/assets/BandPhoto.svg')"
                        class="mx-1"
                        contain
                        width="402"
                        height="395"
                    />
                </v-card>
                <v-card class="my-9 text-left border-right-4 border-danger">
                    <h1 class="title font-weight-bold mb-12">Informacje</h1>
                    <p>Rok założenia: <span>1990</span></p>
                    <p>Pochodzenie: <span>Liverpool, Anglia</span></p>
                    <p>
                        Gatunek muzyczny:
                        <span>rock progresywny, art rock, doom metal</span>
                    </p>
                    <p>
                        Członkowie:
                        <span
                            >Vincent Cavanagh, Daniel Cavanagh, Jaime Cavanagh,
                            Lee Douglas, John Douglas</span
                        >
                    </p>
                </v-card>
            </v-col>

            <v-col class="mt-9" lg="6" sm="12">
                <v-row>
                    <v-col class="my-9" lg="7" sm="7">
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
                            <p class="mb-8 text-left">Dodaj do ulubionych:</p>
                            <p class="mb-8 text-left">
                                <font-awesome-icon
                                    class="icon"
                                    icon="heart"
                                    size="2x"
                                    color="#865e61"
                                />
                                <span>199 osób</span> dodało do ulubionych
                            </p>
                        </v-card>
                    </v-col>
                    <v-col class="mt-14" lg="4" sm="12">
                        <v-card align="flex-start">
                            <v-btn
                                outlined
                                color="grey"
                                height="30px"
                                class="text-uppercase mb-16"
                                >Obserwuj</v-btn
                            >
                            <p class="mb-8">Oceń artystę:</p>
                            <p class="mb-8">
                                <font-awesome-icon
                                    class="icon"
                                    v-for="(star, index) in stars"
                                    :key="index"
                                    icon="star"
                                    size="2x"
                                    :color="star.color"
                                />
                                <span> 4.0</span>
                            </p>
                        </v-card>
                    </v-col>
                    <v-col class="my-9" lg="12" sm="8">
                        <v-card class="my-9">
                            <h1
                                class="
                                    display-1
                                    font-weight-bold
                                    mb-12
                                    text-left
                                "
                            >
                                Biografia
                            </h1>
                            <p class="text-justify">
                                Anathema (gr. klątwa) to angielska grupa
                                muzyczna. Powstała 1990 roku w Liverpoolu.
                                Początkowo wykonująca drugofalowy death
                                metal/doom metal, będąc wraz z grupami
                                Katatonia, Tiamat, Winter, My Dying Bride i
                                Paradise Lost prekursorem gatunku. Obecnie grupa
                                zaliczana jest do nurtu art rocka oraz rocka
                                atmosferycznego.
                                <br /><br />
                                Anathema została stworzona w 1990 roku pod nazwą
                                Pagan Angel. W listopadzie tego roku zespół
                                nagrał pierwsze demo "An Iliad of Woes". Zmiana
                                nazwy nastąpiła na początku 1991 roku. Pierwsze
                                demo przyciągnęło uwagę zespołów z brytyjskiej
                                sceny metalowej i pozwoliło Anathemie zagrać
                                koncerty u boku takich kapel jak Bolt Thrower
                                czy Paradise Lost.
                            </p>
                        </v-card>
                    </v-col>
                </v-row>
            </v-col>
        </v-row>
    </v-container>
</template>

<script>
export default {
    name: "Header",

    data: () => ({
        stars: [
            { color: "#868263" },
            { color: "#868263" },
            { color: "#868263" },
            { color: "#868263" },
            { color: "gray" },
        ],
    }),
};
</script>

<style scoped>
.artist-title {
    letter-spacing: 5px !important;
}
p {
    color: gray;
}
p > span {
    color: #ebebf2;
    padding-bottom: 1px;
}
v-card {
    box-shadow: 0px red;
}
.icon {
    position: relative;
    top: 5px;
}
</style>
