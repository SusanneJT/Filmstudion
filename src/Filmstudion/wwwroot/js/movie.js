class Movie {
    constructor() {
        this.URL = "https://localhost:44393/api/filmstudios/"
    }

    async GetAll() {
        return fetch(this.URL + "Movies").then(response => response.json());
    }
}