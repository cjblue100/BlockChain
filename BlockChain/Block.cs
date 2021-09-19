using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain
{
    public class Block
    {
        public string PreviousHash { get; set; }

        public string  Hash { get; private set; }
        public List<Transaction> Transactions { get; set; }

        public readonly DateTime _timeStamp;

        private long _nonce;

        public Block(DateTime timestamp,List<Transaction> transactions, string previousHash="")
        {
            _timeStamp = timestamp;
            Transactions = transactions;
            PreviousHash = previousHash;
            Hash = CreateHash();
        }

        public string CreateHash()
        {
            using(var sha256=SHA256.Create())
            {
                var rawData = $"{PreviousHash}{_timeStamp}{string.Concat(Transactions?.Select(x=>x.ToString()) ?? new[] { "" } )}{_nonce}";
                var bytes = Encoding.UTF8.GetBytes(rawData);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);

            }
        }

        public void MineBlock(int proofWork)
        {
            var hashValidationTemplate = new String('0', proofWork);
            while(Hash.Substring(0,proofWork)!=hashValidationTemplate)
            {
                _nonce++;
                Hash = CreateHash();

            }

            Console.WriteLine($"Block with hash {Hash} Successfuly mined");

        }
    }
}
