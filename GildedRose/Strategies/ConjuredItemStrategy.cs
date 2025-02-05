using GildedRoseKata.Models;

namespace GildedRoseKata.Strategies
{
    public class ConjuredItemStrategy : StandardItemStrategy
    {
        protected override void UpdateQuality(Item item)
        {
            base.UpdateQuality(item);
            base.UpdateQuality(item);
        }

        protected override void UpdateExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                base.UpdateQuality(item);
                base.UpdateQuality(item);
            }
        }
    }
}
