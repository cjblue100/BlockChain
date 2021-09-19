using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BlockChain
{
    public class Transaction
    {
        public string from { get; set; }
        public string to { get; set; }
        public decimal Amount { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
