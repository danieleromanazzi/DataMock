
using DataMock.Configuration;

namespace DataMock.Behaviors
{
    public class CollectionBehavior : IBehavior
    {
        public int Lenght { get; set; }
        public string IndexField { get; set; }

        public void Default()
        {
            if (!Configure.Current.TryGetBehavior<CollectionBehavior>(out var behavior))
            {
                Lenght = 8;
                return;
            }

            if (behavior is CollectionBehavior collection)
            {
                Lenght = collection.Lenght;
                IndexField = collection.IndexField;
            }
        }
    }
}
