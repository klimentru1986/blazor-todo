FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview6 AS build
WORKDIR /app
COPY . ./

RUN dotnet build -c Release

FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview6 AS api
WORKDIR /app
COPY --from=build /app/ToDo.Api/out .
ENTRYPOINT ["dotnet", "ToDo.Api.dll", "--urls", "http://+:5001"]