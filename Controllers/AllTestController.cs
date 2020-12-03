using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTest.Models;

namespace OnlineTest.Controllers
{
 


    public class AllTestController : Controller


    {
        //This controller Will handle all test Code Here
        // GET: AllTest
        private OnlineTestDBEntities db = new OnlineTestDBEntities();
        public static int result = 0;
        public ActionResult PythonTest()   //Python Test
        {

            string test = "Python";
            var questions = db.Questions.Where(s => s.Test_Name == test).ToList();

            return View(questions);

        }
        public ActionResult CSharpTest()   //C# Test
        {
            string test = "C#";
            var questions = db.Questions.Where(s => s.Test_Name == test).ToList();

            return View(questions);

        }
        public ActionResult JAVATest()  //Java Test
        {
            string test = "JAVA";
            var questions = db.Questions.Where(s => s.Test_Name == test).ToList();

            return View(questions);

        }
        public ActionResult ADOTest()  //ADO.Net test
        {
            string test = "ADO";
            var questions = db.Questions.Where(s => s.Test_Name == test).ToList();

            return View(questions);

        }

        public ActionResult PythonInstruction()
        {
            return View();

        }

        public ActionResult CSharpInstruction()
        {
            return View();
        }

        public ActionResult JAVAInstruction()
        {
            return View();
        }

        public ActionResult ADOInstruction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckAnswerPython(string Answer, String Question_Answer)
        {
            //string correctanswer = TempData["CorrectAnswer"].ToString();
            if (Answer == Question_Answer)
            {
                result = result + 5;
            }
             
            ViewBag.Result = result;
            return RedirectToAction("PythonTest");

        }

        [HttpPost]
        public ActionResult CheckAnswerCSharp(string Answer, String Question_Answer)
        {
            //string correctanswer = TempData["CorrectAnswer"].ToString();
            if (Answer == Question_Answer)
            {
                result = result + 5;
            }
 
            ViewBag.Result = result;
            return RedirectToAction("CSharpTest");

        }

        [HttpPost]
        public ActionResult CheckAnswerJAVA(string Answer, String Question_Answer)
        {
            //string correctanswer = TempData["CorrectAnswer"].ToString();
            if (Answer == Question_Answer)
            {
                result = result + 5;
            }
 
            ViewBag.Result = result;
            return RedirectToAction("JAVATest");

        }


        [HttpPost]
        public ActionResult CheckAnswerADO(string Answer, String Question_Answer)
        {
            //string correctanswer = TempData["CorrectAnswer"].ToString();
            if (Answer == Question_Answer)
            {
                result = result + 5;
            }
 
            ViewBag.Result = result;
            return RedirectToAction("ADOTest");

        }


        public ActionResult Result()
        {
            ViewBag.Finalresult = result;
            return View();
        }

    }
    }