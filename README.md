# RabbitMQCalculator

RabbitMQCalculator is the most over engeneering calculator you will ever see.

# Tools and techniques applied:

- ASP.NET Core Web API project
- ASP.NET Core Worker Service
- Entity Framework Core
- RabbitMQ
- Vertical Slice Architecture

# How to run

First, to run this project you need to have the programs below installed:

- .NET 6 
- Docker

<b>To run the project, follow the steps:</b>

1. Open Command Prompt (or Terminal on Linux) 

2. Inside root solution folder, type: <br>
	
	<mark> docker-compose up --d --force-recreate

3. Run the project <br>
	
	3.1. If you have a Visual Studio version installed, open solution and configure to run multiple projects <br>

	3.2. Otherwise, still in solution root folder, type the commands :
	- <b> dotnet run -project RabbitMQCalculator.WebApi.csproj </b>
	- <b> dotnet run -project RabbitMQCalculator.Workers.csproj </b>


4. If all previous steps got success:
	- The WebApi is running at localhost:5001/swagger
	- The RabbitMQ console is running at localhost:15672 (user: guest, password: guest)

