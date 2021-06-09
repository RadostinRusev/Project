using AppsService.DTOs;
using AppsService.Implementation;
using DisturbedAppsProject.Context;
using DisturbedAppsProject.Entities;
using Newtonsoft.Json;
using ProjMVC.ViewModels;
using ProjMVC.ViewModels.Home;
using Repository2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly Uri Userurl = new Uri("https://localhost:44325/api/Users");
        private readonly Uri PlayListurl = new Uri("https://localhost:44325/api/PlayLists");
        private readonly Uri Songurl = new Uri("https://localhost:44325/api/Songs");
        private  readonly Uri Logurl = new Uri("https://localhost:44325/token");
       public static  string  token;
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About(string search,int? id)
        {
            
            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = PlayListurl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("");

                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<PlayListVM>>(jsonString);

                ViewBag.Message = "Your application description page.";
                ViewData["id"] = id;
                List<PlayListVM> result = new List<PlayListVM>();
                if ((id == 0 || id == null) && search == null)
                {
                    result = responseData;
                }
                else if (id !=0 && search ==null)
                {
               //     result = responseData.FindAll(u => u.Name.Contains(search)).ToList();
                    result = responseData.FindAll(p => p.UserId == id).ToList();
                }
                else if(search != null && (id == 0 || id==null))
                {
                    result = responseData.FindAll(u => u.Name.Contains(search)).ToList();
                }
                else
                {
                    result = responseData.FindAll(p => p.UserId == id&& p.Name.Contains(search)).ToList();
                }
                return View(result);
            }
        }


        public async Task<ActionResult> Song(string search, int? id)
        {

            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = Songurl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("");

                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<SongVM>>(jsonString);
                ViewData["ID"] = id;
                ViewBag.Message = "Your application description page.";
                List<SongVM> result = new List<SongVM>();
                if ((id == 0 || id == null) && search == null)
                {
                    result = responseData;
                }
                else if (id != 0 && search == null)
                {
                    //     result = responseData.FindAll(u => u.Name.Contains(search)).ToList();
                    result = responseData.FindAll(p => p.PlayListId == id).ToList();
                }
                else if (search != null && (id == 0 || id == null))
                {
                    result = responseData.FindAll(u => u.Name.Contains(search)).ToList();
                }
                else
                {
                    result = responseData.FindAll(p => p.PlayListId == id && p.Name.Contains(search)).ToList();
                }
                return View(result);
            }
        }

        public async Task<ActionResult> Contact(string search)
        {
          
            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = Userurl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("");

                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<UserVM>>(jsonString);

                ViewBag.Message = "Your contact page.";
               
                List<UserVM> result = new List<UserVM>();
                if (search == null)
                {
                    result = responseData;
                }
                else
                {
                    result = responseData.FindAll(u => u.Name.Contains(search)).ToList();
                }
                //  ClaimsPrincipal claimsPrincipal= Thread.CurrentPrincipal.Identity.IsAuthenticated;
               
 
             

                return View(result);
            }
        }
        // creatni view za playlistovete i song
        public ActionResult Login()
        {


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginVM model)
        {

            if (!ModelState.IsValid)
                return View(model);
            /*  try
              {
                  using (var client = new HttpClient())
                  {
                      client.BaseAddress = Logurl;
                      client.DefaultRequestHeaders.Accept.Clear();
                      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                      // add data to request
                      var content = JsonConvert.SerializeObject(model);
                      var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                      var byteContect = new ByteArrayContent(buffer);
                      byteContect.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                      //make request
                      HttpResponseMessage response = await client.PostAsync("", byteContect);
                      Console.WriteLine(response.Headers);
                  }

                  return RedirectToAction("Index");
              }
              catch
              {
                  return View();
              }*/
            using (var client = new HttpClient())
            {
                try
                {
                    LoginResultToken accessToken = GetLoginToken(model.username, model.password);
                    if (accessToken.AccessToken != null)
                    {
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken.ToString());

                    }
                    else
                    {
                        Console.WriteLine("Error Occurred:{0}, {1}", accessToken.Error, accessToken.ErrorDescription);
                    }
                   
                    if (client.DefaultRequestHeaders.Authorization == null ||
                   !string.Equals(client.DefaultRequestHeaders.Authorization.Scheme, "bearer", StringComparison.OrdinalIgnoreCase) ||
                   string.IsNullOrEmpty(client.DefaultRequestHeaders.Authorization.Parameter))
                    {
                        Console.WriteLine("ne");
                    }
                    token = client.DefaultRequestHeaders.Authorization.Parameter;
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }

            }



            /*   using (var client = new HttpClient())
               {
                   //prepare the client
                   client.BaseAddress = Userurl;
                   client.DefaultRequestHeaders.Accept.Clear();
                   client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                   // make a request
                   HttpResponseMessage respondMessage = await client.GetAsync("");

                   //parse the response and return the data
                   string jsonString = await respondMessage.Content.ReadAsStringAsync();
                   var responseData = JsonConvert.DeserializeObject<List<UserVM>>(jsonString);
                   int a = responseData.Count();
                   UserVM loguser = responseData.Find(u => u.Name == model.Name &&
                                                                  u.Password == model.Password);

                   MusicDbContext context = new MusicDbContext();

                   UserManagmentService service = new UserManagmentService();


                   if (loguser == null)
                   {
                       ModelState.AddModelError("AuthenticationFailed", "Wrong username or password");
                       return View(model);
                   }

                   //  this.HttpContext.Session.SetString("LoggedUserId", loggedUser.Id.ToString());
                   // this.HttpContext.Session.SetString("LoggedUserUsername", loggedUser.Name);
                   Session.Add("LoggedUserId", loguser.Id.ToString());
                   Session.Add("LoggedUserUsername", loguser.Name);*/
        //    return RedirectToAction("Index", "Home");
         //   }
                           
        }
            public ActionResult Logout()
            {
                this.HttpContext.Session.Remove("LoggedUserId");

                return RedirectToAction("Index", "Home");

            
           
           
        }
        public static LoginResultToken GetLoginToken(string username, string password)
        {
            string log = "https://localhost:44325/token";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(log);
            //TokenRequestViewModel tokenRequest = new TokenRequestViewModel() { 
            //password=userInfo.Password, username=userInfo.UserName};
            HttpResponseMessage response =
              client.PostAsync("Token",
                new StringContent(string.Format("grant_type=password&username={0}&password={1}",
                  HttpUtility.UrlEncode(username),
                  HttpUtility.UrlEncode(password)), Encoding.UTF8,
                  "application/x-www-form-urlencoded")).Result;

            string resultJSON = response.Content.ReadAsStringAsync().Result;
            LoginResultToken result = JsonConvert.DeserializeObject<LoginResultToken>(resultJSON);

            return result;
        }
    }
  
}
