using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlockChain
{
    public class BlockChain
    {
        private readonly int _proofOfWork;
        private readonly decimal _miningReward;

        private List<Transaction> _pendingTransaction;
        public List<Block> chain { get; set; }

        public BlockChain(int proofOfWork, decimal miningReward)
        {
            chain = new List<Block>();
            AddGenesisBlock();
            this._proofOfWork = proofOfWork;
            this._miningReward = miningReward;
            this._pendingTransaction = new List<Transaction>();
        }

        public void CreateTransaction(Transaction transaction) => _pendingTransaction.Add(transaction);
       
        public void MineBlock(string mineAddress)
        {
            var rewarTransaction = new Transaction
            {
                from = null,
                to = mineAddress,
                Amount = _miningReward
            };

            _pendingTransaction.Add(rewarTransaction);
            var block = new Block(DateTime.Now, _pendingTransaction);
            block.MineBlock(_proofOfWork);
            block.PreviousHash = chain.Last().Hash;
            chain.Add(block);
            _pendingTransaction = new List<Transaction>();

        }
        private void AddGenesisBlock()
        {
            chain.Add(CreateGenesisBlock());
        }

        private Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now,null,"0");
        }

        public void AddBlock(DateTime timestamp,List<Transaction> transactions)
        {
          
            var lastBlock = chain.Last();
            var block = new Block(timestamp, transactions, lastBlock.Hash);
            chain.Add(block);

        }

        public bool IsValid()
        {
            for(int i=1;i<chain.Count;i++)
            {
                var currentBlock = chain[i];
                var previousBlock = chain[i - 1];
                if(currentBlock.Hash !=currentBlock.CreateHash())
                {
                    return false;
                }    

                if(currentBlock.PreviousHash!=previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
