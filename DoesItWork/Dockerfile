FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DoesItWork/DoesItWork.csproj", "DoesItWork/"]
RUN dotnet restore "DoesItWork/DoesItWork.csproj"
COPY . .
WORKDIR "/src/DoesItWork"
RUN dotnet build "DoesItWork.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoesItWork.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoesItWork.dll"]
