// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Scaffold-DbContext ' Data Source = .;Initial Catalog = Resto ;Integrated Security = SSPI;TrustServerCertificate = True ;' Microsoft.EntityFrameworkCore.SqlServer
//dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=TechTalk;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --data-annotations --table speakers

// PM> Scaffold-DbContext Data Source=.;Initial Catalog=TechTalk;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer


//

//dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=TechTalk;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --data-annotations --table speakers --context AppDbContext --output-dir Entities --context -dir Data
//using EF08_ReverseEngineering;


//dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Rest;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer






using System;

namespace ReverseEngineeringCLI.Entities
{
    class Program
    {
        public static void Main()
        {
            var context = new RestoContext();
            foreach (var product in context.Products)
            {
                Console.WriteLine(product.Name);
            }
            Console.ReadKey();
        }
    }
}