using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Net.Http;

namespace gamingApi.Controllers
{
    public class Spin : Controller
    {
        public object UrlUtil { get; private set; }

        // GET: Spin
        public ActionResult Index()
        {
            return View();
        }

        // GET:spin/create
        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            int betNumber = UrlUtil.getParam(this, "bet", "0");
            int betAmount = UrlUtil.getParam(this, "amount", "0");

            Random rnd = new Random();
            int spin = rnd.Next(1,10);

            try
            {
                var response = "";


                if (betAmount <= 0)
                {
                    response = "Incorrect Amount ";
                }
                else
                 if (betNumber <= 0)
                {
                    response = "Incorrect bet selection";
                }
                else
                {
                    int num = 0;
                    for (int i = 1; i <= spin; i++)
                    {
                        num = rnd.Next(i, 36);
                    }

                    if (betNumber == num)
                    {
                        response = "won";
                    }
                    else
                    {
                        response = "loss";
                    }

                }


                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.Gone);
                var jObject = JObject.Parse(response);
                //var jsonResponse = result;
                result.Content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
                return result;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
             

          
        }

    }
}
