using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolBusAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class DbContextTransactionWrapper : IDbContextTransaction
    {
        private readonly IDbContextTransaction _transaction = null;

        internal DbContextTransactionWrapper(IDbContextTransaction transaction, bool existingTransaction)
        {
            _transaction = transaction;
            _existingTransaction = existingTransaction;
        }

        internal bool _existingTransaction { get; set; }

        public Guid TransactionId => throw new NotImplementedException();

        /// <summary>
        /// Commits all changes made to the database in the current transaction.
        /// </summary>
        public void Commit()
        {
            // Don't commit someone else's transaction
            if (!_existingTransaction)
            {
                _transaction.Commit();
            }
        }

        /// <summary>
        /// Discards all changes made to the database in the current transaction.
        /// </summary>
        public void Rollback()
        {
            // Don't rollback someone else's transaction
            if (!_existingTransaction)
            {
                _transaction.Rollback();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting 
        /// unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Don't dispose of someone else's transaction
            if (!_existingTransaction)
            {
                _transaction.Dispose();
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if (!_existingTransaction)
            {
                await _transaction.CommitAsync();
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (!_existingTransaction)
            {
                await _transaction.RollbackAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (!_existingTransaction)
            {
                await _transaction.DisposeAsync();
            }
        }
    }
}
