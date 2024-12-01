# PiistechCodingTest
So far i have completed few part of the task. I was focusing on coding architecture that's why i couldn't complete the task. But i hope you will like this architure. Let explain what i have done so far:

1. I have follow CLEAN architecture for this project.
2. I have created API for Product and User using Mediator.
3. Then create a WEB application.
4. I have called all the api from the web application and then show it in the browser

What was my Plan: Before start the task i was planning to chose this architeture and trying to do it but unfotunately time has running the end. so my plan is:
1. I have create a class for validator. i wil use Abstruct Validator that is .net build in function property validation
2. Create rest of the feature using API
3. Then call all those api from web application
4. Authenticate the API with JWT token

Benifit: Some sort of benifit for this acchitectures are;
1. Easy to manage the code
2. Can extend the project without modifying the architecture
3. API can be used from external project

How to run the project:
1. At first change the connection string of bd according to your server
2. select the Web API project (Piistech.Ecommerce.API) as start up Project
3. In package manager console set the Intrastructure (Piistech.Ecommerce.Infrastructure) as Default project
4. Then run the command
   1. add-migration "MigrationName"
   2. update-database
The   chose multiple project ( PiistechEcommerce.Web and Piistech.Ecommerce.API) for start up project
