# hockey-game
 Hockey Game is a demo project, with simple use cases around the Montréal Hockey Team:
 - get a team from year
 - add a new player
 - set a player as captain
 

## Architecture 

Hockey Game is split in a REST API in .Net 6 and a SPA in Angular 13.
The API is build in clean architecture : 
- HockeyGame.Angular : the angular project
- HockeyGame.API : all about the API (= how to expose business services)
- HockeyGame.Application : the business services
- HockeyGame.Application.Tests : the business service tests using XUnit
- HockeyGame.Infrastructure : the infrastructure dependencies of the business services like the database. As it's a simple demo, I choose a InMemory database
- HockeyGame.Core : All interfaces and Entities of the project

## Installation

### Launch the API
Go to HockeyGame.Api and enter this command :
```sh
dotnet run
```


### Launch the SPA
Go to HockeyGame.Angular and enter this commands in a terminal : 
```sh
npm install
ng serve
```


### Misc
Manuel testing is possible via the postman collection (HockeyGame.Api/Hokey Game.postman_collection.json).


