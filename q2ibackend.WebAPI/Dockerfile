#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["q2ibackend.WebAPI/q2ibackend.WebAPI.csproj", "q2ibackend.WebAPI/"]
RUN dotnet restore "q2ibackend.WebAPI/q2ibackend.WebAPI.csproj"
COPY . .
WORKDIR "/src/q2ibackend.WebAPI"
RUN dotnet build "q2ibackend.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "q2ibackend.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "q2ibackend.WebAPI.dll"]