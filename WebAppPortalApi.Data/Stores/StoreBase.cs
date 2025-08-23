
using WebAppPortalSite.Database;

namespace WebAppPortalSite.Data.Stores
{
    public class StoreBase
    {
        protected readonly DBContext context;

        public StoreBase(DBContext context)
        {
            this.context = context;
        }


    }
}
