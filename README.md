# Airline Ticket Management System

![](https://github.com/qasimshk/AirlineManagementSystem/blob/master/System%20Design.png)

The airline management system project is developed to explain the concept of orchestration microservice patterns. As the name says this orchestrator service is responsible for the workflow of each asynchronous transaction. The payload sent by the gateway API is stored in the database and an entry is created. The created entry state is updated on each successful response sent by the consuming microservices. 

### Run in docker
To run application in docker use below mentioned command. Make sure to create all the databases using script files in seeds folder, for the first time. Use [http://localhost:8081/swagger/index.html](http://localhost:8081/swagger/index.html) to access it.
```
docker-compose up -d
```

#### Registration
```javascript
{
  "email": "test@example.com",
  "password": "Password123!"
}
```

#### Book ticket
```javascript
{
  "flightNumber": "XCF123",
  "departureDate": "2022-10-28",
  "firstName": "Jay",
  "lastName": "Cutler",
  "emailAddress": "test@example.com"
}
```

### Build Status 

| Service | Status |
| ------------- | ------------- |
| Airline Ticket System | [![Build status](https://dev.azure.com/CematixSolutions/CT%20Microservices/_apis/build/status/gateway-microservice-ci)](https://dev.azure.com/CematixSolutions/CT%20Microservices/_build/latest?definitionId=5) |

### How to install:
- Install [.Net 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) on the pc if required.
- Open solution in Visual Studio.
- Navigate to the project opened in visual studio and expand the database folder open seeds folder and execute all three scripts files one by one to setup all six databases.
- For message bus, AMQP URL is required if you do not have rabbitMq installed on your local system then follow steps mentioned with alphabetical prefix.
> a) Open [Cloud AMQP](https://www.cloudamqp.com/) in the browser.
>
> b) Sign up and then sign in to your account.
>
> c) Once logged in click on the create new instance on the top right green button and <b>create an instance</b> with the <b>FREE plan (little lemur)</b>.
>
> d) Click on the created instance and copy the AMQP URL
- Go to airline management API project present in 01 Gateway folder and open appsettings.Development.json. Update SQL connection string with the server name, username, password, and event bus connection.
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
- First create an account using registration service
- Copy the token from registration response, click on <b>authorize</b> button in swagger at top right and paste the token in the value. <b>Don't add word bearer in the beginning of the token</b>.
- Token is valid for 5 minutes only. To refresh it, copy token and refresh token from registration or login api response and paste it in refresh token input body.
- You can see the list of countries and available flights by executing the first and second APIs.
- In the third API, please use any below mentioned country ISO codes to search a flight.
```
https://localhost:44314/api/flight/destination/ENG/To/NZL 
https://localhost:44314/api/flight/destination/NPL/To/AUS 
https://localhost:44314/api/flight/destination/AUS/To/UAE 
https://localhost:44314/api/flight/destination/NPL/To/POR 
https://localhost:44314/api/flight/destination/AUS/To/AUS 
https://localhost:44314/api/flight/destination/USA/To/NPL 
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
- [Microsoft Identity](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.identity?view=aspnetcore-6.0)

 

 

 

