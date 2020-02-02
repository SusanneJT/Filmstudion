
if (sessionStorage.getItem("ChosenStudio") != null) {
    $("#WarningBox").hide();
    $("#dropdownMenuButton").html(sessionStorage.getItem("ChosenStudio"));

}

filmstudio = new FilmStudio();
movie = new Movie();

$(document).ready(async function () {
    AllStudios();
    AllMovies();
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
}

async function AllMovies() {
    var movies = await movie.GetAll();
    $.each(movies, function (i) {

        $('<div class="mt-3 p-3"><div class="card h-100" style="width: 15rem;">'
            + '<img class= "card-img-top" src="/img/image-not-found.png" alt="Card image cap">'
            + '<div class="card-body d-flex flex-column">'
            + '<h5 class="card-title">' + movies[i].movieTitle + '</h5>'
            +  '<a href="#" class="btn btn-primary btn-sm mt-auto">Mer info</a>'
            + '</div>'
            + '</div></div>').appendTo("#MovieBox");

        console.log(movies[i].movieTitle);
        //$('<a class="dropdown-item" href="#" onclick="ChooseFilmStudio(\''
            //+ studios[i].studioName + '\')">' + studios[i].studioName + '</a > ').appendTo("#dropDownItems");
    });
}



    
