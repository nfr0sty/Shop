namespace Shop;

public class Shop
{
    private const string ShowSellerProducts = "1";
    private const string ShowBuyerProducts = "2";
    private const string BuyProduct = "3";
    private const string Exit = "4";

    private Seller _seller;
    private Buyer _buyer;
    private bool _isRunning = true;

    public Shop()
    {
        _seller = new Seller("Продавец", 1000);
        _buyer = new Buyer("Покупатель", 100);

        _seller.AddProduct(new Product("Яблоко", 50));
        _seller.AddProduct(new Product("Банан", 30));
        _seller.AddProduct(new Product("Апельсин", 40));
    }

    public void Run()
    {
        while (_isRunning)
        {
            ShowMenu();
            HandleUserInput();
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\nМеню:");
        Console.WriteLine($"{ShowSellerProducts} Показать товары продавца");
        Console.WriteLine($"{ShowBuyerProducts} Показать товары покупателя");
        Console.WriteLine($"{BuyProduct} Покупка товара");
        Console.WriteLine($"{Exit} Выход");
        Console.Write("Выберите действие: ");
    }

    private void HandleUserInput()
    {
        string choice = Console.ReadLine();

        switch (choice)
        {
            case ShowSellerProducts:
                _seller.ShowProducts();
                break;

            case ShowBuyerProducts:
                _buyer.ShowProducts();
                break;

            case BuyProduct:
                HandlePurchase();
                break;

            case Exit:
                _isRunning = false;
                break;

            default:
                Console.WriteLine("Неверный ввод, попробуйте снова.");
                break;
        }
    }

    private void HandlePurchase()
    {
        _seller.ShowProducts();
        Console.WriteLine("\nВыберите товар для покупки (введите номер): ");
        
        string input = Console.ReadLine();
        if (int.TryParse(input, out int productIndex) && productIndex > 0 && productIndex <= _seller.GetProductCount())
        {
            Product product = _seller.GetProduct(productIndex - 1);
            if (_buyer.CanBuy(product))
            {
                _buyer.BuyProduct(product);
                _seller.SellProduct(product);
            }
            else
            {
                Console.WriteLine("ОШИБКА: Недостаточно денег для покупки!");
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор товара.");
        }
    }
}