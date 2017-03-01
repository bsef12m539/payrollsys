using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using payrol.Models;

namespace payrol.Controllers
{
    public class EmployeController : Controller
    {
        payEntities db = new payEntities();
        // GET: Employe
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addEmploye()
        {
            return View();
        }
        public ActionResult addempDb(string name,string dg,string dp,int bs)
        {
            Emp e = new Emp();
            e.name = name;
            e.department = dp;
            e.designation = dg;
            e.status = "true";
            e.salary = bs;
            db.Emps.Add(e);
            db.SaveChanges();
            return RedirectToAction("addEmploye");
        }
        public ActionResult attendance()
        {
            return View();
        }
        public ActionResult attendanceEmp()
        {
            DateTime d = DateTime.Now.Date;
            foreach(Emp e in db.Emps)
            {
                if(db.Attendances.Where(x=>x.eid==e.Id && x.date==d).Count()>0)
                {

                }
                else
                {
                    Attendance att = new Attendance();
                    att.status = Request[e.Id + ""].ToString();
                    att.date = DateTime.Now.Date;
                    att.eid = e.Id;
                    db.Attendances.Add(att);
                }
                

            }
            db.SaveChanges();
          return RedirectToAction("Index");
        }
        public ActionResult generateSalary()
        {
            return View();
        }
        public ActionResult addBonus(int user_id,int count,int ded,int bonus,int salary,DateTime da)
        {
            salary s = new salary();
            s.eid = user_id;
            s.bonus = bonus;
            s.deduction = ded;
            s.days = count;
         s.month = da.Date;
            db.salaries.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult viewSalary()
        {
            return View();
        }
        public ActionResult viewAttendance()
        {
            
           var aa = from m in db.Attendances
                 group m by m.date
                     into g
                     select g.Key;
           ViewBag.date = aa;

              
            return View();
        }
        public ActionResult viewEmp()
        {
            return View();
        }
    }
}