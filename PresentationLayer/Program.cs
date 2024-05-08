using PresentationLayer.Controllers;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            SaleController Application = new();

            Application.RunApp();

            Console.ReadKey();
        }
    }
}