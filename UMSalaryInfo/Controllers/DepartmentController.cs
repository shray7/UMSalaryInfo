using System.IO;
using System.Net;
using System.Web.Mvc;

namespace UMSalaryInfo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            string url = @"http://salaryapi.azurewebsites.net/api/Department/GetDepartmentsFromDb";
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            
            return View();
        }
        public string Get()
        {
            string url = @"http://salaryapi.azurewebsites.net/api/Department/GetDepartmentsFromDb";
            string text;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();

            var resStream = response.GetResponseStream();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
    }
}