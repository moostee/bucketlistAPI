using System.ComponentModel.DataAnnotations;

namespace bucketListAPIModels
{
    public class BucketList : AddToBucketList
    {
        [Required]
        public int BucketListId { get; set; }
        public string Name { get; set; }
        public string DateCreated { get; set; }
    }

    public class AddToBucketList
    {
        public string BucketlistName { get; set; }
        [Required]
        public int UserId { get; set; }
    }

}
