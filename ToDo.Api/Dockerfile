FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview6 AS api
WORKDIR /app
COPY . ./

CMD dotnet run -c Release --urls="http://+:5001" --project ToDo.Api ./ToDo.Api/    
