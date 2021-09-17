using Microsoft.Azure.Cosmos;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class VeterinariaDatabase
    {
        private const string ConnectionString = "AccountEndpoint=https://preparacaoatdb.documents.azure.com:443/;AccountKey=jzVqT4CtyBnU5W8lXWnTXUvP0RzgQDBifGWXtQUEMV5fHwxTcVoOhzAkWCAbKbGz2Js2o5nEoDBRqQd9zGLHQA==;";
        private const string Database = "veterinario-db";
        private const string Container = "marcacao-consulta";

        private CosmosClient CosmosClient { get; set; }

        public VeterinariaDatabase()
        {
            this.CosmosClient = new CosmosClient(ConnectionString);
        }

        public List<MarcacaoConsulta> GetAll()
        {
            var container = this.CosmosClient.GetContainer(Database, Container);

            QueryDefinition queryDefinition = new QueryDefinition("SELECT * FROM c");

            var result = new List<MarcacaoConsulta>();

            var queryResult = container.GetItemQueryIterator<MarcacaoConsulta>(queryDefinition);

            while (queryResult.HasMoreResults)
            {
                FeedResponse<MarcacaoConsulta> currentResultSet = queryResult.ReadNextAsync().Result;
                result.AddRange(currentResultSet.Resource);
            }

            return result;
        }

        public MarcacaoConsulta GetById(Guid id)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);

            QueryDefinition queryDefinition = new QueryDefinition($"SELECT * FROM c where c.id = '{id}'");

            var result = new List<MarcacaoConsulta>();

            var queryResult = container.GetItemQueryIterator<MarcacaoConsulta>(queryDefinition);

            while (queryResult.HasMoreResults)
            {
                FeedResponse<MarcacaoConsulta> currentResultSet = queryResult.ReadNextAsync().Result;
                result.AddRange(currentResultSet.Resource);
            }

            return result.FirstOrDefault();
        }

        public async Task Save(MarcacaoConsulta obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.CreateItemAsync<MarcacaoConsulta>(obj, new PartitionKey(obj.PartitionKey));
        }

        public async Task Delete(MarcacaoConsulta obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.DeleteItemAsync<MarcacaoConsulta>(obj.Id.ToString(), new PartitionKey(obj.PartitionKey));
        }

        public async Task Update(MarcacaoConsulta obj)
        {
            var container = this.CosmosClient.GetContainer(Database, Container);
            await container.ReplaceItemAsync<MarcacaoConsulta>(obj, obj.Id.ToString(), new PartitionKey(obj.PartitionKey));
        }

    }
}
