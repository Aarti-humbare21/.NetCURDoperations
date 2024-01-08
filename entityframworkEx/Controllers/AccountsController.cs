using Microsoft.AspNetCore.Mvc;
using entityframworkEx.Models;
namespace entityframworkEx.Controllers
{
    public class AccountsController : Controller
    {
        public readonly DatabaseContext _context;
        public AccountsController(DatabaseContext context) {

            _context = context;
        
        
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel obj)
        {
            if (obj.EmailID == "aartihumbare2003@gmail.com" && obj.password == "1234")
            {
                return RedirectToAction("Home", "Accounts");
            }
            else
            {
                return View();
            }
        }


        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel obj)
        {
            if(obj==null)
            {

            }
             else
             {
                if(ModelState.IsValid)
                {
                    var res = new RegisterModel
                    {
                      
                        RollNo = Convert.ToInt32(obj.RollNo),
                        Name = obj.Name,
                        EmailID = obj.EmailID,
                        password = obj.EmailID,
                        Age = Convert.ToByte(obj.Age),
                        Dob = Convert.ToDateTime(obj.Dob),
                        Fee = Convert.ToDecimal(obj.Fee),
                        Dept = obj.Dept,
                        status = Convert.ToBoolean(obj.status),
                        role = obj.role,

                    };
                    _context.Add(res);
                   int x= _context.SaveChanges();
                    if (x > 0)
                    {
                        return RedirectToAction("Login", "Accounts");
                    }
                    else
                    {
                        return View();
                    }
                }
            }
           return View();
       }
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet]

        public IActionResult DisplayData()
        {
            var result = from s in _context.RegisterModel select s;
            
            return View(result.ToList());
        }
        [HttpGet]
        public IActionResult Edit(int? recordid)
        {
            var result=_context.RegisterModel.Find(recordid); 

            return View(result);
        }

        [HttpPost]
          public IActionResult Edit(int? recordid,RegisterModel obj)
        {
            if (recordid == null)
            {
                
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _context.Update(obj);
                    int x=_context.SaveChanges();
                    if (x > 0)
                    {
                        return RedirectToAction("DisplayData", "Accounts");
                    }
                }
            }
            return View();
          }
        public IActionResult Delete(int? recordid)
        {
            var result = _context.RegisterModel.Find(recordid);
            if (result != null)
            {
                _context.Remove(result);
                int x=_context.SaveChanges();
                if(x > 0)
                {
                    return RedirectToAction("DisplayData", "Accounts");
                }
            }
            return View(recordid);
        }
       


    }
}
