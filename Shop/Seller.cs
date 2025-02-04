namespace Shop;

public class Seller: Person
{
    public Seller(string name, int money) : base(name, money){}
    
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public int GetProductCount()
    {
        return Products.Count;
    }
    
    public Product GetProduct(int index)
    {
        return Products[index];
    }
    
    public void SellProduct(Product product)
    {
        Products.Remove(product);
        IncreaseMoney(product.Price);
    }

    public override void ShowProducts()
    {
        Console.WriteLine($"\nТовары у продавца {Name}:");

        if (Products.Count == 0)
        {
            Console.WriteLine("Нет товаров в наличии.");
        }
        else
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Products[i].GetInfo()}");
            }
            
            Console.WriteLine($"Деньги продавца: {Money} руб.");
        }
    }
}