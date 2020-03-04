using RowDataGateway.Finders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RowDataGateway
{
    
    class Program
    {
        private const string Connection_String= "data source=DESKTOP-IU300GU\\SQLEXPRESS;initial catalog=portafolio;integrated security=True";


        static void Main(string[] args)
        {
           

            Console.WriteLine("Row Data Gateway Pattern");
            MediaFinder finder = new MediaFinder(Connection_String);

            MediaGateway media = finder.Find(3);
            Console.WriteLine("Encontrado: " + media.Name);
            media.Name = "La voragine";
            media.Update();
            
            
            MediaGateway MediaG = new MediaGateway(Connection_String)
            {
                Name = "Semana",
                Type = MediaType.Magazine
            };
            MediaG.Insert();
            Console.ReadKey();

            

        }
    }
}
