# Inventory APP

> Inventory system for small business and at home uses.

## Frontend built With

- [Angular](https://angular.io/cli) - The web framework used
- [PrimeNg](https://primefaces.org/primeng/showcase/#/) - UI library

### Installing frontend

Get git source code :

```sh
$ git clone https://github.com/ronnysuero/InventoryApp.git
$ cd frontend
```

Download dependencies

```sh
$ npm install
```

Start the app:

```sh
$ ng serve
```

Api Url by default is `http://localhost:14228/`, but if you need to change it, you need to go inside `frontend/src` folder and there is a file called config.json. This file contains all the configurations if you need change any else.

```json
    "config": {
      "active": "dev",
      "apps": [
        {
          "key": "dev",
          "api": "http://localhost:14228/"
        }
      ],
      "AuthConfig": {
        "TokenName": "tokeninventoryapp"
      }
    }
```

## Backend built With

- [NetCore](https://docs.microsoft.com/en-us/dotnet/) - The webapi framework used

### Server

Connection String is already added, but if you need to change it, you need to go inside backend folder and there is a file called appsettings.json. This file contains all the configurations if you need change any else.

```json
    "ConnectionStrings": {
      "Local": "Server=.;Database=DbInventory;Trusted_Connection=True;MultipleActiveResultSets=True",
      "ActiveConnection": "Local"
    }
```

AutoMigrations is already enabled by default, so you just need startup the project and that's it.

```
app.UseSqlServerAutoMigrations();
```

## Credentials
- Username: sa
- Password: 123456

## Meta

Ronny Zapata – ronnysuero@gmail.com

## License

This software is licensed under the [MIT](https://github.com/nhn/tui.editor/blob/master/LICENSE) ©
