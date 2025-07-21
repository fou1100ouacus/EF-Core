

using EFCore01;
using System;
using System.Data;
using System.Transactions;

namespace EF005
{

    class Program
    {
        public static void Main()
        {



            //__________________________  EF CORE             ____________________________
            //__________________________  EF CORE  01 Rertive data           ____________________________

            //using (var context = new AppDbContext())
            //{
            //    foreach (var item in context.Wallets)
            //    {
            //        Console.WriteLine(item);

            //    }

            //}

            //__________________________  EF CORE  05 Rertive data           ____________________________

            //using (var context = new AppDbContext())
            //{
            //    var item=context.Wallets.FirstOrDefault(x=>x.Id==3);
            //    Console.WriteLine(item);

            //}

            //__________________________  EF CORE  05 Insert data           ____________________________


            //var wallet = new Wallet
            //{
            //    Holder = "manar",
            //    Balance = 9000
            //};
            //using (var context=new AppDbContext())
            //{
            //    context.Add(wallet);
            //    context.SaveChanges();
            //}
            //__________________________  EF CORE  05 Update data           ____________________________

            //using (var context = new AppDbContext())
            //{
            // var wallet=context.Wallets.Single(x=>x.Id==3);
            //    wallet.Balance += 7;
            //    context.SaveChanges();

            //}
            //__________________________  EF CORE  05 delet data           ____________________________

            //using (var context = new AppDbContext())
            //{
            //    var wallet = context.Wallets.Single(x => x.Id == 5);
            //    context.Wallets.Remove(wallet);
            //    context.SaveChanges();

            //}
            //__________________________  EF CORE  05 QUERY data           ____________________________

            //using (var context = new AppDbContext())
            //{
            //    var items= context.Wallets.Where(x => x.Balance > 5000);
            //    //Console.WriteLine(item);
            //    foreach (var item in items)
            //    {
            //        Console.WriteLine(item);

            //    }
            //}
            //__________________________  EF CORE  05 transaction            ____________________________

            //var amoutToTransfer = 1000;

            //using (var context = new AppDbContext())
            //{
            //    using (var transactionScopee = context.Database.BeginTransaction())
            //    {
            //        var from = context.Wallets.Single(x => x.Id == 2);
            //        var to = context.Wallets.Single(x => x.Id == 3);

            //        from.Balance -= amoutToTransfer;
            //        context.SaveChanges();
            //        to.Balance += amoutToTransfer;
            //        context.SaveChanges();
            //        transactionScopee.Commit();

            //    }
            //}



        }







    }
}
}