using Data.Exceptions;
using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class HeroApiRepository : IHeroRepository
    {        
        private readonly string ApiUrl = string.Empty;
        private HttpClient client;
        public HeroApiRepository(string apiUrl, string apiKey)
        {
            client = new HttpClient();
            ApiUrl = $"{apiUrl}/{apiKey}";
        }

        public async Task<HeroModel> GetAsync(int id)
        {            
            HeroModel model = null;
            
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{ApiUrl}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var jsonResponse = JsonConvert.DeserializeObject<ResultModel>(json);

                    if (HasInvalidId(id, jsonResponse))
                    {
                        throw new InvalidIdException("Invalid Id");
                    }
                    
                    if (HasError(jsonResponse))
                    {
                        throw new ApiErrorException(jsonResponse.Error);
                    }

                    model = JsonConvert.DeserializeObject<HeroModel>(json);
                }
                else
                {
                    throw new Exception("An unexpected error ocurred");
                }
            }

            return model;
        }

        public async Task<ICollection<HeroModel>> GetByNameAsync(string heroName)
        {
            ICollection<HeroModel> result = null;
            
            if (heroName == null)
            {
                throw new Exception("The search string can't be null");
            }

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage httpResponse = await client.GetAsync($"{ApiUrl}/search/{heroName}");

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonString = await httpResponse.Content.ReadAsStringAsync();
                    SearchResultModel jsonModel = JsonConvert.DeserializeObject<SearchResultModel>(jsonString);

                    if (HasError(jsonModel))
                    {
                        throw new ApiErrorException(jsonModel.Error);
                    }

                    result = jsonModel.Results ?? new List<HeroModel>();
                }
                else
                {
                    throw new Exception("An unexpected error ocurred");
                }
            }

            return result;
        }

        public bool HasError(ResultModel response)
        {
            if (response.Response.Equals("error"))
            {
                if(!response.Response.Equals("character with given name not found"))
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasInvalidId(int id, ResultModel model)
        {
            if (id < 1)
            {
                return true;
            }

            if (model.Response.Equals("error") && model.Error.Equals("invalid id"))
            {
                return true;
            }

            return false;
        }
    }
}
