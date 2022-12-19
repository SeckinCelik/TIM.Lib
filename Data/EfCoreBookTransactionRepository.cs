using TIM.Lib.Model;

namespace TIM.Lib.Data
{
    public class EfCoreBookTransactionRepository : EfCoreRepository<BookTransaction, MyMDBContext>
    {
        public EfCoreBookTransactionRepository(MyMDBContext context) : base(context)
        {
        }
    }
}
