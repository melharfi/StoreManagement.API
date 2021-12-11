using StoreManagement.Data.EF.Infrastructure;
using StoreManagement.Data.Infrastructure.Models;
using StoreManagement.Data.Infrastructure.Repositories;

namespace StoreManagement.Data.Infrastructure.UnitOfWorks
{
    public class StoreUnitOfWork : UnitOfWork, IStoreUnitOfWork
    {
        private CategoryRepository _CategoryRepository;
        private BrandRepository _BrandRepository;
        private ProductRepository _ProductRepository;
        public StoreUnitOfWork(StoreDbContext context) : base(context)
        { }

        public StoreDbContext Context => this.context as StoreDbContext;

        public ICategoryRepository CategoryRepository => _CategoryRepository = _CategoryRepository ?? new CategoryRepository(Context);
        public IBrandRepository BrandRepository => _BrandRepository ??= new BrandRepository(Context);
        public IProductRepository ProductRepository => _ProductRepository ??= new ProductRepository(Context);
    }
}
