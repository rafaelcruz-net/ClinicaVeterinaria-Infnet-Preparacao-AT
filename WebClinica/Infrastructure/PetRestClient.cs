using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClinica.Models;

namespace WebClinica.Infrastructure
{
    public class PetRestClient
    {
        private string URL_PET_REST = "https://clinicaveterinariainfnet.azurewebsites.net/api";

        public IList<PetModel> GetAll()
        {
            var client = new RestClient(URL_PET_REST);

            var request = new RestRequest("GetAll", DataFormat.Json);

            var response = client.Get<IList<PetModel>>(request);

            return response.Data;

        }

        public PetModel GetById(Guid id)
        {
            var client = new RestClient(URL_PET_REST);

            var request = new RestRequest($"GetById?id={id}", DataFormat.Json);

            //Outra forma de passar o parametro id
            //request.AddQueryParameter("id", id.ToString());            
            
            var response = client.Get<PetModel>(request);

            return response.Data;

        }

        public void Save(PetModel model)
        {
            var client = new RestClient(URL_PET_REST);
            var request = new RestRequest($"Save", DataFormat.Json);
            request.AddJsonBody(model);

            var response = client.Post<PetModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.Created)
                throw new Exception("Não consegui criar o agendamento");


        }

        public void Delete(Guid id)
        {
            var client = new RestClient(URL_PET_REST);

            var request = new RestRequest($"Delete?id={id}", DataFormat.Json);

            //Outra forma de passar o parametro id
            //request.AddQueryParameter("id", id.ToString());            

            var response = client.Delete(request);
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Não consegui criar o agendamento");

        }

        public void Update(PetModel model)
        {
            var client = new RestClient(URL_PET_REST);
            
            var request = new RestRequest($"Update", DataFormat.Json);
            request.AddJsonBody(model);

            var response = client.Put<PetModel>(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Não consegui atualizar o agendamento");

        }



    }
}
