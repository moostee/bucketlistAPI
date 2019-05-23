using bucketListAPIModels;
using bucketListDAL;
using System;

namespace bucketListService
{
    public class BucketListService : IBucketList
    {
        private readonly IBucketListRepo _bucketListRepository;
        public BucketListService(IBucketListRepo bucketListRepository)
        {
            _bucketListRepository = bucketListRepository;
        }

        public Response AddToBucketList(AddToBucketList addToBucketModel)
        {
            Response response = new Response();
            response.ResponseCode = "02";
            response.ResponseMessage = "Failed";
            try
            {
                var result = _bucketListRepository.AddToBucketList(addToBucketModel);
                if (result > 0)
                {
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Successfully Added";
                }

            }
            catch (Exception e)
            {
                response.ResponseCode = "99";
                response.ResponseMessage = "An error occured while proceesing your request";
            }

            return response;
        }

        public Response DeleteBucketList(BucketList deleteBucketList)
        {

            Response response = new Response();
            response.ResponseCode = "02";
            response.ResponseMessage = "Failed";
            try
            {
                var result = _bucketListRepository.DeleteBucketList(deleteBucketList);
                if (result > 0)
                {
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Successfully Deleted";
                }

            }
            catch (Exception e)
            {
                response.ResponseCode = "99";
                response.ResponseMessage = "An error occured while proceesing your request";
            }

            return response;
        }

        public Response EditBucketList(BucketList editBucketList)
        {
            Response response = new Response();
            response.ResponseCode = "02";
            response.ResponseMessage = "Failed";
            try
            {
                var result = _bucketListRepository.EditBucketList(editBucketList);
                if (result > 0)
                {
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Successfully Updated";
                }

            }
            catch (Exception e)
            {
                response.ResponseCode = "99";
                response.ResponseMessage = "An error occured while proceesing your request";
            }

            return response;
        }

        public Response GetAllBucketList(int UserId)
        {
            Response response = new Response();
            response.ResponseCode = "02";
            response.ResponseMessage = "Failed";
            try
            {
                var result = _bucketListRepository.GetAllBucketList(UserId);
                if (result != null)
                {
                    response.ResponseCode = "00";
                    response.ResponseMessage = "Successful";
                    response.Data = result;
                }

                response.Data = result;
            }
            catch (Exception e)
            {
                response.ResponseCode = "99";
                response.ResponseMessage = "An error occured while proceesing your request";
            }

            return response;
        }
    }
}
