namespace BackToBg.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // var writer = new ConsoleWriter(50,50);
            // var reader = new ConsoleReader();
            // Player pesho = new Player("Pesho");
            // var manager = new PlayerManager(pesho);
            // var enc = new RandomEncountersManager(manager,reader,writer);
            // enc.RandomEncounters[5].Invoke();

            SLTest test1 = new SLTest();
            test1.Execute();
        }
    }
}