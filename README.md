# Airline Ticket Management System

![](https://github.com/qasimshk/AirlineManagementSystem/blob/master/System%20Design.png)

The airline management system project is developed to explain the concept of orchestration microservice patterns. As the name says this orchestrator service is responsible for the workflow of each asynchronous transaction. The payload sent by the gateway API is stored in the database and an entry is created. The created entry state is updated on each successful response sent by the consuming microservices. 

### Build Status 

| Service | Status |
| ------------- | ------------- |
| Airline Ticket System | [![Build status](https://dev.azure.com/CematixSolutions/CT%20Microservices/_apis/build/status/gateway-microservice-ci)](https://dev.azure.com/CematixSolutions/CT%20Microservices/_build/latest?definitionId=5) |

### How to install:
- Install [.Net 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) on the pc if required.
- Open solution in Visual Studio 2019.
- Create five databases in SQL server by these names: Customers, FlightDetails, ServiceState, Orders & Payments
- Navigate to the project opened in visual studio and expand the database folder to publish all five SQL projects one by one to create the schema in all five databases. Please make sure that the database project is pointing to the current database referenced by its name.
- Open seeds folder and execute the query file in flight details database in SQL server.
- For message bus, AMQP URL is required if you do not have rabbitMq installed on your local system then follow steps mentioned with alphabetical prefix.
> a) Open [Cloud AMQP](https://www.cloudamqp.com/) in the browser.
>
> b) Sign up and then sign in to your account.
>
> c) Once logged in click on the create new instance on the top right green button and <b>create an instance</b> with the <b>FREE plan (little lemur)</b>.
>
> d) Click on the created instance and copy the AMQP URL
- Go to airline management API project present in 01 Gateway folder and open appsettings.Development.json and paste AMQP URL in EventBusConnection value.
- Go to airline customers service in customers folder and open appsettings.Development.json. Update SQL connection string with the server name, username, password, and event bus connection.
- Go to airline flight details API in flight details folder and open appsettings.Development.json. Update SQL connection string with the server name, username, and password.
- Go to airline notification service in notifications folder and open appsettings.Development.json. Update event bus connection.
- Go to airline orchestrator service in the orchestrator folder and open appsettings.Development.json. Update SQL connection string with the server name, username, password, and event bus connection.
- Go to airline orders service in orders folder and open appsettings.Development.json. Update SQL connection string with the server name, username,  password, and event bus connection.
- Go to airline payment service in payments folder and open appsettings.Development.json. Update SQL connection string with the server name, username, password, and event bus connection.
- Right click on solution airline management system and click on set startup projects. Select Multiple projects and make airline.customers.service, airline.flightdetail.api, airline.management.api, airline.notification.service, airline.orchestrator.service, airline.orders.service & airline.payment.service actions as <b>start</b>
- Click start in visual studio.
  
### Project user guide:
- At project start, there will be one swagger web page and five console services
- You can see the list of countries and available flights by executing the first and second APIs.
- In the third API, please use any below mentioned country ISO codes to search a flight.
```
https://localhost:44314/api/Flight/Destination/ENG/To/NZL 
https://localhost:44314/api/Flight/Destination/NPL/To/AUS 
https://localhost:44314/api/Flight/Destination/AUS/To/UAE 
https://localhost:44314/api/Flight/Destination/NPL/To/POR 
https://localhost:44314/api/Flight/Destination/AUS/To/AUS 
https://localhost:44314/api/Flight/Destination/USA/To/NPL 
```
- To book a ticket copy the flight number from flight destination API response using any one of the above-mentioned combinations.
- Expand flight booking ticket post endpoint and paste the flight number, enter departure date, first name, last name & dummy email address, and click execute.
- Copy order number from booking ticket API response and paste it in flight order API to check its state.
- If the order state is complete it will generate a ticket number in response.
- Copy the ticket number and paste it into the flight ticket API to view the ticket.

### NuGet Packages

- [MassTransit](https://masstransit-project.com/getting-started/)
- [MediatR](https://github.com/jbogard/MediatR/wiki)
- [Fluent Validator](https://docs.fluentvalidation.net/en/latest/index.html)
- [Fluent Assertion](https://fluentassertions.com/introduction)
- [NSubstitute](https://nsubstitute.github.io/help/getting-started/)

 

 

 

