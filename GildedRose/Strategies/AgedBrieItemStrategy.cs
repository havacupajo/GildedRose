﻿using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies
{

    public class AgedBrieItemStrategy : BaseItemStrategy
    {
        protected override void UpdateQuality(Item item)
        {
            IncreaseQuality(item);
        }

        protected override void UpdateExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }
    }
}
