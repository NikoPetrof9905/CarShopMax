var app = new Vue({
    el: '#app',
    vuetify: new Vuetify(),
    data: {

        makeupId: document.getElementById("makeupId").value,
        makeupName: "My awesome makeup",
        makeupDescription: "My Awesome Makeup description",
        makeupPicture: null,
        makeupPictureBase64: null,
        makeupSteps: [
            {
                name: "Put on some ...",
                description: "....",
                color: "#f1f1f1"
            }
        ],

        // do show the login error dialog
        errDialog: false,
        // error message
        errText: null,

    },
    watch: {
        makeupPicture(val) {
            var reader = new FileReader();
            reader.onloadend = () => app.makeupPictureBase64 = reader.result;
            reader.readAsDataURL(val);
        }
    },
    mounted() {
        if (this.makeupId != 'new') {



        } 
    },
    methods: {
        save() {
            if (this.makeupId == 'new') {

                try {
                    axios.post("/api/makeups", { "name": app.makeupName, "image": app.makeupPictureBase64, "description": app.makeupDescription, "steps": app.makeupSteps.map(x => { return { "name": x.name, "color": x.color, "description": x.description }; }) })
                        .then(function (response) {
                            window.location.href = "/home";
                        })
                        .catch(function (err) {
                            app.errText = err.response.data;
                            app.errDialog = true;
                        });
                }
                // Something went horrablly wrong!
                catch (err) {
                    this.isLoading = false;
                    this.errText = "Нещо се обърка!";
                    this.errDialog = true;
                }

            } else {

            }
        }
    }
})