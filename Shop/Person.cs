namespace Shop;

public abstract class Person
{
    public Person(string name, int money)
    {
        Name = name;
        Money = money;
    }
    
    public string Name { get; private set; }
    public int Money { get; private set; }

    protected void ChangeMoney(int amount)
    {
        Money += amount;
    }

    public abstract void ShowProducts();
}