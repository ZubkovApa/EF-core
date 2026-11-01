using Microsoft.EntityFrameworkCore;

Console.WriteLine("Магазин спичек «Чирк»: проект запущен!");

using var db = new ShopContext();
db.Database.EnsureDeleted();   // удалить старую базу
db.Database.EnsureCreated();   // создать новую базу и таблицы
Console.WriteLine("=== Шаг 3 ===");

// 1. Создаем покупателей
var ivan = new Customer { Name = "Иван Петров", Phone = "+7 900 111-22-33", City = "Омск" };
var olga = new Customer { Name = "Ольга Смирнова", Phone = "+7 900 444-55-66", City = "Томск" };
var petr = new Customer { Name = "Петр Сидоров", Phone = "+7 900 777-88-99", City = "Омск" };
var anna = new Customer { Name = "Анна Иванова", Phone = "+7 900 123-45-67", City = "Москва" }; // У неё не будет заказов
var sergey = new Customer { Name = "Сергей Смирнов", Phone = "+7 900 987-65-43", City = "Томск" };

db.Customers.AddRange(ivan, olga, petr, anna, sergey);

// 2. Создаем товары (минимум 5 видов)
var kaminnie = new Product { Name = "Каминные", Price = 150m, MatchesInBox = 50, Stock = 100 };
var ohotnichyi = new Product { Name = "Охотничьи", Price = 90m, MatchesInBox = 40, Stock = 200 };
var gost = new Product { Name = "ГОСТ", Price = 50m, MatchesInBox = 60, Stock = 500 };
var vodostoykie = new Product { Name = "Водостойкие", Price = 120m, MatchesInBox = 30, Stock = 50 };
var hosta = new Product { Name = "Хозяйственные", Price = 30m, MatchesInBox = 100, Stock = 1000 };

db.Products.AddRange(kaminnie, ohotnichyi, gost, vodostoykie, hosta);

// Сохраняем, чтобы у них появились Id в базе
db.SaveChanges(); 

// 3. Создаем заказы (по заданию: один покупатель делает 2 заказа, у одного заказов нет)
// Передаем сами объекты (например, Customer = ivan), чтобы EF сам подставил нужные Id
var order1 = new Order { Customer = ivan, Product = kaminnie, Quantity = 3 }; 
var order2 = new Order { Customer = ivan, Product = gost, Quantity = 10 }; // Второй заказ Ивана
var order3 = new Order { Customer = olga, Product = ohotnichyi, Quantity = 5 };
var order4 = new Order { Customer = petr, Product = hosta, Quantity = 2 };

db.Orders.AddRange(order1, order2, order3, order4);
db.SaveChanges();

Console.WriteLine("Данные успешно добавлены!");
Console.WriteLine("=== Шаг 4 ===");

// 1. Спички дешевле 100 ₽ от дешёвых дорог
Console.WriteLine("--- Спички дешевле 100 руб ---");
var cheapProducts = db.Products
    .Where(p => p.Price < 100)  // фильтр
    .OrderBy(p => p.Price)      // сортировка
    .ToList();                  // выполнить запрос

foreach (var p in cheapProducts)
    Console.WriteLine($"{p.Name} — {p.Price} руб.");

// 2. Сколько видов спичек есть на складе (остаток > 0)
var inStockCount = db.Products.Count(p => p.Stock > 0);
Console.WriteLine($"\nВидов спичек в наличии: {inStockCount}");

// 3. Три самых дорогих товара
Console.WriteLine("\n--- Топ-3 самых дорогих ---");
var top3 = db.Products
    .OrderByDescending(p => p.Price) // сортировка по убыванию
    .Take(3)                         // берем только 3
    .ToList();

foreach (var p in top3)
    Console.WriteLine($"{p.Name} — {p.Price} руб.");
