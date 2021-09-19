using System;
using System.Collections.Generic;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            var blockChain = new BlockChain(2,10);

            blockChain.AddBlock(DateTime.Now, new List<Transaction>
            {
                new Transaction
                {
                    Amount=100,
                    from="Mario",
                    to="Carlos"
                }
            });

            blockChain.AddBlock(DateTime.Now, new List<Transaction>
            {
                new Transaction
                {
                    Amount=200,
                    from="Juan",
                    to="Pedro"
                }
            });

            blockChain.AddBlock(DateTime.Now, new List<Transaction>
            {
                new Transaction
                {
                    Amount=300,
                    from="Luis",
                    to="Oscar"
                }
            });

            Console.WriteLine($"Is valid: {blockChain.IsValid()} ");
            Console.WriteLine("Start mining");
            blockChain.MineBlock("miner");

            Console.ReadKey();

        }
    }
}
