# ProjectStore Api
Api for a group project ProjectStore.
At first this project used to be a MVC app but later my collegue made a Blazor app, so we used existing backend for a Blazor server-side with minor changes. My friend's client-side and mine server-side combined can be found here => https://github.com/MountainCat1/ProjectStoreBlazor

## Features:
- CRUD for products
- Authentication
-- Api verify if Username from input exists in a database and later compare if a hashed password match with one from the input. As a result from a previous operation JWT token is returned.
- Authorization
-- To authorise user for adding/deleting/updating product API decompose JWT token and retrieve token claims
- Middleware
-- Custom Exceptions for different erorrs
- Integration tests with mocked DB and fake filters

## What I have used:
- .NET 5
- EntityFramework ORM with:
-- AutoMapper
-- FluentApi
- CQRS architecture with MediatR
- FluentValidation
- XUnit tests with FluentAssertions and Moq

## Future plans:
- !--Now-- adding basket functionality!
- Learn Angular and combine! //TO DO
- Implement microservices after learning them! //TO DO
- Make a version with DDD architecture after figuring it out! //TO DO
- ✨ Implement new things which I would learn trough my journey with .NET✨/TO DO
