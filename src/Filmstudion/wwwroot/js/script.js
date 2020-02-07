filmstudio = new FilmStudio();
movie = new Movie();

$(".show-later").hide();

if (sessionStorage.getItem("ChosenStudio") != null) {
    $("#WarningBox").hide();
    $("#dropdownMenuButton").html(sessionStorage.getItem("ChosenStudio"));
    AllMovies(sessionStorage.getItem("ChosenStudio"));
}




$(document).ready(async function () {
    AllStudios();
});

async function AllStudios() {
    var studios = await filmstudio.GetAll();
    $.each(studios, function (i) {
        $('<a class="dropdown-item" href="#" onclick="ChooseFilmStudio(\''
            + studios[i].filmstudioName + '\')">' + studios[i].filmstudioName + '</a > ').appendTo("#dropDownItems");
    });
}


function ChooseFilmStudio(studioName) {
    console.log(studioName);
    sessionStorage.setItem("ChosenStudio", studioName);
    $("#dropdownMenuButton").html(studioName);
    $("#WarningBox").hide();
    $(".show-later").show();
    AllMovies();
    GetLendedMovies(studioName);
}

async function AllMovies() {
    var movies = await movie.GetAll();
    $("#MovieUl").empty();
    $.each(movies, function (i) {
        var button;
        if (movies[i].availableForLending)
            button = '<button type = "button" class="btn btn-success">Tillganglig</button>'
        else
            button = '<button type="button" class="btn btn-danger">Ej tillganglig</button>'

        $('<li class="list-group-item d-flex justify-content-between align-items-center">'
            + '<div class="image-parent">'
            + '  <img src="/img/image-not-found.png" class="img-fluid" alt="quixote">'
            + '</div>'
            + '<h6>' + movies[i].movieTitle + '</h6>'
            + '<a href="movie.html" onclick="SaveMovieId(\''
            +  movies[i].movieId + '\')">Mer info</a>'
            + button
            + '</li>').appendTo("#MovieUl");

    });
}

async function GetLendedMovies(studioName) {
    var lendedMovies = await filmstudio.GetLendingsForStudio(studioName);
    $("#LendedMovies").empty();
    $.each(lendedMovies, function (i) {

        $('<li class="list-group-item">' + lendedMovies[i].movie.movieTitle + '</li>').appendTo("#LendedMovies");


    });
}

function SaveMovieId(movieId) {
    sessionStorage.setItem("movieId", movieId)
}




    
