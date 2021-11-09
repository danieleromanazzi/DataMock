namespace DataMock.Behaviors
{
    public class WordsBehavior : IBehavior
    {
        public int Number { get; set; }
        public int Lenght { get; set; }

        public void Default()
        {
            Lenght = 5;
            Number = 2;
        }
    }
}
