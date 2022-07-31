# HealthBuilder
HealthBuilder is a full-stack web application that allows people to control their 
training regime and diet in one place.

# Motivation
Keeping yourself healthy is a complicated task and the success in this field is determined by sleep, 
training and eating. This solution offers great amount existing diets and excercises which can be used 
to compose a personalized routine to a put the user on track to a healthier and tastier lifestyle.

# Tech Stack
* ASP.NET Core
* MSSQL
* EF Core
* React
* Redux

# System Architecture
HealthBuilder is a full-stack application that is based on the client-server architecture. 
The diagram below demonstrates the high-level architecture of the system.

![This is an image](https://user-images.githubusercontent.com/57729718/177005358-e9452fd0-4cd8-43fd-981f-a6af396456d0.png)

This architecture fully meets the application requirements and will provide efficient operation. 
Each component is isolated and independent from the other, giving the system the necessary level of maintainability.
The data flows striclty from one component in the pipeline to the next.

# User Stories( Functionality )
- [x] User can register and login.
- [x] User can create dishes.
- [x] User can create excercises.
- [x] User can schedule dishes and excercises.
- [x] User can view publicly available dishes, excercises.
- [x] User can make his/her dishes and excercises private.
