namespace QcommentUrlCutter
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Startup.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("\nPress any key to continue . . .");
            Console.ReadLine();
        }
    }
}