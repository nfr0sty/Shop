namespace Shop;

public class Product
{
    public Product(string name, int price)
    {
        Name = name;
        Price = price;
    }
    
    public string Name { get; private set; }
    public int Price { get; private set; }

    public string GetInfo()
    {
        return $" {Name}, Цена: {Price}";
    }
}