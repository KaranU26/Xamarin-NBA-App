using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace REALAssignMENT2
{
     public class NetworkingManager
    {

        private string url = "https://api-nba-v1.p.rapidapi.com";
        private string key = "/?rapidapi-key=f866011085msh391e885e62f67afp1c21d2jsn8f0882d74c73";

        private HttpClient client = new HttpClient();

        public async Task<List<EastConference>> EastConf()
        {
            var response = await client.GetAsync(url + "/teams/confName/East"+key);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<EastConference>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, Object>>(stringResponse);
                var jsondata = dic.ElementAt(0).Value.ToString();
                var dic2 = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsondata);
                var arrayString = dic2.ElementAt(4).Value.ToString();
                var listdata =  JsonConvert.DeserializeObject<List<EastConference>>(arrayString.ToString());
                return listdata;
                
            }
        }

        public async Task<List<WestConference>> WestConf()
        {
            var response = await client.GetAsync(url + "/teams/confName/West" + key);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<WestConference>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, Object>>(stringResponse);
                var jsondata = dic.ElementAt(0).Value.ToString();
                var dic2 = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsondata);
                var arrayString = dic2.ElementAt(4).Value.ToString();
                var listdata = JsonConvert.DeserializeObject<List<WestConference>>(arrayString.ToString());
                return listdata;

            }
        }
        public async Task<List<Player>> GetByTeamPlayers(string teamId)
        {
            var response = await client.GetAsync(url+"/players/teamId/"+teamId+key);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<Player>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, Object>>(stringResponse);
                var jsondata = dic.ElementAt(0).Value.ToString();
                var dic2 = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsondata);
                var arrayString = dic2.ElementAt(4).Value.ToString();
                var listString = JsonConvert.DeserializeObject<List<Player>>(arrayString.ToString());
                return listString;
            }
        }
        public async Task<List<PlayerStatistics>> GetPlayerStats(string playerId)
        {
            var response = await client.GetAsync(url + "/statistics/players/playerId/" + playerId + key);
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<PlayerStatistics>();
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, Object>>(stringResponse);
                var jsondata = dic.ElementAt(0).Value.ToString();
                var dic2 = JsonConvert.DeserializeObject<Dictionary<string, Object>>(jsondata);
                var arrayString = dic2.ElementAt(4).Value.ToString();
                var listString = JsonConvert.DeserializeObject<List<PlayerStatistics>>(arrayString.ToString());
                return listString;
            }
        }
    }
}
