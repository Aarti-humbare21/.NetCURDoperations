using Microsoft.AspNetCore.Mvc;
using entityframworkEx.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace entityframworkEx.Controllers
{
    public class SpCurdController : Controller
    {
        public readonly DatabaseContext _context;
        public SpCurdController(DatabaseContext context)
        {

            _context = context;


        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult Insert(RegisterModel obj)
        {
            string sql = "exec sp_insert @RollNo ,@Name, @EmailID,@password,@Age,@Dob,@Fee,@Dept ,@status ";
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter{ParameterName="@rollno",Value=obj.RollNo},
                new SqlParameter{ParameterName="@name",Value=obj.Name},
                new SqlParameter{ParameterName="@emailid",Value=obj.EmailID},
                new SqlParameter{ParameterName="@password",Value=obj.password},
                new SqlParameter{ParameterName="@age",Value=obj.Age},
                new SqlParameter{ParameterName="@dob",Value=obj.Dob},
                new SqlParameter{ParameterName="@fee",Value=obj.Fee},
                new SqlParameter{ParameterName="@dept",Value=obj.Dept},
                new SqlParameter{ParameterName="@status",Value=obj.status},
                new SqlParameter{ParameterName="@role",Value=obj.role},
           
            };
            var res=_context.Database.ExecuteSqlRaw(sql, param.ToArray());
            if (res > 0)
            {
                return RedirectToAction("Display", "SpCurd");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Display()
        {

            List<RegisterModel> list;
            string sql = "exec sp_getalldatamvc";
            list = _context.RegisterModel.FromSqlRaw<RegisterModel>(sql).ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Edit( int? RecordId)
        {
            string sql = "exce sp_getdatabyids @RecordId";
            List<SqlParameter> para = new List<SqlParameter>()
            {
               new SqlParameter { ParameterName="@RecordId",Value=RecordId}
            };

            var res = _context.RegisterModel.FromSqlRaw(sql, para.ToArray()).AsEnumerable().FirstOrDefault();
            return View(res);
        }
        [HttpPost]
        public IActionResult Edit(RegisterModel obj)
        {

            string sql = "exec sp_updates @RollNo ,@Name, @EmailID,@password,@Age,@Dob,@Fee,@Dept ,@status,@RecordId ";
            List<SqlParameter> param = new List<SqlParameter>()
            {
                new SqlParameter{ParameterName="@rollno",Value=obj.RollNo},
                new SqlParameter{ParameterName="@name",Value=obj.Name},
                new SqlParameter{ParameterName="@emailid",Value=obj.EmailID},
                new SqlParameter{ParameterName="@password",Value=obj.password},
                new SqlParameter{ParameterName="@age",Value=obj.Age},
                new SqlParameter{ParameterName="@dob",Value=obj.Dob},
                new SqlParameter{ParameterName="@fee",Value=obj.Fee},
                new SqlParameter{ParameterName="@dept",Value=obj.Dept},
                new SqlParameter{ParameterName="@status",Value=obj.status},
                new SqlParameter{ParameterName="@role",Value=obj.role},
                new SqlParameter{ParameterName="@RecordId",Value=obj.RecordId},

            };

            var res = _context.Database.ExecuteSqlRaw(sql, param.ToArray());
            if (res > 0)
            {
                return RedirectToAction("Display", "SpCurd");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
