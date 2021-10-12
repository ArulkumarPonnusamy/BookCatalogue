
Technology Used - .Net Core 5
Required Framework - Framework 4.8
Visual Studio - 2019

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
