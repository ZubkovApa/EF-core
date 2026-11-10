namespace MyApp.Data;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string City { get; set; } = "";

    public List<Order> Orders { get; set; } = new();

    public override string ToString() => $"{Name} ({Phone}), {City}";
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";       
    public decimal Price { get; set; }            
    public int MatchesPerBox { get; set; }        
    public int Stock { get; set; }                
    public string? Description { get; set; }

    public List<Order> Orders { get; set; } = new();

    public override string ToString() =>
        $"{Name} — {Price:C}, {MatchesPerBox} шт/коробка, остаток {Stock}" +
        (Description is null ? "" : $" ({Description})");
}

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; }             

    public int CustomerId { get; set; }
    public int ProductId { get; set; }

    public Customer Customer { get; set; } = null!;
    public Product Product { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public override string ToString() =>
        $"{Customer?.Name ?? "?"} — {Product?.Name ?? "?"} — {Quantity} шт. — " +
        $"{(Product is null ? 0 : Product.Price * Quantity):C} ({CreatedAt:g})";
}