using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Model;
using Newtonsoft.Json;

namespace FirstBot
{
    public class GameService
    {
        private HttpClient client {get; set;}

        private const string ServerName = "http://ServerName";

        private const string Authorization = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJFcnpoYW5HZXRVcCIsImp0aSI6IjRkMWY4ODkxLWNkZmEtNDBlOS05N2ZmLWMxMmYwNWRhZmU4MyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYWJjNTJhMWEtNDQ3Yi00ZWFjLTg4NzQtMmZhOWRmOGFlMTM0Iiwicm9sIjoiYXBpX2FjY2VzcyIsImV4cCI6MTU1NzEzMTQ3NSwiaXNzIjoibXNrZG90bmV0IiwiYXVkIjoibXNrZG90bmV0In0.gorYhnqPilzcAK0xjbbXhAWKQcfxgx8UM04orx1jadk";

        public GameService()
        {
            client = new HttpClient();
        }

        public async Task<PlayerSessionInfo> CreateRace(string mapName)
        {
            var uri = $"{ServerName}/receapi/race/";

            var createRace = new CreateRaceDto(mapName);

            var createRasejson = JsonConvert.SerializeObject(createRace);

            var response = await client.SendAsync(new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Post,
                Content = new StringContent(createRasejson, Encoding.UTF8, "application/json"),
                Headers = { { "Authorization", $"{Authorization}" } }
            });

            var playerSessionInfoJson = await response.Content.ReadAsStringAsync();

            var playerSessionInfo = JsonConvert.DeserializeObject<PlayerSessionInfo>(playerSessionInfoJson); 

            return playerSessionInfo;
        }

        public void GetHelpMath()
        {
            // var uri = $"/receapi/race/";

            // var createRace = new CreateRaceDto(mapName);

            // var createRasejson = JsonConvert.SerializeObject(createRace);

            // var response = await client.PostAsync(uri, new StringContent(createRasejson, Encoding.UTF8, "application/json"));

            // var playerSessionInfoJson = await response.Content.ReadAsStringAsync();

            // var playerSessionInfo = JsonConvert.DeserializeObject<PlayerSessionInfo>(playerSessionInfoJson); 

            // return playerSessionInfo;
        }
    }
}