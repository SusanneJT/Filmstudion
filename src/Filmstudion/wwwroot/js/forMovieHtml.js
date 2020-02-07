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
        //+ '<button type="button" onclick="ChangeMaxLendings(\'' + chosenMovie.movie.movieId + '\')" class="btn btn-warning text-right">Andra</button>'
        + '<button type="button" class="btn btn-warning" data-toggle="modal" data-target="#exampleModal">Andra</button>'
        + '</div></div>'
        ).appendTo("#Movie");
}

async function ChangeMaxLendings() {
    // https://localhost:44393/api/Movies/3?maxLendings=4
    var movieId = sessionStorage.getItem("movieId");
    var newMax = $("#NewMaxLending").val();
    movie.UpdateMaxLendings(movieId, newMax);
    location.reload()
}