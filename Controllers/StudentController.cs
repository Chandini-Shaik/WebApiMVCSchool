using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Text;
using WebApiMVCSchool.Models;

namespace WebApiMVCSchool.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentModel> studata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44330/api/";
                var json = webClient.DownloadString("Students");
                var list = JsonConvert.DeserializeObject<List<StudentModel>>(json);
                studata = list.ToList();
                return View(studata);
            }
        }

        // GET: Student/Details/5
        public ActionResult Details(int Rollno)
        {
            StudentModel studata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44330/api/";
                var json = webClient.DownloadString("Students/" + Rollno);
                studata = JsonConvert.DeserializeObject<StudentModel>(json);
            }
            return View(studata);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel model)

        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44330/api/";
                    var url = "Students/POST";
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<StudentModel>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }


        // GET: Student/Edit/5
        public ActionResult Edit(int Rollno)
        {
            StudentModel studata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44330/api/";

                var json = webClient.DownloadString("Students/" + Rollno);
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<StudentModel>(json);
            }
            return View(studata);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int Rollno, StudentModel model)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "https://localhost:44330/api/Students/" + Rollno;
                    //var url = "Values/Put/" + id;
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(webClient.BaseAddress, "PUT", data);
                    StudentModel modeldata = JsonConvert.DeserializeObject<StudentModel>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int Rollno)
        {
            StudentModel studata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "https://localhost:44330/api/";

                var json = webClient.DownloadString("Students/" + Rollno);
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<StudentModel>(json);
            }
            return View(studata);

        }

        // POST: Student/Delete/5

        [HttpPost]
        public ActionResult Delete(int Rollno, StudentModel model)
        {

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection nv = new NameValueCollection();
                    //webClient.BaseAddress = "https://localhost:44330/api/Students/" + id;

                    var url = "https://localhost:44330/api/Students/" + Rollno;
                    var response = Encoding.ASCII.GetString(webClient.UploadValues(url, "DELETE", nv));
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    //webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    //string data = JsonConvert.SerializeObject(model);

                    //var response = webClient.UploadString(webClient.BaseAddress, data);

                    //EmployeeViewModel modeldata = JsonConvert.DeserializeObject<EmployeeViewModel>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
    }
}
    