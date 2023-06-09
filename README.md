# DBServer

DBServer - это сервер с базой документов написаный с помощью ASP.NET и Entity Framework(SQLite).

**Для подключения к серверу написан клиент - [DBClient](https://github.com/paket17/DBClient).**

Клиент-серверное приложение с базой данных. Взаимодействие с базой данных происходит на сервере. Клиент с сервером общаются с помощью http запросов.

**В базе данных есть таблица договоров, которая содержит:**
* Имя договора.
* Номер договора.
* Дату создания записи в БД.
* Дату последнего изменения записи в БД.

**Возможности сервера:**
* Показывает записи в БД.
* Добавляет записи в БД.
* Изменение записей в БД.
* Удаление записей из БД.

База данных появляется после первого запуска и находится в папке с программой.

Для настройки подключения к серверу и базе данных можно воспользоваться appsettings.json, который так же лежит в папке с программой.

**В релизе можно посмотреть на программу, так же там уже есть тестовая база с документами.**
