# Nozama


### Requirements 
- Install `.Net core` module.
- Install and configure `Apache` server.

You can find the steps to do this [here](https://www.c-sharpcorner.com/article/how-to-deploy-net-core-application-on-linux/)


### Mode of use

Open a terminal in root directory of the project:

```
dotnet ef migrations add AddTables
dotnet ef database drop
dotnet ef database update
```

To execute the project:

```
dotnet run
```

