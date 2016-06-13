using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;
using WebApplication1.Utilities;

namespace WebApplication1.Controllers
{
    public class ViewModelTestController : Controller
    {
        private MyDbContext db = new MyDbContext();
        private UserManager<ContractUser> manager;

        public ViewModelTestController()
        {
            manager = new UserManager<ContractUser>(new UserStore<ContractUser>(db));
        }
        // GET: ViewModelTest
        public ActionResult Index()
        {
            return View();
        }
        //GET
        public ActionResult CreateInit()
        {
            var initViewModel = new ContractCreateInitViewModel();

            var currentUser = manager.FindById(User.Identity.GetUserId());

            string currentName = currentUser.UserName.ToString();
            string currentUserId = currentUser.Id.ToString();
            ViewBag.OwnerName = currentUserId;

            string currentDepartmentName = QueryUtility.GetDepartmentsOfUser(currentName, db).Select(d => d.DepartmentName).FirstOrDefault();
            ViewBag.ClientSelect = new SelectList(db.Mandants, "Id", "MandantName");

            IQueryable<Mandant> currentClient = QueryUtility.GetClientOfDepartment(currentDepartmentName, db);
            string currentClientName = currentClient.Select(c => c.MandantName).FirstOrDefault();

           //ViewBag.CoordinatorId = new SelectList(QueryUtility.GetCoordinatorsFromClient(currentClientName, db), "Id", "UserName");
           //ViewBag.ClientId = new SelectList(db.Mandants, "Id", "MandantName");

            initViewModel.Coordinators = new SelectList(QueryUtility.GetCoordinatorsFromClient(currentClientName, db), "Id", "UserName");
            initViewModel.Signers = new SelectList(db.Users);//Chr: All Users, change Later

            return View(initViewModel);
        }
        [HttpPost]
        public ActionResult CreateInit(ContractCreateInitViewModel initViewModel)
        {
            var Owner = db.Users.Find(initViewModel.OwnerId);
            var Coordinator = db.Users.Find(initViewModel.CoordinatorId);

            var contract = new Contract();
            contract.Owner = Owner;
            contract.Coordinator = Coordinator;

            contract.Description = initViewModel.Description;

            db.Contracts.Add(contract);
            db.SaveChanges();
            return RedirectToAction("CreateGeneral", new { id = contract.Id });
        }

        // GET: Contract/Create/CreateGeneral
        public ActionResult CreateGeneral(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //David Create and populate the ViewModel
            var generalViewModel = new ContractCreateGeneralViewModel();

            //Set the Contract Id
            var contract = db.Contracts.Find(id);
            generalViewModel.ContractId = contract.Id;

            //Set the types and kinds
            generalViewModel.ContractKinds = new SelectList(db.ContractKinds, "Id", "Description");
            generalViewModel.ContractTypes = new SelectList(db.ContractTypes, "Id", "Description");

            //Christoph: set up the Dropdownlist for FrameContractChoice:
            List<SelectListItem> frameContractChoice = new List<SelectListItem>();
            frameContractChoice.Add(new SelectListItem
            {
                Text = "Kein Rahmenvertrag", Value = "NoFrame", Selected = true
            });
            frameContractChoice.Add(new SelectListItem
            {
                Text = "Ist Hauptvertrag", Value = "FrameMain"
            });
            frameContractChoice.Add(new SelectListItem
            {
                Text = "Ist Untervertrag", Value = "FrameSub"
            });
            generalViewModel.FrameContractChoice = frameContractChoice;



            return View(generalViewModel);
        }

        [HttpPost]
        public ActionResult CreateGeneral(ContractCreateGeneralViewModel generalViewModel)
        {
            //load contract from db
            var contract = db.Contracts.Find(generalViewModel.ContractId);

            //load the cKind and set it
            var cKind = db.ContractKinds.Find(generalViewModel.ContractsKindId);
            contract.ContractKind = cKind;

            //load the cType and set it
            var cType = db.ContractTypes.Find(generalViewModel.ContractsTypeId);
            contract.ContractType = cType;

            //FrameContract
            FrameContract frame;
            switch (generalViewModel.FrameOptionChosen)
            {
                case "FrameMain":
                    frame = new FrameContract();
                    frame.MainContract = contract;
                    contract.IsFrameContract = true;
                    db.FrameContracts.Add(frame);
                    break;
                case "FrameSub":
                    var fMain = db.FrameContracts.Find(generalViewModel.MainFrameIdSelected);
                    frame = (FrameContract)fMain;
                    frame.Contracts.Add(contract);
                    contract.FrameContract = frame;
                    db.Entry(frame).State = EntityState.Modified;
                    break;
                case "NoFrame":
                default:
                    break;
            }

            db.Entry(contract).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("CreateDates", new { id = contract.Id });
        }
        /**
        // GET: Contract/Create/CreateGeneral
        public ActionResult CreateDates(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //David Create and populate the ViewModel
            var datesViewModel = new ContractCreateDatesViewModel();

            //Set the Contract Id
            var contract = db.Contracts.Find(id);
            datesViewModel.ContractId = contract.Id;


            return View(datesViewModel);
        }
        
        [HttpPost]
        public ActionResult CreateDates(ContractCreateDatesViewModel datesViewModel)
        {
            //load contract from db
            var contract = db.Contracts.Find(datesViewModel.ContractId);

            contract.ContractBegin = datesViewModel.ContractBegin;
            contract.ContractEnd = datesViewModel.ContractEnd;

            db.Entry(contract).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index", "Contract");
        }

        // GET: ViewModelTest
        public ActionResult Test()
        {
            return View();
        }**/

        [HttpPost]
        public ActionResult Test(FormCollection form)
        {
            return RedirectToAction("CreateGeneral");
        }
    }
}