Перед тестом в папке со слоем Апи выполнить команду:

docker compose up -d --force-recreate --no-deps --build postgres

После этого в корневой папке со всеми слоями выполнить следующие команды:

dotnet ef migrations add Init --project Contacts.Data --startup-project Contacts.API
dotnet ef database update --project Contacts.Data --startup-project Contacts.API

эти команды создадут контейнер с базой данных в докере и всё будет работать