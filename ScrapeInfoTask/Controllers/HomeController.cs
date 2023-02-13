using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScrapeInfoTask.Models;

namespace ScrapeInfoTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        TestContext _context = new TestContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listOfData = _context.ScrapeInfos.ToList();
            return View(listOfData);
        }

        [HttpPost]
        public ActionResult Index(DateTime dtFrom, DateTime dtTo)
        {
            ViewBag.DateFrom = dtFrom;
            ViewBag.DateTo = dtTo;

            var listOfDataByDate = _context.ScrapeInfos.
            Where(s => s.DateTime >= dtFrom && s.DateTime <= dtTo).ToList();

            return View(listOfDataByDate);

        }

        public IActionResult Converter()
        {
            //string fileName = Path.GetTempFileName();
            //file.SaveAs(fileName);

            //string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0;";
            //OleDbConnection connection = new OleDbConnection(connectionString);
            //connection.Open();

            //System.Data.DataTable dt = new System.Data.DataTable();
            //OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connection);
            //adapter.Fill(dt);

            //connection.Close();

            //Application wordApp = new Application();
            //Document wordDoc = wordApp.Documents.Add();

            //Table table = wordDoc.Tables.Add(wordDoc.Range(), dt.Rows.Count + 1, dt.Columns.Count);

            //// Add header row
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    table.Rows[1].Cells[i + 1].Range.Text = dt.Columns[i].ColumnName;
            //}

            //// Add data rows
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        table.Rows[i + 2].Cells[j + 1].Range.Text = dt.Rows[i][j].ToString();
            //    }
            //}

            //string savePath = Path.ChangeExtension(fileName, ".docx");
            //wordDoc.SaveAs2(savePath);
            //wordDoc.Close();
            //wordApp.Quit();

            //byte[] fileBytes = System.IO.File.ReadAllBytes(savePath);
            //return File(fileBytes, "application/msword", "ExcelToWord.docx");



            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Delete(int id)
        {
            var data = _context.ScrapeInfos.Where(s => s.Id == id).FirstOrDefault();
            _context.ScrapeInfos.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
