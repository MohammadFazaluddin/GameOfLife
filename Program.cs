namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // int MAX_HEIGHT = 25;
            int MAX_HEIGHT = Console.LargestWindowHeight - 5;
            // int MAX_WIDTH = 50;
            int MAX_WIDTH = Console.LargestWindowWidth - 3;
            int FPS = 1000 / 9;
            //int FPS = 2000 / 1;

            bool simulateLife = true;
            Simulation simulation = new(MAX_HEIGHT, MAX_WIDTH);
            simulation.Setting();

            Console.Clear();
            do
            {
                //stop
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
                    simulateLife = false;

                Console.SetCursorPosition(1, 1);

                simulation.Draw();

                simulation.NextGeneration();

                Task.Delay(FPS).Wait();
            }
            while (simulateLife);

        }
    }
}

