# Backend Test Task Readme

This repository contains a backend application that performs experiments with random prices and provides endpoints to retrieve button colors and prices based on a device token.

## Getting Started

To run the application, follow these steps:

1. **Set Up Configuration**:

    - Create in root directory `appsettings.json` file, using `appsettingExample.json`.
    - Configure the following settings:
        - `"Colors"`: An array of available colors.
        - `"PriceProbabilities"`: An array of `PriceProbability` objects, each containing a `Value` and `Probability`.
        - `"DefaultConnection"`: Connection string for the database.

2. **Build and Run**:

    - Use Visual Studio or your preferred IDE to build and run the application.

3. **API Endpoints**:

    - The application provides the following endpoints:
        - `GET /experiment/button_color?device-token={deviceToken}`: Returns the button color for the specified device token.
        - `GET /experiment/price?device-token={deviceToken}`: Returns the price for the specified device token.

## Code Structure

The application is structured as follows:

- **Models** (`KorliakovBackendTestTask.Models`):
    - Contains the `Client` class that represents a client with properties: `DeviceToken`, `Color`, and `Price`.

- **Repository** (`KorliakovBackendTestTask.Repository`):
    - Provides a generic repository interface `IRepository<T>` and its implementation `Repository<T>`. It includes methods for creating, reading, updating, and deleting objects of type `T`.

- **Utilities** (`KorliakovBackendTestTask.Utils`):
    - Contains the `IExperimentHelper` interface and its implementation `ExperimentHelper`. This class handles experiments with random prices and provides methods to retrieve button colors and prices based on a device token.

- **Controllers** (`KorliakovBackendTestTask.Controllers`):
    - Includes the `ExperimentController` with two GET endpoints:
        - `GetButtonColor`: Retrieves the button color for a specified device token.
        - `GetPrice`: Retrieves the price for a specified device token.

- **Schema** (`KorliakovBackendTestTask.Schema`):
    - Contains the `ExperimentResponse` struct that defines the structure of the API response.

## Usage

- The application uses a database to store client information. Ensure that the database connection string is correctly configured in `appsettings.json`.

- Experiments with random prices are conducted based on the defined probabilities in `PriceProbabilities`.

- To perform experiments, use the following endpoints:
    - `GET /experiment/button_color?device-token={deviceToken}`
    - `GET /experiment/price?device-token={deviceToken}`

## Additional Notes

- If an exception occurs during the experiment, the application logs a warning and returns the price with the highest probability.

- The application uses Dapper for better performance in database operations.

## Contributing

If you'd like to contribute to this project, please follow the standard GitHub fork and pull request workflow.

## License

This project is licensed under the [MIT License](LICENSE).