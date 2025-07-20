using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Data;
using System.Transactions;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace EFCore01
{
    class Program
    {
        public static void Main()
        {

            //// Console.WriteLine(  "sdfsdfsdfs");
            //var configuration = new ConfigurationBuilder()
            //    .AddJsonFile("appsettingss.json")
            //    .Build();
            //IDbConnection db = new SqlConnection(configuration.GetSection("conecstr").Value);

            //~~~~~~~~~~~~~~~~~~~~~~~~~~   1- execute Raw sql   ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


            //var query = "select * from Wallets";
            //var resultAsDynmaicBinding = db.Query(query);

            //Console.WriteLine("using dynamic query object binding");
            //foreach (var item in resultAsDynmaicBinding)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("using static query object binding ");

            //var resultAsStatiBinding = db.Query<Wallet>(query);
            //foreach (var item in resultAsStatiBinding)
            //{
            //    Console.WriteLine(item);
            //}
            //~~~~~~~~~~~~~~~~~~~~~~~~~~   2- Execute Insert  Using Dapper ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //var query = "Insert into Wallets(Holder,Balance)" +
            //            "Values (@Holder,@Balance)";
            //var ParametrsUpdated = new Wallet { Balance = 342, Holder = "aya3" };

            ////  db.Execute(query, ParametrsUpdated);
            //db.Execute(query, new
            //{
            //    Balance = ParametrsUpdated.Balance,
            //    Holder =ParametrsUpdated.Holder,


            //});

            //~~~~~~~~~~~~~~~~~~~~~~~~~~   2- insert way2    ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            //var query = "Insert into Wallets(Holder,Balance)" +
            //            "Values (@Holder,@Balance)" +
            //            "select CAST(SCOPE_IDENTITY() AS INT)";
            //var ParametrsUpdated = new Wallet { Balance = 383, Holder = "yoya" };

            ////  db.Execute(query, ParametrsUpdated);
            //var parametres = new
            //{
            //    Holder = ParametrsUpdated.Holder,
            //    Balance = ParametrsUpdated.Balance
            //};
            //ParametrsUpdated.Id = db.Query<int>(query, parametres).Single();
            //Console.WriteLine(ParametrsUpdated);

            //~~~~~~~~~~~~~~~~~~~~~~~~~~   3- execute Update  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // var query = "UPDATE Wallets SET Holder = @Holder, Balance = @Balance " +
            //     $"WHERE Id = @Id";
            // var ParametrsUpdated = new Wallet {Id=1, Balance = 383, Holder = "yoya" };

            // //  db.Execute(query, ParametrsUpdated);
            // var parametres = new
            // {   Id=ParametrsUpdated.Id,
            //     Holder = ParametrsUpdated.Holder,
            //     Balance = ParametrsUpdated.Balance
            // };
            //db.Execute(query,parametres);




            //~~~~~~~~~~~~~~~~~~~~~~~~~~  Transaction   ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //var amoutToTransfer = 100;
            //using (var transactionScopee = new TransactionScope())
            //{
            //    var walletfrom = db.QuerySingle<Wallet>("select * from Wallets where Id = @Id ", new { Id = 4 });
            //    var walletTo = db.QuerySingle<Wallet>("select * from Wallets where Id = @Id ", new { Id = 5 });

            //    //walletfrom.Balance -= amoutToTransfer;
            //    // walletTo.Balance += amoutToTransfer;

            //    db.Execute("UPDATE Wallets SET  Balance = @Balance \" +\r\n          " +
            //        "  //     $\"WHERE Id = @Id", new
            //        {
            //            Id = walletfrom.Id,
            //            Balance = walletfrom.Balance - amoutToTransfer
            //        });

            //    db.Execute("UPDATE Wallets SET  Balance = @Balance \" +\r\n          " +
            //        "  //     $\"WHERE Id = @Id", new
            //        {
            //            Id = walletTo.Id,
            //            Balance = walletTo.Balance + amoutToTransfer
            //        });
            //    transactionScopee.Complete();

            //}


        }

//~~~~~~~__________~~~~~~~~~~~~~~~~~~~ NHibernate      ~~~~~~~~~~~~~_________~~~~~~~~~~~~~~~~~
        private static ISession CreateSession()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var constr = config.GetSection("constr").Value;


            var mapper = new ModelMapper();

            // list all of type mappings from assembly

            mapper.AddMappings(typeof(Wallet).Assembly.ExportedTypes);

            // Compile class mapping
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            // optional
            Console.WriteLine(domainMapping.AsString());

            // allow the application to specify propertties and mapping documents
            // to be used when creating

            var hbConfig = new Configuration();

            // settings from app to nhibernate 
            hbConfig.DataBaseIntegration(c =>
            {
                // strategy to interact with provider
                c.Driver<MicrosoftDataSqlClientDriver>();

                // dialect nhibernate uses to build syntaxt to rdbms
                c.Dialect<MsSql2012Dialect>();

                // connection string
                c.ConnectionString = constr;

                // log sql statement to console
                c.LogSqlInConsole = true;

                // format logged sql statement
                c.LogFormattedSql = true;
            });

            // add mapping to nhiberate configuration
            hbConfig.AddMapping(domainMapping);


            // instantiate a new IsessionFactory (use properties, settings and mapping)
            var sessionFactory = hbConfig.BuildSessionFactory();

            var session = sessionFactory.OpenSession();

            return session;
        }



    }
}




