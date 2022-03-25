using LatinDecoderDAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            return Json(new { words = wordList });
        }

    }
}
