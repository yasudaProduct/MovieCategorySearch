using Merino.Infrastructure;
using Microsoft.Extensions.Configuration;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.Usecase.Movie.Dto;
using System.Net.Http.Json;
using System.Runtime.InteropServices;

namespace MovieCategorySearch.Infrastructure.ApiClient
{

    public class TmdbApiClient : MerinoApiClient, ITmdbApiClient
    {

        const string BASE_URL = "https://api.themoviedb.org/3/";

        private string _accessToken;

        private IConfiguration _config;

        private Dictionary<string, string> commonHeaders 
            = new Dictionary<string, string>()
            {
                { "include_adult", "false"},
                { "language", "ja" },
                { "page", "1" },
            };

        public TmdbApiClient(IConfiguration config)
        {
            _config = config;

            _accessToken = _config.GetSection("Tmdb:AccsessToken").Value;
        }

        public async Task<TmdbApiResponce> RunAsync()
        {
            var parameters = new Dictionary<string, string>()
            {
                { "language", "ja" },
                { "page", "1" }
            };

            var request = new HttpRequestMessage(HttpMethod.Get, BASE_URL+ "movie/top_rated" + $"?{await new FormUrlEncodedContent(parameters).ReadAsStringAsync()}");
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {_accessToken}");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                TmdbApiResponce responseString = await response.Content.ReadFromJsonAsync<TmdbApiResponce>();
                Console.WriteLine(responseString);
                return responseString;
            }
            else
            {
                Console.WriteLine("Error");
                throw new Exception("Error");
            }
        }

        public async Task<TmdbApiResponce> GetPopular()
        {

            var request  = await this.CreateRequestMessage("movie/popular");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                TmdbApiResponce responseString = await response.Content.ReadFromJsonAsync<TmdbApiResponce>();
                Console.WriteLine(responseString);
                return responseString;
            }
            else
            {
                Console.WriteLine("Error");
                throw new Exception("Error");
            }
        }

        public async Task<TmdbApiResponce> SearchCollection(string title)
        {
            Dictionary<string, string> urlParam = commonHeaders;
            urlParam.Add("query", title);

            var request = await this.CreateRequestMessage("search/movie", urlParam);
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                TmdbApiResponce responseString = await response.Content.ReadFromJsonAsync<TmdbApiResponce>();
                Console.WriteLine(responseString);
                return responseString;
            }
            else
            {
                Console.WriteLine("Error");
                throw new Exception("Error");
            }
        }

        #region private methods

        private async Task<HttpRequestMessage> CreateRequestMessage(string urlMethod,Dictionary<string,string>? urlParam = null)
        {

            if (urlParam == null) urlParam = commonHeaders;

            var request = new HttpRequestMessage(HttpMethod.Get, BASE_URL+ urlMethod + $"?{await new FormUrlEncodedContent(urlParam).ReadAsStringAsync()}");
            request.Headers.Add("accept", "application/json");
            request.Headers.Add("Authorization", $"Bearer {_accessToken}");

            return request;
        }

        #endregion
    }
}
