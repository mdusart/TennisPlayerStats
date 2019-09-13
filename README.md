# TennisPlayerStats
For testing i use a programm name Postman which testing webservices
I enter this URL : http://localhost:51375/TennisPlayerService.svc/Player/52 you selected GET or DELETE
To select all player it's http://localhost:51375/TennisPlayerService.svc/Players
You can also enter in visual studio in TennisPlayerService.svc you right click and click on "Display in browser"
When you are in browser enter the URL but to test DELETE you have to use postman. I tested like this.

For unit tests, those testing the exceptions do not pass because you have to use a mock for WebOperationContext, i know the solution but i
don't have enought time to develop it. With the mock all the unit test passed.
