using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using FirstBot.Model;
using IO.Swagger.Model;
using Newtonsoft.Json;
using static IO.Swagger.Model.TurnModel;

namespace FirstBot
{
    public class GameService
    {
        private HttpClient client {get; set; }

        private const string ServerName = "http://51.15.100.12:5000";

        private const string Authorization = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJFcnpoYW5HZXRVcCIsImp0aSI6IjRkMWY4ODkxLWNkZmEtNDBlOS05N2ZmLWMxMmYwNWRhZmU4MyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjoiYWJjNTJhMWEtNDQ3Yi00ZWFjLTg4NzQtMmZhOWRmOGFlMTM0Iiwicm9sIjoiYXBpX2FjY2VzcyIsImV4cCI6MTU1NzEzMTQ3NSwiaXNzIjoibXNrZG90bmV0IiwiYXVkIjoibXNrZG90bmV0In0.gorYhnqPilzcAK0xjbbXhAWKQcfxgx8UM04orx1jadk";

        public GameService()
        {
            client = new HttpClient();
        }

        public async Task<PlayerSessionInfo> CreateRace(string mapName)
        {
            var uri = $"{ServerName}/raceapi/race/";

            var createRace = new CreateRaceDto(mapName);

            var response = await client.SendAsync(CreateHttpRequest(uri, HttpMethod.Post, createRace.ToJson()));

            var playerSessionInfoJson = await response.Content.ReadAsStringAsync();

            var playerSessionInfo = JsonConvert.DeserializeObject<PlayerSessionInfo>(playerSessionInfoJson); 

            return playerSessionInfo;
        }

        public async Task<TurnResult> Move (string sessionId, DirectionEnum direction, int acceleration)
        {
             var uri = $"{ServerName}/raceapi/race/{sessionId}";

             var turnModel = new TurnModel(direction, acceleration);

             var response = await client.SendAsync(CreateHttpRequest(uri, HttpMethod.Put, turnModel.ToJson()));
         
             var turnResultJson = await response.Content.ReadAsStringAsync();

             var turnResult = JsonConvert.DeserializeObject<TurnResult>(turnResultJson); 

             return turnResult;
        }

        public async Task<PlayerSessionInfo> GetCurrentState (string sessionId)
        {
             var uri = $"{ServerName}/raceapi/race/?sessionId={sessionId}";

             var response = await client.SendAsync(CreateHttpRequest(uri, HttpMethod.Get, ""));
         
             var playerSessionInfoJson = await response.Content.ReadAsStringAsync();

             var playerSessionInfo = JsonConvert.DeserializeObject<PlayerSessionInfo>(playerSessionInfoJson); 

             return playerSessionInfo;
        }

        private HttpRequestMessage CreateHttpRequest(string uri, HttpMethod method, string content )
        {
            return new HttpRequestMessage
            {
                RequestUri = new Uri(uri),
                Method = method,
                Content = new StringContent(content, Encoding.UTF8, "application/json"),
                Headers = { { "Authorization", $"{Authorization}" } }
            };
        }
    }
}