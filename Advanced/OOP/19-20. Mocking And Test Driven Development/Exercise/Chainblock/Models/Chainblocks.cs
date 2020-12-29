using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Models
{
    public class Chainblocks : IChainblock
    {
        private readonly Dictionary<int, ITransaction> _transactions;

        public Chainblocks()
        {
            this._transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => this._transactions.Count;

        public void Add(ITransaction tx)
        {
            if (this._transactions.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException();
            }

            this._transactions[tx.Id] = tx;
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            if (!Enum.IsDefined(typeof(TransactionStatus), newStatus))
            {
                throw new InvalidOperationException();
            }

            if (!this._transactions.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            var transaction = this._transactions[id];

            if (transaction.Status == newStatus)
            {
                throw new InvalidOperationException();
            }

            transaction.Status = newStatus;

        }

        public bool Contains(ITransaction tx)
        {
            if (!this._transactions.ContainsValue(tx))
            {
                return false;
            }

            return true;
        }

        public bool Contains(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException();
            }

            if (!this._transactions.ContainsKey(id))
            {
                return false;
            }
            return true;

        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this._transactions.Values.Where(tr => tr.Amount >= lo && tr.Amount <= hi);
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this._transactions.Values.OrderByDescending(tr => tr.Amount).ThenBy(tr => tr.Id);
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            string[] receivers = this._transactions.Values.Where(tr => tr.Status == status)
                                                          .ToArray()
                                                          .OrderBy(tr => tr.Amount)
                                                          .Select(s => s.To)
                                                          .ToArray();
            if (receivers.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            string[] senders = this._transactions.Values.Where(tr => tr.Status == status)
                                                       .ToArray()
                                                       .OrderBy(tr => tr.Amount)
                                                       .Select(s => s.From)
                                                       .ToArray();
            if (senders.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();
            }

            return this._transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var transactions = this._transactions.Values.Where(tr => tr.From == receiver && tr.Amount >= lo && tr.Amount < hi)
                                                       .OrderByDescending(tr => tr.Amount)
                                                       .ThenBy(tr => tr.Id);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var transactions = this._transactions.Values.Where(tr => tr.To == receiver)
                                                      .OrderByDescending(tr => tr.Amount)
                                                      .ThenBy(tr => tr.Id);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var transactions = this._transactions.Values.Where(tr => tr.From == sender && tr.Amount > amount)
                                                      .OrderByDescending(tr => tr.Amount);
            if (transactions.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var transacions = this._transactions.Values.Where(tr => tr.From == sender).OrderByDescending(tr => tr.Amount);

            if (transacions.Count() == 0)
            {
                throw new InvalidOperationException();
            }

            return transacions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            ITransaction[] transactions = this._transactions.Values.Where(tr => tr.Status == status)
                                                                  .OrderByDescending(tr => tr.Amount)
                                                                  .ToArray();
            if (transactions.Length == 0)
            {
                throw new InvalidOperationException();
            }

            return transactions;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this._transactions.Values.Where(tr => tr.Status == status && tr.Amount <= amount)
                                           .OrderByDescending(tr => tr.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            for (int i = 0; i < this._transactions.Count; i++)
            {
                yield return this._transactions[i + 1];
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();
            }

            this._transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    }
}
