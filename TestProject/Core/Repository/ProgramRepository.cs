using Microsoft.Azure.Cosmos;
using TestProject.Models;

namespace TestProject.Repository
{

    public class ProgramRepository : IProgramRepository
    {
        private readonly CosmosClient _cosmosDbClient;
        private readonly IConfiguration _configuration;
       
        private readonly Container _container;

       

        public ProgramRepository(CosmosClient cosmosDbClient, IConfiguration configuration)
        {
            _cosmosDbClient = cosmosDbClient;
           
            _configuration = configuration;
          
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var containerName = "Program";
            var db = cosmosDbClient.GetDatabase(databaseName);
            db.CreateContainerAsync(containerName, "/id");
            _container = cosmosDbClient.GetContainer(databaseName, containerName);

        }


        public async Task AddAsync(InternshipProgram item)
        {
            try
            {
                await _container.CreateItemAsync(item, new PartitionKey(item.Id));
            }
            catch (CosmosException)
            {

                throw;
            }
           
        }

       
        public async Task<InternshipProgram?> GetAsync(string id)
        {
            try
            {
                var response = await _container.ReadItemAsync<InternshipProgram>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException) 
            {
                return null;
            }
        }

        public async Task UpdateAsync(string id, InternshipProgram item)
        {
            await _container.UpsertItemAsync(item, new PartitionKey(id));
        }

      
        public async Task<IEnumerable<InternshipProgram>> GetAllAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<InternshipProgram>(new QueryDefinition(queryString));

            var results = new List<InternshipProgram>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync().ConfigureAwait(true);
                results.AddRange(response.ToList());
            }

            return results;
        }


        public async Task DeleteAsync(string id)
        {
            await _container.DeleteItemAsync<InternshipProgram>(id, new PartitionKey(id));
        }




    }
}
