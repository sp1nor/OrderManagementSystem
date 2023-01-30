## Architecture

Microservices with clean architecture for order management system

## Catalog microservice which includes;
ASP.NET Core Web API application
REST API principles, CRUD operations

## Ordering Microservice
Implementing DDD, CQRS, and Clean Architecture

## Libs

Microsoft.Extensions.DependencyInjection.Abstractions, MediatR, Automapper, FluentValidation, MassTransit, Newtonsoft.Json, swashbuckle 

EntityFrameworkCore in Memory for development and EntityFrameworkCore.SqlServer for prod

RabbitMQ Event Driven Communication

## Logging
Serilog

## DB

MS SQL server, redis,, Postgresql, mongodb

## Tests
xUnit (catalog unit tests),
NetArchTest.Rules (ordering architecture tests)

## Installing
Clone the repository

system requirements 

* docker installed
* Memory: 4 GB
* CPU: 2

## Run

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d

## ElasticSerach & kibana
indexformat 

applogs-*

applogs-catalog-api-development-2023-01
applogs-order-api-development-2023-01