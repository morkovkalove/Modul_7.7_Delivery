// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using ConsoleApp2;


Console.WriteLine("Вы зашли в интернет-доставку 'Kawaiki' ");



Info getInfo = new Info();
getInfo.EnterInfo();

HomeDelivery home = new HomeDelivery("м.Автозаводская, ул. Пушкина, д. Колотушкина 18А", 600);
PickPointDelivery point = new PickPointDelivery("м.Войковская, ленинградское шоссе, д.1А", 90, 7);
ShopDelivery shop = new ShopDelivery("м.Охотный ряд, ул.Площадь революции, д.9, стр.1");



Byer Ksenia = new Byer();

Ksenia["name"] = "Ksenia";
Ksenia["email"] = "ksen.frolova@gmail.com";
Ksenia["phone"] = "+79999999999";

Console.WriteLine("Ваши контакты для связи с вами :");
Console.WriteLine("Ваше имя :" + Ksenia["name"]);
Console.WriteLine("Ваша эл.почта :" + Ksenia["email"]);
Console.WriteLine("Ваша телефонный номер :" + Ksenia["phone"]);

