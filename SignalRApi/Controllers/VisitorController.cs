using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.DAL;
using SignalRApi.Model;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;
        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        [HttpGet]
        public async Task<IActionResult> CreateVisitor()
        {
            Random random = new Random();
            for (int x = 1; x <= 10; x++)
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = random.Next(100, 2000),
                        VisitDate = DateTime.UtcNow.AddDays(x)
                    };
                    await _visitorService.SaveVisitor(newVisitor);
                    await Task.Delay(1000);
                }
            }
            return Ok("Ziyaretçiler başarılı bir şekilde eklendi");
        }
    }
}
