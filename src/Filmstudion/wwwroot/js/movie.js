class Movie {
    constructor() {
        this.URL = "https://localhost:44393/api/movies/"
    }

    async GetAll() {
        return fetch(this.URL).then(response => response.json());
    }

    async GetMovieById(movieId) {
        return fetch(this.URL + movieId).then(response => response.json());
    }

    async UpdateMaxLendings(movieId, maxLending) {
       // this.URL + movieId + "?maxLendings=" + maxLending

        fetch((this.URL + movieId + "?maxLendings=" + maxLending), {
            method: 'PATCH', body: JSON.stringify({
                completed: true
            }),
            headers: {
                'Content-type': 'application / json; charset = UTF - 8'}
            })
            .then(response => response.json())
             .then(json => console.log(json))
    }


}