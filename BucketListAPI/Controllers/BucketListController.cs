using bucketListAPIModels;
using bucketListService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BucketListAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BucketListController : ControllerBase
    {
        private readonly IBucketList _bucketListService;
        public BucketListController(IBucketList bucketListService)
        {
            _bucketListService = bucketListService;
        }
        // GET: api/<controller>
        [HttpGet]
        [Route("getallbucketlist")]
        public IActionResult GetAllBucklist([FromQuery] int UserId)
        {
            return Ok(_bucketListService.GetAllBucketList(UserId));
        }

        [HttpPost]
        [Route("addtobucketlist")]
        public IActionResult AddToBucketList([FromBody] AddToBucketList addToBucketModel)
        {
            return Ok(_bucketListService.AddToBucketList(addToBucketModel));
        }

        [HttpPost]
        [Route("deletefrombucketlist")]
        public IActionResult DeleteBucketList([FromBody] BucketList deleteBucketList)
        {
            return Ok(_bucketListService.DeleteBucketList(deleteBucketList));
        }

        [HttpPost]
        [Route("editbucketlist")]
        public IActionResult EditBucketList([FromBody] BucketList editBucketList)
        {
            return Ok(_bucketListService.EditBucketList(editBucketList));
        }


    }
}
