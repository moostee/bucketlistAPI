using bucketListAPIModels;
using System.Collections.Generic;

namespace bucketListDAL
{
    public interface IBucketListRepo
    {
        List<BucketList> GetAllBucketList(int UserId);
        int AddToBucketList(AddToBucketList addToBucketModel);
        int DeleteBucketList(BucketList deleBucketList);
        int EditBucketList(BucketList editBucketList);
    }
}
