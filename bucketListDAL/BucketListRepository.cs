using bucketListAPIModels;
using bucketListDAL;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace bucketListService
{
    public class BucketListRepository : IBucketListRepo
    {
        //an instance of the inbuilt IConfiguration class
        private readonly IConfiguration _config;
        //configuration is an instance of what we have in our config file
        public BucketListRepository(IConfiguration configuration)
        {
            //making what we have in our config file equal to what we have in the inbuilt Iconfiguration
            _config = configuration;
        }

        public int AddToBucketList(AddToBucketList addToBucketModel)
        {
            int response = 0;
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@UserId", addToBucketModel.UserId);
                parameter.Add("@Name", addToBucketModel.BucketlistName);

                response = con.QueryFirst<int>("AddNewBucketList", parameter, commandType: CommandType.StoredProcedure);

            }

            return response;
        }

        public int DeleteBucketList(BucketList deleBucketList)
        {
            int response = 0;
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", deleBucketList.BucketListId);
                parameter.Add("@UserId", deleBucketList.UserId);

                response = con.QueryFirst<int>("DeleteFromBucketList", parameter, commandType: CommandType.StoredProcedure);

            }

            return response;
        }

        public int EditBucketList(BucketList editBucketList)
        {
            int response = 0;
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@Id", editBucketList.BucketListId);
                parameter.Add("@Name", editBucketList.Name);
                parameter.Add("@UserId", editBucketList.UserId);

                response = con.QueryFirstOrDefault<int>("EditBucketList", parameter, commandType: CommandType.StoredProcedure);

            }

            return response;
        }

        public List<BucketList> GetAllBucketList(int UserId)
        {
            List<BucketList> bucketList = new List<BucketList>();
            using (IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@UserId", UserId);

                var response = con.Query<BucketList>("GetAllBucketListPerUser", parameter, commandType: CommandType.StoredProcedure).ToList();
                if (response.Count > 0)
                {
                    foreach (var item in response)
                    {
                        bucketList.Add(new BucketList()
                        {
                            BucketListId = item.BucketListId,
                            DateCreated = item.DateCreated,
                            Name = item.Name
                        });
                    }
                }

            }

            return bucketList;
        }
    }

}
