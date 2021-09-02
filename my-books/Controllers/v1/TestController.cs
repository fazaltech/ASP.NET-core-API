using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]

    [ApiVersion("1.6")]
    
    [Route("api/[controller]")]
   // [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        [HttpGet("get-test-data")]
        public IActionResult GetV1() 
        {
            return Ok("This is TestController V1.0");
        }


        [HttpGet("get-test-data"), MapToApiVersion("1.1")]
        public IActionResult Getv11()
        {
            return Ok("This is TestController V1.1");
        }
        [HttpGet("get-test-data"),MapToApiVersion("1.6")]
        public IActionResult Getv16()
        {
            return Ok("This is TestController V1.6");
        }

    }
}
