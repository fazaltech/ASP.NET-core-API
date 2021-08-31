using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using my_books.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {


        private PublishersService _publisherService;

        public PublishersController(PublishersService publisherService)
        {
            _publisherService = publisherService;
        }



        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publisherService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);

            }

            catch (PublisherNameException ex) 
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpGet("get-publisher-by-id/{id}")]
        public ActionResult<Publisher> GetPublisherById(int id)
        {
            

            var _respone = _publisherService.GetPublisherById(id);

            if (_respone != null)
            {
                // return Ok(_respone);
             
              return _respone;
                
            }
            else 
            {
                   return NotFound();

                
            }
     

        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id) 
        {
            var _respone = _publisherService.GetPublisherData(id);
            return Ok(_respone);
        
        }


        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherById(int id) 
        {

            try
            {
                _publisherService.DeletePublisherById(id);
                return Ok();

            }
            
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            
        }
    }
}
