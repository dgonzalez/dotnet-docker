# Use the standard Microsoft .NET Core container
FROM gcr.io/google-appengine/aspnetcore:2.0.0
 
# Copy our code from the "/src/MyWebApi" folder to the "/app" folder in our container
WORKDIR /app
COPY . .
 
ENV ASPNETCORE_URLS http://*:8080
EXPOSE 8080
 
# Restore the necessary packages
RUN dotnet restore
 
# Build and run the dotnet application from within the container
ENTRYPOINT ["dotnet", "run"]
