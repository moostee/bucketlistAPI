using Microsoft.EntityFrameworkCore;

namespace bucketListDAL
{
    public class BucketListDbContext : DbContext
    {
        public BucketListDbContext(DbContextOptions<BucketListDbContext> options) : base(options)
        {

        }
    }
}
