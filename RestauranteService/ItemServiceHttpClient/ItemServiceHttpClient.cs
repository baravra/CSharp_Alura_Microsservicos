using RestauranteService.Dtos;
using System.Text;
using System.Text.Json;

namespace RestauranteService.ItemServiceHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configurantion;

        public ItemServiceHttpClient(HttpClient client, IConfiguration configurantion)
        {
            _client = client;
            _configurantion = configurantion;
        }

        public async void EnviaRestauranteParaItemService(RestauranteReadDto restauranteReadDto)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(restauranteReadDto),
                Encoding.UTF8,
                "application/json"
                );

            await _client.PostAsync(
                _configurantion["ItemService"]
                , content);
        }
    }
}
