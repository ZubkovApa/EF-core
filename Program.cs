using Microsoft.EntityFrameworkCore;

Console.WriteLine("Магазин спичек «Чирк»: проект запущен!");

using var db = new ShopContext();
db.Database.EnsureDeleted();   // удалить старую базу
db.Database.EnsureCreated();   // создать новую базу и таблицы
