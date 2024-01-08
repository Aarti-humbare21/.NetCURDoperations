using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using entityframworkEx.Models;

using System.Data;
using Microsoft.EntityFrameworkCore;

namespace entityframworkEx.Controllers
{
   
        public class ConcurrencyExController : Controller
        {
            public readonly DatabaseContext _context;
            public ConcurrencyExController(DatabaseContext context)
            {

                _context = context;


            }
           

           

            [HttpGet]

            public IActionResult DisplayData()
            {
                var result = from s in _context.t1 select s;

                return View(result.ToList());
            }
            [HttpGet]
            public IActionResult Edit(int? Id)
            {

                var Data = _context.t1.Find(Id);

                return View(Data);
            }

            [HttpPost]
            public IActionResult Edit(int? Id, t1 obj)
            {
            try
            {
                if (obj == null)
                {

                }
                else
                {
                    if (ModelState.IsValid)
                    {
                        _context.Update(obj);
                        int x = _context.SaveChanges();
                        if (x > 0)
                        {
                            return RedirectToAction("DisplayData", "ConcurrencyEx");
                        }
                    }
                }

            }
            catch (DbUpdateConcurrencyException ex)
            {
                ModelState.AddModelError(string.Empty, "Name already updated some other,plz new data update it"+ex.Message);
                return View();

            }
            return View();
        }
            public IActionResult Delete(int? id)
            {
                var result = _context.RegisterModel.Find(id);
                if (result != null)
                {
                    _context.Remove(result);
                    int x = _context.SaveChanges();
                    if (x > 0)
                    {
                        return RedirectToAction("DisplayData", "ConcurrencyEx");
                    }
                }
                return View(id);
            }



        }

    }

