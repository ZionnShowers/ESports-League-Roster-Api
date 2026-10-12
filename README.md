
Peer Reviewer: Callen Thomason
REview: Your model looks great, and your DTOS look good too. For the TransferDto isn't it only supposed to have one variable though? 

You got all the CRUD methods, they look good. 

The Controller and services look good, but it looks like you didn't handle any of the transfer business logic. Going to test it now. 

For the post I would have liked a seperate error message for gamertag still exists, and one for team is full. So the user knows what went wrong. The update request is not working for me. I'm getting a 200 ok, but it is not updating the database. The transfer updates the database correctly, but it fails to access teh business logic. I can transfer a player to the same team, should return a conflict.  