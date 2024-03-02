using MusicApp.DataAccess;
using MusicApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MusicApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;
        private readonly IRepository<MovieSearch> _searchRepository;

        public MovieService(IHttpClientFactory clientFactory, IConfiguration configuration,
            IRepository<MovieSearch> searchRepository)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
            _searchRepository = searchRepository;
        }

        public IEnumerable<string> MostSearched()
        {
            return _searchRepository.AsQueryable().Select(n => n.Query).AsEnumerable();
        }

        public async Task<IEnumerable<MovieSnapshot>> GetMovies(string search)
        {
            var searches = _searchRepository.AsQueryable().OrderBy(k => k.DateCreated);
            if (searches.Any() && searches.Count() > 4)
            {
                _searchRepository.Delete(searches.First());
            }

            _searchRepository.Insert(new MovieSearch() { Query = search, DateCreated = DateTime.Now });
            _searchRepository.SaveChanges();

            string url = $"{_configuration["ImdbConfig:BaseUrl"]}";
            string param = $"&t={search}&s={search}&page=1";

            url += param;

            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.GetAsync(url);
            var jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<MovieSearchResponse>(content, jsonSettings);
                return data.Search;
            }

            return Enumerable.Empty<MovieSnapshot>();
        }

        public async Task<MovieDetail> MovieDetail(string imdbId)
        {
            string url = $"{_configuration["ImdbConfig:BaseUrl"]}";
            string param = $"&i={imdbId}";

            url += param;

            var httpClient = _clientFactory.CreateClient();
            var response = await httpClient.GetAsync(url);
            var jsonSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<MovieDetail>(content, jsonSettings);
                return data;
            }

            return null;
        }
    }
}