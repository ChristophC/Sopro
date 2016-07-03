using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller
    {

        private MyDbContext db = new MyDbContext();
        private UserManager<ContractUser> manager;

        public AdministrationController()
        {
            manager = new UserManager<ContractUser>(new UserStore<ContractUser>(db));
        }
        // GET: Administration
        public ActionResult Index()
        {
            //Ober: Add UserRole-Management-Fields
            ViewBag.ClientSelect = new SelectList(db.Clients, "Id", "ClientName");
            ViewBag.UserSelect = new SelectList(db.Users, "Id", "UserName");
            ViewBag.RoleSelect = new SelectList(db.Roles, "Id", "Name");
            return View(db.Contracts.ToList());
        }

        /**************Contracts********************/
        // GET: Contract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contract contract = db.Contracts.Find(id);
            if (contract == null)
            {
                return HttpNotFound();
            }
            return View(contract);
        }

        // POST: Contract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contract contract = db.Contracts.Find(id);
            db.Contracts.Remove(contract);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //Helpers
        public ActionResult GetJsonUsersFromClient(string client)
        {
            var departments = QueryUtility.GetDepartmentsFromClient(client, db);
            IEnumerable<ContractUser> users = Enumerable.Empty<ContractUser>();
            //users.Concat(new[] { manager.FindByName("Admin") });
            foreach (Department d in departments)
            {
                if(d.DepartmentName != null) {
                    IEnumerable<ContractUser> addUser = QueryUtility.GetUsersFromDepartment(d.DepartmentName, db).AsEnumerable<ContractUser>();
                    if(addUser.Any())
                    {
                        users = users.Concat(addUser);
                    }
                }
            }
            //IQueryable<ContractUser> test = QueryUtility.GetUsersFromDepartment(departments.FirstOrDefault().DepartmentName, db);
            List<SelectListItem> data = new SelectList(users, "Id", "UserName").ToList();
            return Json(data);
        }
    }
}