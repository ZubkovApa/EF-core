namespace MyApp.Data;

public static class DbSeed
{
    public static void Seed(AppDbContext db)
    {
        if (db.Customers.Any() || db.Products.Any() || db.Orders.Any())
            return;

        var ivan  = new Customer { Name = "Иван Петров",    Phone = "+7 900 111-22-33", City = "Омск" };
        var olga  = new Customer { Name = "Ольга Смирнова", Phone = "+7 900 444-55-66", City = "Томск" };
        var petya = new Customer { Name = "Пётр Кузнецов",  Phone = "+7 900 777-88-99", City = "Омск" };
        var anna  = new Customer { Name = "Анна Волкова",   Phone = "+7 900 222-33-44", City = "Новосибирск" };
        var sergey= new Customer { Name = "Сергей Орлов",   Phone = "+7 900 555-66-77", City = "Томск" };
        db.Customers.AddRange(ivan, olga, petya, anna, sergey);

        var kam  = new Product { Name = "Каминные",         Price = 150m, MatchesPerBox = 50,  Stock = 20, Description = "Горят даже под дождём" };
        var hos  = new Product { Name = "Хозяйственные",    Price =  45m, MatchesPerBox = 100, Stock = 50 };
        var tur  = new Product { Name = "Туристические",    Price =  90m, MatchesPerBox = 40,  Stock = 15, Description = "Водостойкие" };
        var dec  = new Product { Name = "Декоративные",     Price = 220m, MatchesPerBox = 30,  Stock = 10 };
        var gos  = new Product { Name = "Гостеприимные",    Price =  75m, MatchesPerBox = 60,  Stock = 25 };
        db.Products.AddRange(kam, hos, tur, dec, gos);

        db.Orders.AddRange(
            new Order { Customer = ivan,   Product = kam, Quantity = 3, CreatedAt = DateTime.UtcNow.AddDays(-5) },
            new Order { Customer = ivan,   Product = hos, Quantity = 2, CreatedAt = DateTime.UtcNow.AddDays(-3) },
            new Order { Customer = olga,   Product = tur, Quantity = 1, CreatedAt = DateTime.UtcNow.AddDays(-2) },
            new Order { Customer = petya,  Product = dec, Quantity = 4, CreatedAt = DateTime.UtcNow.AddDays(-1) },
            new Order { Customer = sergey, Product = gos, Quantity = 2, CreatedAt = DateTime.UtcNow }
        );

        db.SaveChanges();
    }
}