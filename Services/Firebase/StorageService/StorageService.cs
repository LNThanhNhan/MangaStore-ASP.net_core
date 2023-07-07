using MangaStore.ViewModels;
using Newtonsoft.Json.Linq;
using Http = System.Net.Http;
using Response= MangaStore.ViewModels.Response;
namespace MangaStore.Services.Firebase.StorageService
{
    public class StorageService
    {
        public static async Task <JObject> UploadImage(IFormFile image)
        {
            string url = Token.GO_SERVER_HOST + "/img/create";
            using (HttpClient client = new HttpClient())
            {
                using (MultipartFormDataContent formData = new MultipartFormDataContent())
                {
                    var fileContent = new StreamContent(image.OpenReadStream());
                    fileContent.Headers.ContentDisposition = new Http.Headers.ContentDispositionHeaderValue("form-data")
                    {
                        Name = "image",
                        FileName = image.FileName
                    };
                    formData.Add(fileContent, "image", image.FileName);

                    HttpResponseMessage response = await client.PostAsync(url, formData);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        dynamic jsonResponse = JObject.Parse(responseBody);
                        if (jsonResponse.success == true)
                        {
                            return jsonResponse;
                        }
                        else
                        {
                            throw new Exception("Image upload failed.");
                        }
                    }
                    else
                    {
                        throw new Exception("Image upload failed with status code: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<JObject> UpdateImage(IFormFile image, string id)
        {
            string url = Token.GO_SERVER_HOST + "/img/update";
            using (HttpClient client = new HttpClient())
            {
                using (MultipartFormDataContent formData = new MultipartFormDataContent())
                {
                    var fileContent = new StreamContent(image.OpenReadStream());
                    fileContent.Headers.ContentDisposition = new Http.Headers.ContentDispositionHeaderValue("form-data")
                    {
                        Name = "image",
                        FileName = image.FileName
                    };
                    formData.Add(fileContent, "image", image.FileName);
                    formData.Add(new StringContent(id), "id");

                    HttpResponseMessage response = await client.PutAsync(url, formData);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        dynamic jsonResponse = JObject.Parse(responseBody);
                        if (jsonResponse.success == true)
                        {
                            return jsonResponse;
                        }
                        else
                        {
                            throw new Exception("Image upload failed.");
                        }
                    }
                    else
                    {
                        throw new Exception("Image upload failed with status code: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task DeleteImage(string id)
        {
            string url = Token.GO_SERVER_HOST + "/img/delete?id="+id;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    dynamic jsonResponse = JObject.Parse(responseBody);
                    if (jsonResponse.success == true)
                        return;
                    throw new Exception("Image upload failed.");
                }
                    
            }
        }
    }
}
