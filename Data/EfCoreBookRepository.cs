using TIM.Lib.Model;

namespace TIM.Lib.Data
{
    public class EfCoreBookRepository : EfCoreRepository<Book, MyMDBContext>
    {
        public EfCoreBookRepository(MyMDBContext context) : base(context)
        {
        }
    }
}
