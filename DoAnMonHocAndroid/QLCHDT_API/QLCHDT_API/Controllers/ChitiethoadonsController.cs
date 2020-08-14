using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLCHDT_API.Models;

namespace QLCHDT_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChitiethoadonsController : ControllerBase
    {
        private readonly Ql_CuaHangDT_AndroidContext _context;

        public ChitiethoadonsController(Ql_CuaHangDT_AndroidContext context)
        {
            _context = context;
        }

        // GET: api/Chitiethoadons
        [HttpGet]
        public IEnumerable<Chitiethoadon> GetChitiethoadon()
        {
            return _context.Chitiethoadon;
        }

        // GET: api/Chitiethoadons/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChitiethoadon([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chitiethoadon = await _context.Chitiethoadon.FindAsync(id);

            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return Ok(chitiethoadon);
        }

        // PUT: api/Chitiethoadons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChitiethoadon([FromRoute] string id, [FromBody] Chitiethoadon chitiethoadon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chitiethoadon.Mahd)
            {
                return BadRequest();
            }

            _context.Entry(chitiethoadon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChitiethoadonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Chitiethoadons
        [HttpPost]
        public async Task<IActionResult> PostChitiethoadon([FromBody] Chitiethoadon chitiethoadon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Chitiethoadon.Add(chitiethoadon);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ChitiethoadonExists(chitiethoadon.Mahd))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetChitiethoadon", new { id = chitiethoadon.Mahd }, chitiethoadon);
        }

        // DELETE: api/Chitiethoadons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChitiethoadon([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chitiethoadon = await _context.Chitiethoadon.FindAsync(id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            _context.Chitiethoadon.Remove(chitiethoadon);
            await _context.SaveChangesAsync();

            return Ok(chitiethoadon);
        }

        private bool ChitiethoadonExists(string id)
        {
            return _context.Chitiethoadon.Any(e => e.Mahd == id);
        }
    }
}