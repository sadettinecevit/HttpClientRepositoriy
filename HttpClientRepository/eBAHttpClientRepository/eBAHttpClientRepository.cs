using eBAHttpClientRepository.Responses.Abstracts;
using eBAHttpClientRepository.Responses.Concrete;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eBAHttpClientRepository
{
    public class eBAHttpClientRepository<T>
    {
        private HttpClient client { get; }
        public string BaseUrl { get; set; }

        /// <summary>
        /// Instance oluşturur. Restfull API'lerden veri çekilebilir. Geri dönen veriler JSON formatında olmalıdır.
        /// </summary>
        /// <param name="_httpClient">HttpClient tipindedir. BaseAddress girilmiş olmalıdır./// </param>
        public eBAHttpClientRepository(HttpClient _httpClient)
        {
            client = _httpClient;
            //BaseUrl = baseUrl;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.BaseAddress = new Uri(BaseUrl);
        }
        /// <summary>
        /// Bu işlemi yaparken server tarafındaki data tipi fonksiyonu verilir.
        /// </summary>
        /// <param name="url">endpoint yazılır.</param>
        /// <param name="data">T tipinde 1 adet data girilmelidir.</param>
        /// <returns></returns>
        public virtual async Task<IResponse> Post(string url, T data)
        {
            string sData = JsonConvert.SerializeObject(data);
            HttpContent httpContent = new StringContent(sData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, httpContent);
            IResponse retVal = new Response(response.IsSuccessStatusCode);

            return retVal;
        }
        /// <summary>
        /// Bu işlemi yaparken server tarafındaki data tipi fonksiyonu verilir.
        /// </summary>
        /// <param name="url">endpoint yazılır.</param>
        /// <param name="data">T tipinde 1 adet data girilmelidir.</param>
        /// <returns></returns>
        public async Task<IResponse> Put(string url, T data)
        {
            string sData = JsonConvert.SerializeObject(data);
            HttpContent httpContent = new StringContent(sData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(url, httpContent);

            IResponse retVal = new Response(response.IsSuccessStatusCode);

            return retVal;
        }
        /// <summary>
        /// Bu işlemi yaparken server tarafındaki data tipi fonksiyonu verilir.
        /// </summary>
        /// <param name="url">endpoint yazılır.(base url dahil DEĞİL!)</param>
        /// <param name="id">Silinecek olan datanın id'si girilmelidir.</param>
        /// <returns></returns>
        public async Task<IResponse> Delete(string url, int id)
        {
            //HttpContent httpContent = new StringContent(Encoding.UTF8, "application/json");
            var response = await client.DeleteAsync(url + "/" + id.ToString());

            IResponse retVal = new Response(response.IsSuccessStatusCode);

            return retVal;
        }
        /// <summary>
        /// Sadece 1 tane T tipinde veri döner.
        /// </summary>
        /// <param name="url">endpoint yazılır.</param>
        /// <param name="id">Çağrılan datanın id'si girilmelidir.</param>
        /// <returns></returns>
        public async Task<IDataResponse<T>> Get(string url, int id)
        {
            HttpResponseMessage response = await client.GetAsync(url);  // Blocking call! // + "/" + id.ToString()

            T data = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);

            IDataResponse<T> retVal = new DataResponse<T>(data, response.IsSuccessStatusCode);

            return retVal;
        }
        /// <summary>
        /// Sadece 1 tane T tipinde veri döner.
        /// </summary>
        /// <param name="url">endpoint yazılır.</param>
        /// <returns></returns>
        public async Task<IDataResponse<T>> GetAll(string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);  // Blocking call!

            IDataResponse<T> retVal = new DataResponse<T>(JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result), response.IsSuccessStatusCode);

            return retVal;

        }
    }
}
