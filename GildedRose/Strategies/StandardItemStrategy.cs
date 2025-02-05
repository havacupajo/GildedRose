using GildedRoseKata.Models;
using GildedRoseKata.Strategies.Base;

namespace GildedRoseKata.Strategies
{
    public class StandardItemStrategy : BaseItemStrategy
    {
        protected override void UpdateQuality(Item item)
        {
            DecreaseQuality(item);
        }

        protected override void UpdateExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }
    }
}
