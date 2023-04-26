FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Wolverine.Mediator.RabbitMq.Receiver/Wolverine.Mediator.RabbitMq.Receiver.csproj", "Wolverine.Mediator.RabbitMq.Receiver/"]
RUN dotnet restore "Wolverine.Mediator.RabbitMq.Receiver/Wolverine.Mediator.RabbitMq.Receiver.csproj"
COPY . .
WORKDIR "/src/Wolverine.Mediator.RabbitMq.Receiver"
RUN dotnet build "Wolverine.Mediator.RabbitMq.Receiver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wolverine.Mediator.RabbitMq.Receiver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Wolverine.Mediator.RabbitMq.Receiver.dll"]
