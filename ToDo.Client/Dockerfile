
FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview6 AS client
WORKDIR /app

COPY ./ToDo.Client ./ToDo.Client/
COPY ./ToDo.Models ./ToDo.Models/

CMD dotnet run --project ToDo.Client ./ToDo.Client/    
