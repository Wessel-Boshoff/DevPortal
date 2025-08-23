using WebAppPortalApi.Database;

namespace WebAppPortalApi.Data.Stores
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
