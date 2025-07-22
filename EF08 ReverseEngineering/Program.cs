// Scaffold - DbContext "Data Source=.;Initial Catalog=TechTalk;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer
//dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=TechTalk;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer --data-annotations --table speakers

// PM> Scaffold-DbContext Data Source=.;Initial Catalog=TechTalk;Integrated Security=SSPI;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer

using EF08_ReverseEngineering;
using System;

namespace EF008.ReverseEngineering
{
    class Program
    {
        // Step #1: Package Manager Console (PMC)
        //    Tools -> Nuget Package Manager -> Package Manager Console

        // Step #2: Package Manager Console (PMC) Tool 
        //    Install-Package Microsoft.EntityFrameworkCore.Tools

        // Step #3: Install Nuget Page on Project Microsoft.EntityFrameworkCore.Design
        // Microsoft.EntityFrameworkCore.SqlServer

        // Step #4: Install Provider in the project Microsoft.EntityFrameworkCore.SqlServer

        // Step #5: Run Command (Full)
        //    Scaffold-DbContext '[Connection String]' [Provider]



        public static void Main(string[] args)
        {
            //foreach (var item in new TechTalkContext().Speakers)
            //{
            //    Console.WriteLine(item.FirstName + " " + item.LastName);
            //}
            //Console.ReadKey();
            //Console.WriteLine(1);
        }
    }
}




