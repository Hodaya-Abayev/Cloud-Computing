using MyProject.BL.BE;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DAL
{
    public class MedicineImageDal
    {
        public void GetImageDescription(MedicineImage Image)
        {
            string apiKey = "acc_c8ca6e79732e57a";
            string apiSecret = "8be9e6d5b65cdd77fd3f2142b95e5d50";
            string image = Image.ImageUrl;

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));
            request.AddFile("image", image);

            IRestResponse response = client.Execute(request);
            ImaggaRoot DetailsTree = JsonConvert.DeserializeObject<ImaggaRoot>(response.Content);
            foreach (var item in DetailsTree.result.tags)
            {
                Image.Description.Add(item.tag.en, item.confidence);
            }
            
        }
    }
}
