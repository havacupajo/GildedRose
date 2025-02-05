using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies
{
    public class BackstagePassStrategy : BaseItemStrategy
    {
        protected override void UpdateQuality(Item item)
        {
            IncreaseQuality(item);
            if (item.SellIn <= 10) IncreaseQuality(item);
            if (item.SellIn <= 5) IncreaseQuality(item);
        }

        protected override void UpdateExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}
