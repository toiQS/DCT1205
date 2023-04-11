using DCT1205.Services;
using DCT1205.Entity;
using DCT1205.Models;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace DCT1205.Controllers
{
    public class EmployeeController : Controller
    {

        private IEmployeeService _employeeService;
        private IWebHostEnvironment _webHostEnvironment;
        public EmployeeController(IEmployeeService employeeService, IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _employeeService.GetAll().Select(employee => new IndexEmployeeViewModel
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                ImageUrl = employee.ImageUrl,
                DOB = employee.DOB,
                Gender = employee.Gender,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                City = employee.City,
            }).ToList();
            return View(model);
        }
        public IActionResult Index(IndexEmployeeViewModel model)
        {
            int id = model.Id;
            string employeeNo = model.EmployeeNo;
            string fullName = model.FullName;
            string ImageUrl = model.ImageUrl;
            DateTime DOB = model.DOB;
            string Gender = model.Gender;
            DateTime DateJoined = model.DateJoined;
            string Designation = model.Designation;
            string city = model.City;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateEmployeeViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DateJoined = model.DateJoined,
                    NationalInsuranceNo = model.NationalInsuranceNo,
                    PaymentMethod = model.PaymentMethod,
                    StudentLoan = model.StudentLoan,
                    UnionMember = model.UnionMember,
                    Address = model.Address,
                    City = model.City,
                    Phone = model.Phone,
                    Postcode = model.Postcode,
                    Designation = model.Designation,
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {

                    var uploadDir = @"images/employees";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _webHostEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                    await _employeeService.CreateAsSync(employee);
                    return RedirectToAction("Index");
                }

            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var model = new DetailEmployeeViewModel
            {

                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                Phone = employee.Phone,
                Email = employee.Email,
                PaymentMethod = employee.PaymentMethod,
                StudentLoan = employee.StudentLoan,
                UnionMember = employee.UnionMember,
                Address = employee.Address,
                City = employee.City,
                ImageUrl = employee.ImageUrl,
                Postcode = employee.Postcode
            };
            return View(model);
        }
    }
}

