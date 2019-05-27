namespace ButtonTest.Src.Main
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (Game game = new Game(1600, 900, "ButtonTest"))
            {
                game.Run(60);
                game.VSync = OpenTK.VSyncMode.Off;
            }
        }
    }
}
