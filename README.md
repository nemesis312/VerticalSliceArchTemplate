# Vertical Slice Architecture Template with CQRS

## Project Overview

This repository contains a template for a .NET Core application implementing Vertical Slice Architecture integrated with the Command Query Responsibility Segregation (CQRS) pattern. Designed to promote clean code principles, this template provides a scalable and maintainable structure for building complex applications. It is ideal for developers looking to implement domain-driven design (DDD) concepts in their projects.

## Key Features

- **Vertical Slice Architecture**: Organizes code around features instead of technical concerns, enhancing modularity and cohesion.
- **CQRS Implementation**: Separates read and write operations for better scalability and clarity, using MediatR for handling commands and queries.
- **Domain-Centric Design**: Focuses on the business domain, facilitating the implementation of complex business logic and rules.
- **Service Layer**: Includes examples of domain services that encapsulate core business logic, demonstrating how to structure and utilize these services effectively.
- **Data Access**: (Optional) Demonstrates both direct database access and repository patterns, giving flexibility in handling data persistence.
- **Time Conversion Feature Example**: Comes with a built-in example feature for converting time, showcasing the practical use of the architecture in real-world scenarios.

## Getting Started

To use this template, clone the repository and customize the feature slices according to your application's requirements. The project is structured to allow easy addition and modification of features, services, and data access methods.

### Prerequisites

- .NET Core 7 SDK
- An understanding of CQRS and domain-driven design principles

### Installation

1. Clone the repository:
   ```
   git clone [https://github.com/nemesis312/VerticalSliceArchTemplate]
   ```
2. Navigate to the project directory and restore the dependencies:
   ```
   cd [project-name]
   dotnet restore
   ```
3. Run the application:
   ```
   dotnet run
   ```

## Contributing

Contributions to enhance this template are welcome. Please read our contributing guidelines and submit pull requests or issues as needed.

## License

This project is licensed under the [MIT License](LICENSE).
