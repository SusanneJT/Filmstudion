filmstudio = new FilmStudio();
movie = new Movie();

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
            + studios[i].studioName + '\')">' + studios[i].studioName + '</a > ').appendTo("#dropDownItems");
    });
}


function ChooseFilmStudio(studioName) {
    console.log(studioName);
    sessionStorage.setItem("ChosenStudio", studioName);
    $("#dropdownMenuButton").html(studioName);
    $("#WarningBox").hide();
    AllMovies(sessionStorage.getItem("ChosenStudio"));
}

async function AllMovies(studioName) {
    var movies = await movie.GetAll(studioName);
    $("#MovieBox").empty();
    $.each(movies, function (i) {

        $('<li class="list-group-item d-flex justify-content-between align-items-center">'
           + '<div class="image-parent">'
           + '  <img src="/img/image-not-found.png" class="img-fluid" alt="quixote">'
           + '</div>'
           + '<h6>' + movies[i].movieTitle + '</h6>'
           + '<a href="#">Mer info</a>'
           + '<button>Låna</button>'
            + '</li>').appendTo("#MovieUl");

    });
}



    
