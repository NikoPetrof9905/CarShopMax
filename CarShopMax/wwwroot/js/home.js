var app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data: {
        isLoading: false,
        makeups: [
        ],
        errText: "",
        errDialog: false
    },
    mounted() {
        this.getNext();
    },
    methods: {

        getNext() {
            try {
                this.isLoading = true;
                axios.get("/api/makeups/next-makeup")
                    .then(function (response) {
                        if (response.data["name"]) app.makeups = [response.data];
                        else app.makeups = [];
                    })
                    .catch(function (err) {
                        app.errText = err.response.data;
                        app.errDialog = true;
                    })
                    .then(function () {
                        app.isLoading = false;
                    });
            }
            // Something went horrablly wrong!
            catch (err) {
                this.isLoading = false;
                this.errText = "Нещо се обърка!";
                this.errDialog = true;
            }
        }

    }
})