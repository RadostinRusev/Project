using Newtonsoft.Json;
using ProjMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjMVC.Controllers
{
    public class PlayListController : Controller
    {
        private readonly Uri rel = new Uri("https://localhost:44325/api/PlayLists");
        string token;
        // GET: National
        
        public async Task<ActionResult> Index()
        {

            using (var client = new HttpClient())
            {

               

                // client.DefaultRequestHeaders.Authorization =
                // new AuthenticationHeaderValue("Bearer", accessToken.ToString());
                //prepare the client
               
                client.BaseAddress = rel;
               
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                token = HomeController.token;
                //  client.DefaultRequestHeaders.Add("Bearer", token);
                //  client.DefaultRequestHeaders.Authorization
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           
                // Validate that we have a bearer token.





                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("");

                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<PlayListVM>>(jsonString);



                return View(responseData);
            }
        }
        public async Task<ActionResult> Details(int id)
        {

            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = rel;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                token = HomeController.token;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("" + id);

                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<PlayListVM>(jsonString);


                return View(responseData);
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Edit(PlayListVM playListVM)
        {

            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = rel;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                token = HomeController.token;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // add data to request
                var content = JsonConvert.SerializeObject(playListVM);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContect = new ByteArrayContent(buffer);
                byteContect.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //make request
                HttpResponseMessage response = await client.PostAsync("", byteContect);


                return View();
            }
        }
        //Get Nat/Create
        public ActionResult Create()
        {
            return View();
        }
        //Post Nat/Create
        [HttpPost]
        public async Task<ActionResult> Create(PlayListVM playListVM)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = rel;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    token = HomeController.token;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // add data to request
                    var content = JsonConvert.SerializeObject(playListVM);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContect = new ByteArrayContent(buffer);
                    byteContect.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    //make request
                    HttpResponseMessage response = await client.PostAsync("", byteContect);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    //prepare the client
                    client.BaseAddress = rel;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    token = HomeController.token;
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // make a request
                    HttpResponseMessage respondMessage = await client.DeleteAsync("?id=" + id);
                }
                //parse the response and return the data
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}