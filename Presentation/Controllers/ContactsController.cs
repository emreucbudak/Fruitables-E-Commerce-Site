using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Context;
using Services.Interfaces;
using Entities.DTO;
using Presentation.ActionFilters;
using System.Net.Mail;
using System.Net;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class ContactsController : ControllerBase
    {
        private readonly IServiceManager _context;

        public ContactsController(IServiceManager context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var x = await _context.ContactService.GetAllContact(false);
            return Ok(x);
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var x = await _context.ContactService.GetContact(id);
            return Ok(x);
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, ContactDto contact)
        {
            await _context.ContactService.UpdateContactFromService(id,contact);

            return NoContent();
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        public async Task<ActionResult<Contact>> PostContact([FromBody]ContactDto contact)
        {
            await _context.ContactService.AddContactFromService(contact);
            SendEmailToUser(contact.Email);

            return NoContent();
        }
        private void SendEmailToUser(string toEmail)
        {
            var fromEmail = "entazeceptedestek@gmail.com";
            var subject = "Mesajınız Alındı";
            var body = "Mesajınız alınmıştır, en kısa sürede dönüş yapılacaktır.";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587, // TLS için 587
                Credentials = new NetworkCredential("entazeceptedestek@gmail.com", "kusc zqdb ofse ulgh"), // Uygulama şifresi kullanın
                EnableSsl = true // SSL/TLS'yi etkinleştiriyoruz
            };

            var mailMessage = new MailMessage(fromEmail, toEmail, subject, body);

            try
            {
                smtpClient.Send(mailMessage);
                Console.WriteLine("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("E-posta gönderme hatası: " + ex.Message);
            }
        }


        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _context.ContactService.DeleteContactFromService(id);

            return NoContent();
        }

    }
}
