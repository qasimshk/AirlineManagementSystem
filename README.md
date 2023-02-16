# Airline Ticket Management System

![](https://github.com/qasimshk/AirlineManagementSystem/blob/master/System%20Design.png)

### Introduction
The airline management system project is developed to explain the concept of orchestration microservice patterns. As the name says this orchestrator service is responsible for the workflow of each asynchronous transaction. The payload sent by the gateway API is stored in the database and an entry is created. The created entry state is updated on each successful response sent by the consuming microservices. 

### xUnit vs NUnit comparision
xUnit and NUnit are both popular open-source unit testing frameworks for .NET. Both frameworks provide similar functionality and are designed to help developers write and run automated tests, but there are some differences between them. Here are some key differences between xUnit and NUnit:

- **Test Execution Model:** xUnit follows a more modern and intuitive test execution model than NUnit. NUnit uses the TestFixture attribute to define a group of test methods, while xUnit uses the class itself to represent a test fixture. xUnit also uses a more intuitive naming convention for test methods, as it requires the method name to describe the expected behavior.

- **Test Runner:** xUnit has a built-in test runner, while NUnit requires a separate test runner tool to be installed. The xUnit test runner is fast, reliable, and can be easily integrated into Visual Studio or other development environments.

- **Attributes and Assertions:** xUnit provides a simpler and more streamlined set of attributes and assertions compared to NUnit. xUnit includes a smaller set of attributes and assertions, which can help to reduce the learning curve for developers who are new to the framework.

- **Test Parallelism:** xUnit provides built-in support for running tests in parallel, which can help to reduce the time it takes to run large test suites. NUnit also supports parallel testing, but it requires additional configuration.

- **Test Data:** xUnit provides a more flexible and extensible way to provide test data using data-driven tests. NUnit provides a similar feature, but xUnit's data-driven tests are more flexible and easier to use.

Overall, both xUnit and NUnit are great options for writing and running automated tests in .NET. Developers should choose the framework that best fits their needs based on factors such as test execution model, test runner, attributes and assertions, test parallelism, and test data.


### Orchestrator vs Choreography patters in microservice architecture 
Both the Orchestrator and Choreography patterns are used in Microservices architecture to coordinate the interactions between services. Here are some advantages of using each pattern:

**Advantages of Orchestrator Pattern:**

- Centralized Control: In this pattern, a central service (Orchestrator) is responsible for coordinating the interactions between services. This provides a single point of control for managing business logic, and helps to ensure that business processes are executed consistently and reliably.

- Flexibility: Orchestrator Pattern allows for a more flexible service design. Services can be loosely coupled and do not need to be aware of each other. This makes it easier to add or remove services, and modify business processes without impacting other services.

- Easier to monitor: Since the Orchestrator service is responsible for coordinating interactions between services, it can also provide detailed monitoring and logging of business processes. This can help to identify issues and improve the overall performance of the system.

**Advantages of Choreography Pattern:**

- Decentralized control: In this pattern, services communicate with each other directly, without the need for a central orchestrator. This makes the system more flexible and less reliant on a single point of failure.

- Scalability: Since each service is responsible for its own actions, it is easier to scale the system by adding more instances of individual services. This makes the system more resilient and able to handle high loads.

- Simplicity: Choreography Pattern is easier to implement and maintain as services are not dependent on a central orchestrator. This makes the system more straightforward to develop and test.

In summary, both patterns have their own advantages and disadvantages. Orchestrator Pattern is more suitable for complex business processes that require a centralized control mechanism. Whereas, Choreography Pattern is more suitable for simpler processes that require a decentralized, scalable and more flexible design.

### CQRS Pattern
CQRS (Command Query Responsibility Segregation) is a pattern used in software engineering that separates the processing of commands and queries into separate components. The pattern provides a way to improve the scalability, performance, and flexibility of a system by handling the read and write operations in different ways.

The core idea of CQRS is to divide the system into two distinct parts: the Command side and the Query side. The Command side is responsible for handling write operations and modifying the state of the system, while the Query side is responsible for handling read operations and returning data to the user.

The Command side consists of commands, command handlers, and aggregates. Commands represent a request to perform an action or modify the state of the system. Command handlers receive and process the commands, and aggregates are responsible for maintaining the consistency of the system's data.

The Query side consists of queries, query handlers, and read models. Queries represent a request for data, and query handlers receive and process the queries. Read models are pre-calculated views of the data that are optimized for fast querying.

The CQRS pattern separates the read and write operations, which can result in better performance and scalability. It allows for the use of different data storage and processing technologies for the Command and Query sides, which can further improve the system's flexibility.

However, implementing CQRS can introduce additional complexity to a system, as it requires the development of separate components for handling the write and read operations. It is also important to ensure that the consistency of the data is maintained between the two sides.

Overall, CQRS is a powerful pattern that can be used to improve the performance, scalability, and flexibility of a system, particularly in cases where read and write operations have different requirements.


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

 

 

 

