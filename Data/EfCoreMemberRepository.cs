using TIM.Lib.Model;

namespace TIM.Lib.Data
{
    public class EfCoreMemberRepository : EfCoreRepository<Member, MyMDBContext>
    {
        public EfCoreMemberRepository(MyMDBContext context) : base(context)
        {
        }
    }
}
