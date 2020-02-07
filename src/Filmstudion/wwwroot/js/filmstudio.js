class FilmStudio {
    constructor() {
        this.URL = "https://localhost:44393/api/filmstudios/"
    }

    async GetAll() {
        return fetch(this.URL).then(response => response.json());
    }

    async GetLendingsForStudio(studioName) {
        return fetch(this.URL + "LendedMovies?filmstudioName=" + studioName).then(response => response.json());
    }

    async LendMovie(studioName, movieId) {
        var lend = "LendedMovies?studioName=" + studioName + "&movieId=" + movieId;
        var requestOptions = {
            method: 'POST',
            redirect: 'follow'
        };

        fetch(this.URL + lend, requestOptions)
            .then(response => response.text())
            .then(result => console.log(result))
            .catch(error => console.log('error', error));
    }
}

