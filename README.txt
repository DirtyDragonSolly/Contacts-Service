CRUD Список контактов в луковой архитектуре

Инструкция по запуску:
	Перед тестом в папке со слоем Апи выполнить команду:

	docker compose up -d

	После этого в корневой папке со всеми слоями выполнить следующие команды:

	dotnet ef migrations add Init -s .\Contacts.API\ -p .\Contacts.Data\
	dotnet ef database update -s .\Contacts.API\ -p .\Contacts.Data\

	эти команды создадут контейнер с базой данных в докере и всё будет работать