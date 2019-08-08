using System;
using System.Collections.Generic;
using System.Transactions;

namespace AUM.Core.Transactions
{
    /// <summary>Provides two-phase commits/rollbacks/etc for a single <see cref="Transaction"/>.</summary>
    sealed class TxEnlistment : IEnlistmentNotification
    {
        private readonly List<IRollbackableOperation> m_Journal = new List<IRollbackableOperation>();

        /// <summary>Initializes a new instance of the <see cref="TxEnlistment"/> class.</summary>
        /// <param name="tx">The Transaction.</param>
        public TxEnlistment(Transaction tx)
        {
            tx.EnlistVolatile(this, EnlistmentOptions.None);
        }

        /// <summary>
        /// Enlists <paramref name="operation"/> in its journal, so it will be committed or rolled
        /// together with the other enlisted operations.
        /// </summary>
        /// <param name="operation"></param>
        public void EnlistOperation(IRollbackableOperation operation)
        {
            operation.Execute();

            m_Journal.Add(operation);
        }

        public void Commit(Enlistment enlistment)
        {
            DisposeJournal();

            enlistment.Done();
        }

        public void InDoubt(Enlistment enlistment)
        {
            Rollback(enlistment);
        }

        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            preparingEnlistment.Prepared();
        }

        /// <summary>Notifies an enlisted object that a transaction is being rolled back (aborted).</summary>
        /// <param name="enlistment">A <see cref="T:System.Transactions.Enlistment"></see> object used to send a response to the transaction manager.</param>
        /// <remarks>This is typically called on a different thread from the transaction thread.</remarks>
        public void Rollback(Enlistment enlistment)
        {
            try
            {
                // Roll back journal items in reverse order
                for (int i = m_Journal.Count - 1; i >= 0; i--)
                {
                    m_Journal[i].Rollback();
                }

                DisposeJournal();
            }
            catch (Exception e)
            {
                throw new TransactionException("Failed to roll back.", e);
            }

            enlistment.Done();
        }

        private void DisposeJournal()
        {
            for (var i = m_Journal.Count - 1; i >= 0; i--)
            {
                var disposable = m_Journal[i] as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }

                m_Journal.RemoveAt(i);
            }
        }
    }
}