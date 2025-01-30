namespace Shop;

public class Seller: Person
{
    public Seller(string name, int money) : base(name, money){}
    
    private List<Product> _products = new List<Product>();

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public int GetProductCount()
    {
        return _products.Count;
    }

    public override void ShowProducts()
    {
        Console.WriteLine($"\nТовары у продавца {Name}:");

        if (_products.Count == 0)
        {
            Console.WriteLine("Нет товаров в наличии.");
        }
        else
        {
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_products[i].GetInfo()}");
            }
            
            Console.WriteLine($"Деньги продавца: {Money} руб.");
        }
    }

    public void SellProduct(int productId, Buyer buyer)
    {
        if (productId < 0 || productId >= _products.Count)
        {
            Console.WriteLine("Некорректный выбор товара.");
            return;
        }
        
        Product product = _products[productId];
        _products.RemoveAt(productId);
        buyer.BuyProduct(product);
        ChangeMoney(product.Price);
    }
}