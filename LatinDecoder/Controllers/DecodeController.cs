using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LatinDecoderDAL;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LatinDecoder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DecodeController : Controller
    {
        [HttpGet("{token}")]
        public IActionResult GetWords([FromRoute] string token)
        {
            WordDataAccess _WordDataAccess = new WordDataAccess();
            List<string> wordList = _WordDataAccess.GetWordListSentence(token);
            return Json(new { words = wordList});
        }
        
    }
}
