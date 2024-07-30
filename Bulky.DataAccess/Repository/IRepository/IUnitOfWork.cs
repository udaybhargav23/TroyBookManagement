namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        //lets have all the repositories over here
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        void Save();
    }
}