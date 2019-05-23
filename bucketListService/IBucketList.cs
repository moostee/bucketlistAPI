using bucketListAPIModels;

namespace bucketListService
{
    public interface IBucketList
    {
        Response GetAllBucketList(int UserId);
        Response AddToBucketList(AddToBucketList addToBucketModel);
        Response DeleteBucketList(BucketList editBucketList);
        Response EditBucketList(BucketList editBucketList);
    }
}
