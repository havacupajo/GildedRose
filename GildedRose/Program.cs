using GildedRoseKata.Models;
using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    private const string WelcomeMessage = "OMGHAI!";
    private const string DayHeader = "-------- day {0} --------";
    private const string ItemHeader = "name, sellIn, quality";
    private const int DefaultDays = 20;

    public static void Main(string[] args)
    {
        var items = InitializeItems();
        var app = new GildedRose(items);
        int days = ParseDays(args);

        UpdateItems(items, app, days);
    }

    private static void UpdateItems(IList<Item> items, GildedRose app, int days)
    {
        Console.WriteLine(WelcomeMessage);
        for (var day = 0; day < days; day++)
        {
            PrintItems(items, day);
            app.UpdateQuality();
        }
    }

    private static void PrintItems(IList<Item> items, int day)
    {
        Console.WriteLine(string.Format(DayHeader, day));
        Console.WriteLine(ItemHeader);
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
        }
        Console.WriteLine();
    }

    private static int ParseDays(string[] args)
    {
        if (args.Length == 0)
            return DefaultDays;

        if (!int.TryParse(args[0], out int days))
        {
            Console.WriteLine($"Invalid number of days. Using default value: {DefaultDays}.");
            return DefaultDays;
        }

        return days + 1;
    }

    private static IList<Item> InitializeItems()
    {
        return new List<Item>
        {
            CreateItem("+5 Dexterity Vest", 10, 20),
            CreateItem("Aged Brie", 2, 0),
            CreateItem("Elixir of the Mongoose", 5, 7),
            CreateItem("Sulfuras, Hand of Ragnaros", 0, 80),
            CreateItem("Sulfuras, Hand of Ragnaros", -1, 80),
            CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
            CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
            CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
            CreateItem("Conjured Mana Cake", 3, 6)      // this conjured item does not work properly yet
        };
    }

    private static Item CreateItem(string name, int sellIn, int quality)
    {
        return new Item { Name = name, SellIn = sellIn, Quality = quality };
    }
}
