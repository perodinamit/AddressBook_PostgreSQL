using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactBook_PostgreSQL.Models;
using ContactBook_PostgreSQL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactBook_PostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        IPhoneRepository phoneRepository;
        public PhoneController(IPhoneRepository _phoneRepository)
        {
            phoneRepository = _phoneRepository;
        }

        [HttpGet]
        [Route("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            try
            {
                var contacts = await phoneRepository.GetContacts();
                if (contacts == null)
                {
                    return NotFound();
                }

                return Ok(contacts);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetPhones")]
        public async Task<IActionResult> GetPhones()
        {
            try
            {
                var phones = await phoneRepository.GetPhones();
                if (phones == null)
                {
                    return NotFound();
                }

                return Ok(phones);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetPhone")]
        public async Task<IActionResult> GetPhone(int? phoneId)
        {
            if (phoneId == null)
            {
                return BadRequest();
            }

            try
            {
                var phone = await phoneRepository.GetPhone(phoneId);

                if (phone == null)
                {
                    return NotFound();
                }

                return Ok(phone);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddPhone")]
        public async Task<IActionResult> AddPhone([FromBody]Phone model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var phoneId = await phoneRepository.AddPhone(model);
                    if (phoneId > 0)
                    {
                        return Ok(phoneId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeletePhone")]
        public async Task<IActionResult> DeletePhone(int? phoneId)
        {
            int result = 0;

            if (phoneId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await phoneRepository.DeletePhone(phoneId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("UpdatePhone")]
        public async Task<IActionResult> UpdatePhone([FromBody]Phone model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await phoneRepository.UpdatePhone(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName ==
                             "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }

    }
}
