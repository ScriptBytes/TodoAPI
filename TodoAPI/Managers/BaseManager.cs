using AutoMapper;
using Microsoft.EntityFrameworkCore.Storage;
using TodoAPI.Data;
using TodoAPI.Managers.Interfaces;

namespace TodoAPI.Managers
{
    public class BaseManager : IBaseManager
    {
        protected readonly TodoContext context;
        private IDbContextTransaction transaction;
        public BaseManager(
            TodoContext context, 
            IMapper mapper
        )
        {
            this.context = context;
        }

        public async Task BeginTransactionAsync()
        {
            transaction = await context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (transaction == null)
            {
                throw new Exception("Transaction is null");
            }

            await transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (transaction == null)
            {
                throw new Exception("Transaction is null");
            }

            await transaction.RollbackAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
