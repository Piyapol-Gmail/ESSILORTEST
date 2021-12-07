using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using TestESSILOR.Models;

namespace TestESSILOR.Controllers
{
    public class WebAPiController : ApiController
    {

        [System.Web.Mvc.HttpGet, System.Web.Http.Route("~/api/Books")]
        public async Task<List<Book>> GetBook(string bookid)
        {
            List<Book> list = new List<Book>();string sql = "";
            using (var context = new MyDBEntities())
            {
                if (bookid != null && bookid.Trim().Length > 0)
                {
                    sql = "select * from Books with (NOLOCK) where BookId = @param1";
                }
                else
                {
                    sql = "select * from Books with (NOLOCK) ";
                }

                var idParam = new SqlParameter
                {
                    ParameterName = "param1",
                    Value = bookid,
                };
                list = context.Database.SqlQuery<Book>(sql, idParam).ToList();
            }

            return list;
        }

        [System.Web.Http.HttpPost, System.Web.Http.Route("~/api/BookP")]
        public async Task<bool> AddNewBook(string Server, string Accountn, string EmpID, string Plant, string sMenu)
        {
            bool rs;
            try
            {
                using (var context = new MyDBEntities())
                {
                    context.Books.Add(new Book()
                    {
                        BookId = "B001",
                        Author = "Bank Wisarut",
                        summary = "2",
                        ISBN = "TH",
                        genre = "Sci-Fi",
                        URL = "https://google.com",

                    });
                    context.SaveChanges();
                    rs = true;
                }
            }
            catch (Exception ex)
            {
                rs = false;
            }
            return rs;
        }
    }
}
