using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace ConsoleApp2;

/*
 Данная система реализовывает доставку еды
 и пищевой\питьевой продукции  */

abstract class Delivery 
{
    public string Address;
    private string PriceOfDelivery;

}




abstract class Product  // Описание продукции
{
    public string Name;
    public string idItem;
    public string Description;
    public string Color;
    public double Price;
}

internal class TV : Product
{
    public string IdItem { get; set; }
    
}

internal class Fridge : Product {}
internal class Laptop : Product {}
internal class SmartWatch : Product {}

class Info
{
    

    public virtual void EnterInfo()
    {
        List<Product> Menu = new List<Product>()
        {
            new TV{IdItem = "1", Name = "Телевизор Samsung UE50AU7570U", Description = "HDR 10+ Tizen OS 20 Вт 50/3840x2160 Пикс", Color = "Silver", Price = 47.999},
            new TV{idItem = "2", Name = "Телевизор Toshiba 55U5069", Description = "HDR 10+ Smart TV 20 Вт 55/3840x2160 Пикс", Color = "Black", Price = 39.999},
            new Fridge{idItem = "3", Name = "Холодильник LG DoorCooling+ GA-B509SAUM", Description = "419 л/автомат.(No Frost)/203*59.5*68.2 см", Color = "Khaki", Price = 58.999},
            new Laptop{idItem = "4", Name = "Игровой ноутбук Acer Aspire 7 A715-75G-57GR NH.Q99ER.00K", Description = "Intel Core i5 10300H/GeForce GTX 1650 4GB/RAM 8 GB, OM 512 GB", Color = "Black", Price = 75.999},
            new SmartWatch{idItem = "5", Name = "Apple Watch Series 7 GPS 45mm Starlight Alum. Sport", Description = "Watch Series 7 GPS/Bright: 1000 кд/кв.м/45*38*10.7 мм", Color = "Shinning Star", Price = 38.999}
        };

        foreach (var el in Menu)
        {
            Console.WriteLine("Добро пожалаловать, вашему вниманию предоставляется список продукции: ");
            Console.WriteLine($"Номер: {el.idItem} Наименование: {el.Name} Описание: {el.Description} Цвет: {el.Color} Цена: {el.Price}");
            
        }
        
    }
}

class Byer
{
    // В блоке get в зависимости от значения строкового индекса возвращается значение того или иного поля класса.
    // Если передано неизвестное название, то генерируется исключение. В блоке set похожая логика - по индексу узнаем, для какого поля надо установить значение.
    string name = "";
    string email = "";
    string phone = "";
    public string this[string propname]
    {
        get
        {
            switch (propname)
            {
                case "name": return name;
                case "email": return email;
                case "phone": return phone;
                default: throw new Exception("Unknown Property Name");
            }
        }
        set
        {
            switch (propname)
            {
                case "name":
                    name = value;
                    break;
                case "email":
                    email = value;
                    break;
                case "phone":
                    phone = value;
                    break;
            }
        }
    }
}

//Доставка на дом
class HomeDelivery : Delivery
{

    private string Adress;
    private double cost;

    public HomeDelivery(string adress, double cost)
    {
        this.Adress = adress;
        this.cost = cost;
        
        Console.WriteLine("Вы выбрали доставку на дом..");
        Console.WriteLine("Стоимость курьерской доставки по Москве и МО составляет " + cost + " руб.");
        Console.WriteLine();

    }
    
}

class PickPointDelivery : Delivery
{
    private string Adress;
    private double Cost;
    private int Period;

    public PickPointDelivery(string adress, double cost, int period)
    {
        this.Adress = adress;
        this.Cost = cost;
        this.Period = period;

        Console.WriteLine(
            "Вы выбрали доставку в пункт выдачи.\nВы сможете забрать ваш заказ в точке пунткта выдачи по адресу " +
            adress);
        Console.WriteLine("Стоимость доставки в пункт выдачи составляет : " + cost +
                          "\nСрок хранение товара в пункте выдаче : " + period + " рабочих дня. Спасибо!");
        Console.WriteLine();

    }
}

class ShopDelivery : Delivery
    {
        private string Adress;

        public ShopDelivery(string adress)
        {
            this.Adress = adress;
            Console.WriteLine("Адрес доставки в розничный магазин: " + adress + "\nЗабрать можно по будням :\nПн-пт : 10:00-20:00\nСб-Вск : 11:00 - 18:30");
            Console.WriteLine();
        }

    }

    class Order<TDelivery, // Заказ
        TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

    }


