﻿using DisturbedAppsProject.Entities;
using Newtonsoft.Json;
using ProjMVC.ViewModels;
using ProjMVC.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly Uri rel = new Uri("https://localhost:44325/api/Users");
        // GET: National
        public async Task<ActionResult> Index()
        {

            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = rel;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("");

                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<List<UserVM>>(jsonString);
            
              

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
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("" + id);

                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<UserVM>(jsonString);


                return View(responseData);
            }
        }
        public async Task<ActionResult> Edit(int id)
        {

            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = rel;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // make a request
                HttpResponseMessage respondMessage = await client.GetAsync("/api/Users/" + id);
                string respon = rel + id.ToString();
                //parse the response and return the data
                string jsonString = await respondMessage.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<UserVM>(jsonString);



                return View(responseData);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(UserVM userVM)
        {

            using (var client = new HttpClient())
            {
                //prepare the client
                client.BaseAddress = rel;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // add data to request
                var content = JsonConvert.SerializeObject(userVM);
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
        public async Task<ActionResult> Create(UserVM userVM)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = rel;
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    // add data to request
                    var content = JsonConvert.SerializeObject(userVM);
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