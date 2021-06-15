using ContactManagement.DataAccess.Entities;
using ContactManagement.DataAccess.Interfaces.Contact;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : Controller
    {
        private readonly IContactsRepository _contactsRepository;
        public ContactsController(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository ??
                throw new ArgumentNullException(nameof(contactsRepository));
        }

        /// <summary>
        /// Create new Contact API
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            _contactsRepository.AddContact(item);
            return CreatedAtRoute("GetContacts", new { Controller = "Contacts", id = item.Id }, item);
        }

        /// <summary>
        /// Update Contact details API
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Contacts item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            var contactObj = _contactsRepository.FindContact(id);
            if (contactObj == null)
            {
                return NotFound();
            }

            return Ok(_contactsRepository.UpdateContact(item));
        }

        /// <summary>
        /// Delete Contact details API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _contactsRepository.DeleteContact(id);
            return NoContent();
        }
        
        /// <summary>
        /// Get all contact details API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> GetAllContacts()
        {
            return Ok(_contactsRepository.GetAllContacts());
        }

        /// <summary>
        /// Get contact details by Contact ID API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetContacts")]
        public ActionResult GetContactById(int id)
        {
            var item = _contactsRepository.FindContact(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
