# CVT
Asp .Net MVC приложение. 
Список контактов с возможностью добавлять, редактировать и удалять записи, искать контакты по любому полю.

Использованы технологии:
-Net Core 3.1
-Entity Framework Core
-MS SQL Server
-AutoMapper
-bootstrap 4 + Fontawesome
-JQuery 3.3.1
-js plugins: DataTable, Datepicker, Inputmask

## Installation
При создании проекта использован подход CodeFirst.

Скопировать проект с репозитория.
Для запуска приложения необходимо создать пустую базу данных в MS SQL. 
Открыть проект в Visual Studio.
В appsettings.json указать в строке ConnectionString параметры подключения к созданной базе данных.
B командную строку PackageManagerConsole (с указанием проекта DAL) ввести команду Update-DataBase для создания структуры базы данных, используя существующие миграции.
Запустить приложение. 

Приложение автоматически сгенерирует начальные данные в базе данных.
