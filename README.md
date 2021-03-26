## Welcome To the BE-HAPI Codebase

Thank you for taking the time to complete this coding assessment as part of your interview with Safarinow.com / Travelstart

Your job, should you choose to accept it, is to complete as many of the tasks set out below.

This code structure and task set is a relavent representation of what we do.

# Before you start:
You will need a minimum of 1 hour of your time. But if you need more time feel free to submit by before 5pm on the day you received the assessment.
You may not get through all of it, hey thats ok. Do your best. Create a PR you are happy to submit to us. If you get stuck, feel free to mock or stub out methods in order to progress.


Ready? Lets go:

# Setup & Requirements
- You will need a Github Account
- An internet connection
- .Net core 5.0, VS Code or Visual Studio (>= 16.8.5)
- You will need Docker.
- Comment your code and
- Stub methods you need to move on to the next task if you need to.

# TODO

- Read in the accommodation records from this JSON end point : https://sncdn.com/hapi/products.json
	- Save using a BackingStoreService

- Create a search endpoint /search
  - Implement a search request with fields you deem appropriate

- Create an authentication end point /user/
	- Create
		- RegisterUser /user/register and
			- LoginUser /user/login
		- Save a user via store BackingStoreService

- Implement JWT token authorization
	- Authorize the Search end point using the Bearer token

- Create unit tests for the Search and Authentication end points. Use mocking where possible.
- Fix any issues with the current code.


# TODO Extras
- Change the backing store to a Mongo DB implementation.
- Update the solution to run within a docker container with Mongo inside *use port 6795 externally*
- Create a basic search page using MVC or any front end framework of your choice (VueJs/Angular)
- Add a Github Actions that fail when business logic unit tests fail (not integration tests).


# GLHF (Good Luck and Have Fun)!
