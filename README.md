FlexForms is a dynamic, metadata-driven form generation platform built with .NET 9. It empowers developers and admins to generate complex, pre-configured user interfaces using stored procedures, dynamic parameters, and reusable component libraries — without writing UI code manually.

Project Structure

DynamicFlow.UI (Razor Class Library): Contains Blazor components that are dynamically generated at runtime.

DynamicFlow.TestUI (Blazor Web App): Hosts the front-end logic and renders UI from API-driven metadata.

DynamicFlow.API (ASP.NET Web API): Supplies metadata, configurations, and dynamic content via REST endpoints.

DynamicFlow.BackOffice (ASP.NET MVC): A back-office configuration interface for defining database logic, parameters, and UI mapping.

