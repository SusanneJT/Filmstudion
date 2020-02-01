


const request = async () => {
    //this.URL = "https://localhost:44393/api/filmstudios";
    return fetch("https://localhost:44393/api/filmstudios").then(response => response.json());
}


$(document).ready(async function () {
    var studios = await request();
    $.each(studios, function (i) {
        $('<a class="dropdown-item" href="#" onclick="ChooseFilmStudio(\''
            + studios[i].studioName + '\')">' + studios[i].studioName + '</a > ').appendTo("#dropDownItems");
    });
        
});

function ChooseFilmStudio(studioName) {
    console.log(studioName);
    sessionStorage.setItem("ChosenStudio", studioName);
    $("#dropdownMenuButton").html(studioName);
}

    
