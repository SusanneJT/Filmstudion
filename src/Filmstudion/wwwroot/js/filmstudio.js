class FilmStudio {
    constructor() {
        this.URL = "https://localhost:44393/api/filmstudios/"
    }

    async GetAll() {
        return fetch(this.URL).then(response => response.json());
    }
}