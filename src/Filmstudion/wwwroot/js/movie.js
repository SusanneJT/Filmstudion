class Movie {
    constructor() {
        this.URL = "https://localhost:44393/api/filmstudios/"
    }

    async GetAll(studioName) {
        return fetch(this.URL + studioName + "/movies").then(response => response.json());
    }
}