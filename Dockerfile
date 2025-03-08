# Use the official .NET runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EventRegistration/EventRegistration.csproj", "EventRegistration/"]
RUN dotnet restore "EventRegistration/EventRegistration.csproj"

# Copy and build the app
COPY . .
WORKDIR "/src/EventRegistration"
RUN dotnet publish -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EventRegistration.dll"]
