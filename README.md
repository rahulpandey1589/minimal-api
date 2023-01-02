# Minimal API Playground - .Net 6

This is a playground to test Minimal feature provided in .Net 6.

## Depedencies
The code available in this repository depends on following items

| Package                	 | Version 	 |
|-------------------------|-----------|
| .Net                   	 | 6       	 |
| Carter                 	 | 6.0.0   	 |
| Swashbuckle.AspnetCore 	 | 6.2.3   	 |
| Polly.Extensions.Http  	 | 3.0.0     |
| Entity Framework  	     | 7.0.0     |



## Projects

Minimal API

This project implements a simple Minimal API which includes OpenAPI(Swagger) documentation and UI.

* Call an external API automatically in background and save the response in `IMemoryCache` utilty provided by framework.The details of Background Service is written in `BackgroudJobs.cs` class.
* User endpoint is exposed which fetch all the data. It first check in cache, if not available, it again makes a call to external endpoint.
* With the help of `ICarterModule` Nuget package, all the endpoints are removed from `Program.cs` and is moved to specific folder. Add following lines in `Program.cs` to register Carter Module
``` 
     builder.Services.AddCarter();
         // other depedencies to register
     
     app.MapCarter();
```
* `IHttpClientFactory` is used to define root endpoints and other important details used to call an external API.
