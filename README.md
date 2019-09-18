# Guidelines on what to do:
 1. Get main char's data to populate partyinfo.json.
 2. Create attribs for CharacterInfo.(Name,gender,*LEVEL*(lv up endpoint),alignment, rumours, war fame)
 3. Create SVN smalltalks utilities (SVNRPG SmallTalks).
 4. Treat Exceptions.
 5. Implement Character sheet creation and pdf export
 6. Create a crawler to redeem data from roll20 website.
 7. Create a crawler for d&dBeyond:
   #### Endpoints:
    https://www.dndbeyond.com/search?q=giant%20owl&f=monsters&c=monsters search for monsters
    https://www.dndbeyond.com/monsters/monster get monster


### About the RestAPI
1. Populate `UserContext.cs` and `MySettings.cs` with whatever you need.
2. Remember to register everything else you create and/or need @ `Startup.cs`
3. If needed, install `Take.CustomerSuccess.Extensions` and register the needed services
