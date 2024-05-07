# HomesteadManager

.NET Blazor app for managing work and inventory associated with homesteading

`dotnet tool install -g dotnet-format`

`dotnet format`



# Local Dev instructions
Copy any `appsettings.json` to `appsettings.Development.json` for local config values.

The app runs as a static web app in Azure currently. To develop locally, download the Static Web App CLI

```
npm install -g @azure/static-web-apps-cli
```

Then start both the UI and the API. In another command line, run:
```
swa start http://127.0.0.1:<UI Port> --api-location http://127.0.0.1:<API Port>
```

This will proxy the network requests through port 4280 and mimic the same behavior as when the app runs in Azure Static Web App.