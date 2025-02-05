using GildedRoseKata.Interfaces;
using GildedRoseKata.Models;
using GildedRoseKata.Strategies;
using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> _items;
    private readonly IDictionary<string, IUpdateStrategy> _strategies;

    // DEV NOTE: Would have prefered to have added itemType enum to Item class, instead of "magic strings"
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
    private const string LegendaryItem = "Sulfuras, Hand of Ragnaros";
    private const string Conjured = "Conjured Mana Cake";

    public GildedRose(IList<Item> items)
    {
        _items = items;
        _strategies = new Dictionary<string, IUpdateStrategy>
        {
            { AgedBrie, new AgedBrieItemStrategy() },
            { BackstagePasses, new BackstagePassStrategy() },
            { LegendaryItem, new SulfurasItemStrategy() },
            { Conjured, new ConjuredItemStrategy() }
        };
    }

    public void UpdateQuality()
    {
        foreach (var item in _items)
        {
            try
            {
                var strategy = _strategies.TryGetValue(item.Name, out var itemStrategy)
                    ? itemStrategy
                    : new StandardItemStrategy();

                strategy.Update(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating item '{item.Name}': {ex.Message}");
            }
        }
    }
}