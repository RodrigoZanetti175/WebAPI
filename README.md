DockerCompose to be inserted

version: '3.8'

services:
  # ASP.NET Core Application
  webapi:
    image: webapi:latest  # Use your custom image here (or you can build from source)
    build: 
      context: .  # Adjust to your application directory
      dockerfile: Dockerfile  # Your Dockerfile for the ASP.NET application
    container_name: webapi
    ports:
      - "5000:80"  # Expose port 5000 on the host to port 80 inside the container (default HTTP port)
    environment:
      - ASPNETCORE_ENVIRONMENT=Development  # You can change to 'Production' for production environment
      - DB_CONNECTION_STRING=Server=mysql;Database=meu_banco;User=usuario;Password=senha_usuario;  # Connection string to MySQL
    depends_on:
      - mysql  # Make sure MySQL service is available before starting ASP.NET service

  # MySQL Database
  mysql:
    image: mysql:latest
    container_name: meu-mysql
    environment:
      MYSQL_ROOT_PASSWORD: senha_segura
      MYSQL_DATABASE: meu_banco
      MYSQL_USER: usuario
      MYSQL_PASSWORD: senha_usuario
    ports:
      - "3306:3306"  # Expose MySQL default port 3306
    volumes:
      - mysql_data:/var/lib/mysql  # Persist MySQL data between container restarts

# Volumes to persist data
volumes:
  mysql_data:
    driver: local
