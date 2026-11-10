public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string City { get; set; } = "";
    public List<Order> Orders { get; set; } = new();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int MatchesInBox { get; set; }
    public int Stock { get; set; }
    public List<Order> Orders { get; set; } = new();
}

public class Order
{
    public int Id { get; set; }
    public int Quantity { get; set; } // сколько коробок заказали

    // Связь с покупателем
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    // Связь с товаром
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}