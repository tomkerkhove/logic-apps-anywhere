FROM mcr.microsoft.com/dotnet/core/sdk:3.1.300 AS build
WORKDIR /src
COPY . .
RUN dotnet publish Codit.LogicAppsAnywhere.csproj --configuration release --output app

FROM mcr.microsoft.com/azure-functions/dotnet:3.0.13614-appservice as runtime
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \ AzureFunctionsJobHost__Logging__Console__IsEnabled=true
ENV AZURE_FUNCTIONS_ENVIRONMENT Development
ENV WEBSITE_HOSTNAME localhost
COPY --from=build /src/app /home/site/wwwroot