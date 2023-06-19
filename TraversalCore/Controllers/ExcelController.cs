using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.ExtendedProperties;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCore.Models;

namespace TraversalCore.Controllers
{
    [AllowAnonymous]
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {

            return View(); 
        }
        public List<DestinationModel> DestinationList() 
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c=new Context()) 
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    City= x.City,
                    DayNight= x.DayNight,
                    Capacity= x.Capacity,
                    Price= x.Price,
                }).ToList();
            }
            return destinationModels;
        }
        public IActionResult StaticExcelReport() 
        {
            
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");
        }
        public IActionResult DestinationExcelReport() 
        {
            using (var workBook = new XLWorkbook()) 
            {
                var workSheet = workBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Kapasite";
                workSheet.Cell(1, 4).Value = "Fiyat";
                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount,1).Value = item.City;
                    workSheet.Cell(rowCount, 2).Value = item.DayNight;
                    workSheet.Cell(rowCount, 3).Value = item.Capacity;
                    workSheet.Cell(rowCount, 4).Value = item.Price;
                    rowCount++;
                }
                using(var stream=new MemoryStream()) 
                {
                    workBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }
            }
            
        }
    }
}
