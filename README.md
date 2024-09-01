
# MySoftwareSkills API

## Overview

The **MySoftwareSkills API** is a RESTful web service designed to manage skills information. This project showcases advanced software development skills, adhering to SOLID principles, design patterns, and utilizing modern technologies like MongoDB, .NET 6, and Swagger for API documentation.

## Technologies Involved

- **.NET 6**: The latest version of the .NET platform, offering improved performance, minimal API, and better integration with modern technologies.
- **C#**: A powerful, versatile language used for building the API, ensuring strong typing and efficient execution.
- **MongoDB**: A NoSQL database that provides flexibility in data modeling, allowing for efficient handling of unstructured data.
- **Swagger**: Integrated for API documentation, providing an interactive interface to test the API endpoints.
- **xUnit**: A testing framework for .NET, used to create unit tests for the application.
- **Moq**: A mocking library used in unit tests to simulate dependencies and isolate the behavior of the components under test.

## Motivation

The motivation behind this project is to demonstrate proficiency in software architecture and development by applying best practices such as SOLID principles and design patterns. This project is also aimed at highlighting the advantages of using MongoDB in scenarios where flexibility in data modeling is required.

## Applied Principles and Patterns

### SOLID Principles

- **Single Responsibility Principle (SRP)**: Each class in the project has a single responsibility. For example, `SkillService` is responsible for business logic related to skills, while `SkillRepository` handles data access operations.
- **Open/Closed Principle (OCP)**: The system is designed to be extendable without modifying existing code. New features can be added by extending existing classes.
- **Liskov Substitution Principle (LSP)**: Derived classes can be substituted for their base classes without altering the correctness of the program.
- **Interface Segregation Principle (ISP)**: The interfaces are kept small and specific to the client, ensuring that classes only implement methods that are necessary for them.
- **Dependency Inversion Principle (DIP)**: The project depends on abstractions (interfaces), rather than concrete implementations, allowing for more flexible and testable code.

### Design Patterns

- **Repository Pattern**: Used to abstract the data access logic, ensuring that the business logic in services does not depend on the underlying data source. This pattern also promotes testability by allowing the use of mock repositories in unit tests.
- **Dependency Injection**: Implemented via .NET’s built-in dependency injection framework to inject dependencies into controllers and services, promoting loose coupling and easier testing.

### Advantages of MongoDB

- **Flexibility in Data Modeling**: MongoDB’s document-based structure allows for storing complex data structures without the need for predefined schemas, making it easier to evolve the data model as requirements change.
- **Scalability**: MongoDB supports horizontal scaling through sharding, which can be essential for handling large datasets and high-throughput applications.
- **Performance**: MongoDB is optimized for high performance, particularly for read-heavy workloads and large datasets.

## Running the Application

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/MySoftwareSkills.git
   cd MySoftwareSkills
   ```

2. **Set up MongoDB**:
   - If you’re using a local MongoDB instance, make sure it’s running.
   - Configure the connection string in the `appsettings.json` file under the `MongoDbSettings` section.

3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

4. **Build the application**:
   ```bash
   dotnet build
   ```

5. **Run the application**:
   ```bash
   dotnet run
   ```

6. **Access the API**:
   - The API will be available at `https://localhost:5001`.
   - You can access the Swagger documentation at `https://localhost:5001/swagger`.

### Running Tests

To run the unit tests, use the following command:

```bash
dotnet test
```

This will execute all the tests in the solution and provide a report on their success or failure.

## Conclusion

The **MySoftwareSkills API** is a robust example of modern software development practices, utilizing .NET, MongoDB, and various design principles and patterns. It’s designed to be easily extendable, maintainable, and scalable, making it a great foundation for any application requiring a flexible and powerful API backend.
