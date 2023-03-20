using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CategoriesServis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        //var => buraya neden var yazamıyorum.. bunu araştırın. bu apigateway, iis, publish vb. herşeyden daha önemlidir..
        List<string> katList = new List<string>() { "A Kategorisi", "B Kategorsi", "C Kategorisi", "D Kategorisi" };

        public IActionResult Get()
        {
            return Ok(katList);
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            try
            {
                string val = katList[index];
                return Ok(val);
            }
            catch
            {
                return NotFound("Kaynak bulunamadı...");
            } 
        }

        [HttpPost]
        public IActionResult Post(RequestModel model)
        {
            katList.Add(model.Name);

            ResponseModel retVal = new ResponseModel();
            retVal.Message = $"Tebrikler {model.Name} adlı kategori eklendi....";
            retVal.Data = katList;
            return Ok(retVal);
        }
    }

    public class RequestModel
    {
        public string Name { get; set; }
    }
    public class ResponseModel
    {
       public string Message { get; set; }

        public List<string> Data { get; set; }
    }
}
