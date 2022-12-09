
Technology Used - .Net Core 5
Required Framework - Framework 4.8
Visual Studio - 2019 or latest version

Introduction:
In this project, I have covered clean architecture practically. Clean architecture is a software architecture that helps us to keep an entire application code under control. The main goal of clean architecture is the code/logic, which is unlikely to change. It has to be written without any direct dependency. This means that if I want to change my development framework OR User Interface (UI) of the system, the core of the system should not be changed. It also means that our external dependencies are completely replaceable.

What is Clean Architecture:
Clean architecture has a domain layer, Application Layer, Infrastructure(Persistance) Layer, and Framework (API) Layer. The domain and application layer are always the center of the design and are known as the core of the system. The core will be independent of the data access and infrastructure concerns. We can achieve this goal by using the Interfaces and abstraction within the core system, but implementing them outside of the core system.

Layer In Clean Architecture:
Clean architecture has a domain layer, Application Layer, Infrastructure Layer, and Presentation Layer. The domain and application layer are always the center of the design and are known as the core of the system.

In Clean architecture, all the dependencies of the application are Independent/Inwards and the Core system has no dependencies on any other layer of the system. So, in the future, if we want to change the UI/ OR framework of the system, we can do it easily because all the other dependencies of the system are not dependent on the core of the system.

Domain Layer
The domain layer in the clean architecture contains the enterprise logic, like the entities and their specifications. This layer lies in the center of the architecture where we have application entities, which are the application model classes or database model classes, using the code first approach in the application development using Asp.net core these entities are used to create the tables in the database.

Application Layer
The application layer contains the business logic. All the business logic will be written in this layer. It is in this layer that services interfaces are kept, separate from their implementation, for loose coupling and separation of concerns.

Infrastructure Layer (Persistance Layer)
In the infrastructure layer, we have model objects we will maintain all the database migrations and database context Objects in this layer. In this layer, we have the repositories of all the domain model objects.

Presentation Layer
In the case of the API Presentation layer that presents us the object data from the database using the HTTP request in the form of JSON Object. But in the case of front-end applications, we present the data using the UI by consuming the APIS.

Advantages of Clean Architecture
The immediate implementation you can implement this architecture with any programming language.
The domain and application layer are always the center of the design and are known as the core of the system that why the core of the system is not dependent on external systems.
This architecture allows you to change the external system without affecting the core of the system.
In a highly testable environment, you can test your code quickly and easily.
You can create a highly scalable and quality product.

Swagger UI:
-----------
https://localhost:44356/swagger/index.html



Get All the Catalogues:
----------------------
GET - https://localhost:44356/api/v1/catalogues



Create New Catalogue:
---------------------
POST - https://localhost:44356/api/v1/catalogues

{
  "Title": "bookCatalogue",
  "Author": "Arul",
  "ISBN": "1234567891233",
  "PublicationDate": "2021-10-12T07:13:21.359Z"
}


Update Catalogue:
-----------------
PUT - https://localhost:44356/api/v1/catalogues/1234567891233

{
  "Title": "bookCatalogue",
  "Author": "Arul",
  "ISBN": "1234567891233",
  "PublicationDate": "2021-10-12T07:13:21.359Z"
}



Delete Catalogue:
-----------------
DELETE - https://localhost:44356/api/v1/catalogues/1234567891233



Search Catalogue By ISBN:
------------------------
GET - https://localhost:44356/api/v1/catalogues/1234567891233



Search Catalogue By Title & Author:
----------------------------------
GET - https://localhost:44356/api/v1/catalogues/title/bookCatalogue/author/Arulkumar
