using Microsoft.EntityFrameworkCore;
using MyApp.Data;

Console.WriteLine($"Путь к файлу базы: {AppDbContext.DbPath}");

using var db = new AppDbContext();

db.Database.EnsureCreated();
DbSeed.Seed(db);

Console.WriteLine("\n=== Покупатели ===");
foreach (var c in db.Customers)
    Console.WriteLine(c);

Console.WriteLine("\n=== Товары ===");
foreach (var p in db.Products)
    Console.WriteLine(p);

Console.WriteLine("\n=== Заказы ===");
var orders = db.Orders
    .Include(o => o.Customer)
    .Include(o => o.Product)
    .ToList();

foreach (var o in orders)
    Console.WriteLine(o);

Console.WriteLine($"\nВсего заказов: {orders.Count}");