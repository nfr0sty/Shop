namespace Shop;

public class Buyer: Person
{
    public Buyer(string name, int money) : base(name, money){}
    
    private List<Product> _purchasedProducts = new List<Product>();

    public void BuyProduct(Product product)
    {
        if (Money >= product.Price)
        {
            _purchasedProducts.Add(product);
            ChangeMoney(-product.Price);
            Console.WriteLine($"{Name} купил {product.Name} за {product.Price} руб.");
        }
        else
        {
            Console.WriteLine("ОШИБКА: Недостаточно денег для покупки!");
        }
    }

    public override void ShowProducts()
    {
        if (_purchasedProducts.Count == 0)
        {
            Console.WriteLine("Пока что нет купленных товаров.");
        }
        else
        {
            Console.WriteLine($"У {Name} Куплены товары:");
            foreach (var product in _purchasedProducts)
            {
                Console.WriteLine($"{product.Name}");
            }
            
            Console.WriteLine($"Остаток денег: {Money} руб.");
        }
    }
}