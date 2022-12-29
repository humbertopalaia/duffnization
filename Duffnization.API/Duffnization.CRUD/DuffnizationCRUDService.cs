using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Duffnization.CRUD.Domains;
using Duffnization.CRUD.Domains.Search;

namespace Duffnization.CRUD
{
    public class DuffnizationCRUDService : IDuffnizationCRUDService
    {
        private readonly DuffnizationCRUDConfig _config;

        public DuffnizationCRUDService(DuffnizationCRUDConfig config)
        {
            _config = config;
        }

        public async Task<List<BeerStyle>> ListAll()
        {
            List<BeerStyle> listReturn= new List<BeerStyle>();

            var token = await GetTokenAsync();
            if (token.Success)
            {
                try
                {
                    using (var client = new HttpClient())
                    {

                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

                        //Request Token
                        var request = await client.GetAsync(_config.BaseApiUrl + $"/beer-style/listall");
                        var response = await request.Content.ReadAsStringAsync();
                        listReturn = System.Text.Json.JsonSerializer.Deserialize<List<BeerStyle>>(response);
                        return listReturn;
                    }
                }
                catch (Exception)
                {
                    return new List<BeerStyle>();
                }
            }
            else
                return listReturn;
        }

        public async Task<DuffnizationCRUDToken> GetTokenAsync()
        {
            DuffnizationCRUDToken duffnizationCRUDToken = null;

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(new { username = _config.Username, password = _config.Password }), Encoding.UTF8, "application/json");

                    //Request Token
                    var request = await client.PostAsync(_config.BaseApiUrl + "/auth/login", content);
                    var response = await request.Content.ReadAsStringAsync();
                    duffnizationCRUDToken = System.Text.Json.JsonSerializer.Deserialize<DuffnizationCRUDToken>(response);
                }
            }
            catch (Exception)
            {
                duffnizationCRUDToken = null;
            }


            return duffnizationCRUDToken;

        }
    }
}
