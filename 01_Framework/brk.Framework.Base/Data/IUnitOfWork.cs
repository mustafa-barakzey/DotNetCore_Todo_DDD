namespace brk.Framework.Base.Data
{

    public interface IUnitOfWork
    {
        /// <summary>
        /// برای ذخیره تغییراتی که توسط سیستم انجام میشود، از این متد استفاده میشود
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// برای ذخیره تغییراتی که توسط سیستم انجام میشود، از این متد استفاده میشود
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();
    }
}
