﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace UMSalaryInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search(string name, string year)
        {
            ViewBag.name = name;
            string url = @"http://salaryapi.azurewebsites.net/api/Salary/GetSalaryFromDb?name=" + name + "&year=" + year;
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            if (!text.Contains("null"))
            {
                var salaryList = JsonConvert.DeserializeObject<List<Salary>>(text);
                foreach (var item in salaryList)
                {
                    if (!string.IsNullOrEmpty(item.FTR))
                        item.FTR = string.Format("{0:c}", decimal.Parse(item.FTR));
                    if (!string.IsNullOrEmpty(item.GF))
                        item.GF = string.Format("{0:c}", decimal.Parse(item.GF));
                }


                return View(salaryList);
            }
            return View();
        }
        [HttpGet]
        public string AngularSearch(string name, string year)
        {
            string url = @"http://salaryapi.azurewebsites.net/api/Salary/GetSalaryFromDb?name=" + name + "&year=" + year;
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            if (!text.Contains("null"))
            {
                var salaryList = JsonConvert.DeserializeObject<List<Salary>>(text);
                foreach (var item in salaryList)
                {
                    if (!string.IsNullOrEmpty(item.FTR))
                        item.FTR = string.Format("{0:c}", decimal.Parse(item.FTR));
                    if (!string.IsNullOrEmpty(item.GF))
                        item.GF = string.Format("{0:c}", decimal.Parse(item.GF));
                }


                return new JavaScriptSerializer().Serialize(salaryList);
            }
            return null;
        }
        [HttpGet]
        public ActionResult SearchSalaryByTitleIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SearchSalaryByTitle(string title, string year)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(year.ToString()))
            {
                string url = @"http://salaryapi.azurewebsites.net/api/Salary/GetSalaryByTitleFromDb?title=" + title + "&year=" + year;
                string text;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json charset=utf-8";

                var response = (HttpWebResponse)request.GetResponse();

                var resStream = response.GetResponseStream();
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                var salaryList = JsonConvert.DeserializeObject<SalaryByTitle>(text);

                return View(salaryList);
            }

            return View();
        }
        [HttpGet]
        public string AngularSearchSalaryByTitle(string title, string year)
        {
            string url = @"http://salaryapi.azurewebsites.net/api/Salary/GetSalaryByTitleFromDb?title=" + title + "&year=" + year;
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            var salaryList = JsonConvert.DeserializeObject<List<Salary>>(text);
            foreach (var item in salaryList)
            {
                if (!string.IsNullOrEmpty(item.FTR))
                    item.FTR = string.Format("{0:c}", decimal.Parse(item.FTR));
                if (!string.IsNullOrEmpty(item.GF))
                    item.GF = string.Format("{0:c}", decimal.Parse(item.GF));
            }

            return new JavaScriptSerializer().Serialize(salaryList);
        }
        [HttpGet]
        public ActionResult NumbersIndex()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Numbers(int year = 0, int campus = 0)
        {

            string url = @"http://salaryapi.azurewebsites.net/api/Salary/GetHighestSalary?" + "year=" + year + "&campus=" + campus;
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            var salaryList = JsonConvert.DeserializeObject<List<Numbers>>(text);

            return View(salaryList);

        }

        [HttpGet]
        public string AngularNumbers(string year)
        {
            string url = @"http://salaryapi.azurewebsites.net/api/Salary/GetHighestSalaryFromDb?" + "year=" + year;
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            var salaryList = JsonConvert.DeserializeObject<List<Salary>>(text);
            foreach (var item in salaryList)
            {
                if (!string.IsNullOrEmpty(item.FTR))
                    item.FTR = string.Format("{0:c}", decimal.Parse(item.FTR));
                if (!string.IsNullOrEmpty(item.GF))
                    item.GF = string.Format("{0:c}", decimal.Parse(item.GF));
            }
            return new JavaScriptSerializer().Serialize(salaryList);
        }
        [HttpGet]
        public ActionResult EmployeeHistory()
        {
            return View();
        }
        [HttpGet]
        public string AngularEmployeeSearch(string name)
        {
            string url = @"http://salaryapi.azurewebsites.net/api/Salary/GetSalaryByNameAllYearsFromDb?" + "name=" + name;
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            var salaryList = JsonConvert.DeserializeObject<List<Salary>>(text);
            foreach (var item in salaryList)
            {
                if (!string.IsNullOrEmpty(item.FTR))
                    item.FTR = string.Format("{0:c}", decimal.Parse(item.FTR));
                if (!string.IsNullOrEmpty(item.GF))
                    item.GF = string.Format("{0:c}", decimal.Parse(item.GF));
            }
            return new JavaScriptSerializer().Serialize(salaryList);
        }
    }

    
    

    public class Salary
    {
        public int SalaryId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string FTR { get; set; }
        public string GF { get; set; }
        public string CampusCode { get; set; }
        public string Year { get; set; }
    }

    public class SalaryByTitle
    {
        public int SalaryByTitleId { get; set; }
        public string NumberPeopleWithTitle { get; set; }
        public string MaxSalary { get; set; }
        public string MinSalary { get; set; }
        public string AvgSalary { get; set; }
    }
    public class Numbers
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Salary { get; set; }
    }
}