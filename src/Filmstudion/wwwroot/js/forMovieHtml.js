filmstudio = new FilmStudio();
movie = new Movie();

$(document).ready(async function () {
    GetMovie();    
});


async function GetMovie() {
    var chosenMovie = await movie.GetMovieById(sessionStorage.getItem("movieId"));
    $('<h1>' + chosenMovie.movie.movieTitle + '</h1>'
        + '<hr><h6>Handling:</h6>'
        + '<p>' + chosenMovie.movie.storyLine + '</p><hr>'
        + '<div class="row">' 
        + '<div class="col-4">'
        + '<h6 style="display: inline">Max antal utlaningar: </h6>' + chosenMovie.movie.maxLendings 
        + '</div> <div class="col-8">'
        + '<button type="button" class="btn btn-warning" data-toggle="modal" data-target="#exampleModal">Andra</button>'
        + '</div></div>'
    ).appendTo("#Movie");


    if (chosenMovie.movie.availableForLending == true) {
        $('<p>' + chosenMovie.movie.movieTitle + ' ar tillganglig att lana.</p>'
            + '<button type="button" class="btn btn-success" onclick="LendMovie()"'
            +'> Lana</button > '
        ).appendTo("#available-box");
    }
    else {
        $('<p>' + chosenMovie.movie.movieTitle + ' kan inte lanas just nu.</p>'
        ).appendTo("#available-box");
    }      
}

async function ChangeMaxLendings() {
    // https://localhost:44393/api/Movies/3?maxLendings=4
    var movieId = sessionStorage.getItem("movieId");
    var newMax = $("#NewMaxLending").val();
    movie.UpdateMaxLendings(movieId, newMax);
    location.reload()
}

async function LendMovie() {
    var movieId = sessionStorage.getItem("movieId");
    var studioName = sessionStorage.getItem("ChosenStudio");
    filmstudio.LendMovie(studioName, movieId);
}