<h1 align="center">Hi there, I'm <a href="https://vk.com/dikiy_marketolog/" target="_blank">VelzDev Studio</a> <img src="https://github.com/blackcater/blackcater/raw/main/images/Hi.gif" height="32"/></h1>

<h3 align="center"> Lazy programmer, a pentester, and a freelancer from Russia</h3>

## Лирическое отступление
Данное приложение работало бы быстрее, асинхроннее и было бы в разы лучше в дизайне, будь оно выполнено на ASP.Net

Но WinForms .Net Framework в целом тоже рабочая штука

## Итак, Настройка

`[app.config]` Заменяем в данном блоке `connectionString` на свою строку подключения к базе данных:
```xml app.config
<connectionStrings>
    <add name="YourConnectionStringName" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=jewellerShop;Integrated Security=True;Pooling=False"
      providerName="System.Data.SqlClient" />
    <add name="Jeweller.Properties.Settings.jewellerShopConnectionString"
      connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=jewellerShop;Integrated Security=True;Pooling=False"
      providerName="System.Data.SqlClient" />
</connectionStrings>
```

> Оу, не забудьте перед этим запустить свой SQL-сервер :)

## Все, программа работает и может быть запущена.

На старте мы имеем аккаунт суперпользователя: Логин `root` пароль `root`

С него получаем доступ к админскому аккаунту

> Можешь его удалить. Попробуй, давай)
> 
> Никуда он не удалится, просто сменит свой `Id`
> 
> Пока код не трогаешь, можешь не бояться за утрату суперпользователя

С этого аккаунта можно создать новых пользователей, товары, категории. Просмотреть список продаж.

> P.S. Редактирование и удаление `правой кнопкой мыши`

## По дизайну: я честно старался

Но с учетом того, что это не сайт, и работает на фиксированных объектах без разметки, имея только теги...

![img](https://private-user-images.githubusercontent.com/74038190/240825300-17f8a48d-4ab3-4e58-bd5a-bf181f4c3d90.gif?jwt=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3MDQ4NDgyNDQsIm5iZiI6MTcwNDg0Nzk0NCwicGF0aCI6Ii83NDAzODE5MC8yNDA4MjUzMDAtMTdmOGE0OGQtNGFiMy00ZTU4LWJkNWEtYmYxODFmNGMzZDkwLmdpZj9YLUFtei1BbGdvcml0aG09QVdTNC1ITUFDLVNIQTI1NiZYLUFtei1DcmVkZW50aWFsPUFLSUFWQ09EWUxTQTUzUFFLNFpBJTJGMjAyNDAxMTAlMkZ1cy1lYXN0LTElMkZzMyUyRmF3czRfcmVxdWVzdCZYLUFtei1EYXRlPTIwMjQwMTEwVDAwNTIyNFomWC1BbXotRXhwaXJlcz0zMDAmWC1BbXotU2lnbmF0dXJlPThmZTY2MDEyMTE2NDFlYTE1YTk3ZmI5YWNlMDcyYzljY2Q5Mjc0NmU3YmRlMTI1OTg1MmVlZWJhYmJjODdkZWQmWC1BbXotU2lnbmVkSGVhZGVycz1ob3N0JmFjdG9yX2lkPTAma2V5X2lkPTAmcmVwb19pZD0wIn0.tRcBLTF56NS4YpIwB1M7INouhc8zoXYOBP_opYY5M3M)

> Честно, 2 дня думал только над тем, как можно реализовать относительно визуальный каталог, работая через статичные объекты

*приношу свои извинения :)*

<h1 align="center">Your's sincerely,  <a href="https://vk.com/dikiy_marketolog/" target="_blank">VelzDev Studio</a> <img src="https://github.com/blackcater/blackcater/raw/main/images/Hi.gif" height="32"/></h1>
