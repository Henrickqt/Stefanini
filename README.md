# Web Charge - Person Phones

![](https://github.com/Henrickqt/Stefanini/blob/main/assets/screen.png)

This project is a CRUD related to a contact list.

## Technologies

This project was developed using the following technologies:

- [Angular](https://angular.io/)
- [.NET](https://docs.microsoft.com/pt-br/dotnet/)
- [Entity Framework](https://docs.microsoft.com/pt-br/dotnet/framework/data/adonet/ef/)

## How to run

Clone the project and access its folder.

```bash
$ git clone https://github.com/henrickqt/Stefanini
$cd Stefanini
```

### Backend

The solution has a docker-compose project ready and configured to run the application, including provisioning an MS SQL instance for it.
The project relies on migration and therefore all data and structures will be created during startup.
If you have difficulties running the project with Docker, ignore it and run the “Examples.Charge.API” project, changing only the connection string and pointing to a valid database instance.

### Frontend

To start it, follow the steps below:
```bash
# Install dependencies
$ npm install

# Start the project
$ npm start
```
The app will be available in your browser at the address http://localhost:4200/.
