using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Data.Infrastructure.Models;
using StoreManagement.Data.Infrastructure.Repositories;

namespace StoreManagement.Data.Infrastructure.UnitOfWorks
{
    public class InMemoryStoreUnitOfWork : UnitOfWork, IInMemoryStoreUnitOfWork
    {
        private InMemoryCategoryRepository _CategoryRepository;
        private InMemoryBrandRepository _BrandRepository;
        private InMemoryProductRepository _ProductRepository;
        public InMemoryStoreUnitOfWork(InMemoryStoreDbContext context) : base(context)
        { }

        public InMemoryStoreDbContext Context => this.context as InMemoryStoreDbContext;

        public IInMemoryCategoryRepository CategoryRepository => _CategoryRepository = _CategoryRepository ?? new InMemoryCategoryRepository(Context);
        public IInMemoryBrandRepository BrandRepository => _BrandRepository ??= new InMemoryBrandRepository(Context);
        public IInMemoryProductRepository ProductRepository => _ProductRepository ??= new InMemoryProductRepository(Context);
    }
}
