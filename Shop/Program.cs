namespace Shop;

class Program
{
    private const string ShowSellerProducts = "1";
    private const string ShowBuyerProducts = "2";
    private const string BuyProduct = "3";
    private const string Exit = "4";
    
    static void Main(string[] args)
    {
        Product apple = new Product("Яблоко", 50);
        Product banana = new Product("Банан", 30);
        Product orange = new Product("Апельсин", 40);
        
        Seller seller = new Seller("Продавец", 1000);
        Buyer buyer = new Buyer("Покупатель", 100);

        seller.AddProduct(apple);
        seller.AddProduct(banana);
        seller.AddProduct(orange);

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine($"{ShowSellerProducts} Показать товары продавца ");
            Console.WriteLine($"{ShowBuyerProducts} Показать товары покупателя");
            Console.WriteLine($"{BuyProduct} Покупка товара");
            Console.WriteLine($"{Exit} Выход");
            
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case ShowSellerProducts:
                    seller.ShowProducts();
                    break;
                
                case ShowBuyerProducts:
                    buyer.ShowProducts();
                    break;
                
                case BuyProduct:
                    
                    Console.WriteLine("\nВыберите товар для покупки (введите номер): ");
                    string input = Console.ReadLine();
                    
                    if (int.TryParse(input, out int productIndex) && productIndex > 0 && productIndex <= seller.GetProductCount())
                    {
                        seller.SellProduct(productIndex - 1, buyer);
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор товара.");
                    }
                    break;
                
                case Exit:
                    return;
                
                default:
                    Console.WriteLine("Неверный ввод, попробуйте снова.");
                    break;
            }
        }
    }
}