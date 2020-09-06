# forenade-filmstudio-api
### För inlämningsuppgiften: Filmstudion

I detta påhittade uppdrag så ska ni jobba för [Sveriges Förenade Filmstudios](https://www.filmstudio.se) (SFF) och utveckla ett API som filmstudion kan anropa för att beställa film.

SFF fungerar så att lokala filmintresserade bildar föreningar som ingår i SFF som är förbundet för hela Sverige, SFF har rätt från filmbolagen att låna ut ett visst antal exemplar av olika filmer till dom lokala föreningar som sedan visar dem på exempelvis kulturbiograferna i sina städer. Förut skedde detta via blanketter och dyr transport av fysiska filmrullar - men idag sker detta såklart digitalt. 

Det som inte hunnit digitaliseras är dock reglerna för hur många filmer som får lånas ut samtidigt, så SFF önskar nu att du tar fram ett API för att hålla koll på vilka filmer som finns tillgängliga för föreningarna att låna digitalt!

### Krav:
* Din API lösning ska vara byggt i ASP.NET (Länkar till en externa sida.) Core, version 3.0 eller 3.1.
* I API:et ska resursen filmer finnas...
* Det ska gå att lägga till en ny film
* Det ska gå att ändra hur många studios som kan låna filmen samtidigt
* Det ska gå att markera att en film är utlånad till en filmstudio, man får inte låna ut den mer än filmen finns tillgänglig (max-antal utlåningar)
* Det ska såklart även gå att ändra så att filmen inte längre är utlånad till en viss filmstudio
* En annan resurs som ska finnas är filmstudios
* Det ska gå att registrera en ny filmstudio
* Det ska gå att ta bort en filmstudio
* Det ska gå att byta namn, och ort på en filmstudio
* Via API:et ska man kunna få fram vilka filmer som studion har lånat
* När filmstudiorna har visat filmerna rapporterar dem in ett betyg och ibland även en triva på film
* Det ska gå att skapa ett nytt trivia objekt som håller koll på en liten anekdot för en viss film (Kan vara en string, kolla på IMDB för exempel)
* Det ska gå att ta bort inskriven trivia
* Det ska också gå att rappotera in ett betyg mellan 1 och 5, det är viktigt att komma ihåg vilken studio som gav betyget för vilken film.
