using Merino.Infrastructure;
using Microsoft.Extensions.Configuration;
using MovieCategorySearch.Application.Usecase.Movie;
using MovieCategorySearch.Application.Usecase.Movie.Dto;
using System.Net.Http.Json;

namespace MovieCategorySearch.Infrastructure.ApiClient
{

    public class TmdbApiClient : MerinoApiClient, ITmdbApiClient
    {

        const string BASE_URL = "https://api.themoviedb.org/3/movie/top_rated";

        private string _accessToken;

        public IConfiguration _config;

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

            var request = new HttpRequestMessage(HttpMethod.Get, BASE_URL + $"?{await new FormUrlEncodedContent(parameters).ReadAsStringAsync()}");
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
    }
}
