# [Visit the wiki](https://github.com/Carepatron/Carepatron-Test-Full/wiki)

#In new terminal Go to /api/
dotnet restore
dotnet build
dotnet run

#Requirements

1. Create a client
⋅⋅* All fields are required
⋅⋅* Send an email and sync documents after a client is created (using the mock repositories provided)
2. Edit a client
⋅⋅* All fields are required
⋅⋅* If the email has changed, send an email and sync documents after a client is updated (using the mock repositories provided)
3. Search for a client
⋅⋅* Searching in the "search field" should filter the list of clients by their first or last name
⋅⋅* Example: John Stevens and Steven Smith should both show up if a user searches "steven"
⋅⋅* Example: John Stevens should show up if a user searches "john"
