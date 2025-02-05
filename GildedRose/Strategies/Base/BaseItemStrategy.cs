using GildedRoseKata.Interfaces;
using GildedRoseKata.Models;

namespace GildedRoseKata.Strategies.Base
{
    public abstract class BaseItemStrategy : IUpdateStrategy
    {
        protected const int MaxQuality = 50;
        protected const int MinQuality = 0;

        public virtual void Update(Item item)
        {
            UpdateQuality(item);
            UpdateSellIn(item);
            UpdateExpired(item);
        }

        protected virtual void UpdateQuality(Item item) { }

        protected virtual void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        protected virtual void UpdateExpired(Item item) { }

        protected void IncreaseQuality(Item item)
        {
            if (item.Quality < MaxQuality)
                item.Quality++;
        }

        protected void DecreaseQuality(Item item)
        {
            if (item.Quality > MinQuality)
                item.Quality--;
        }
    }
}
