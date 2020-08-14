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
    public class NhacungcapsController : ControllerBase
    {
        private readonly Ql_CuaHangDT_AndroidContext _context;

        public NhacungcapsController(Ql_CuaHangDT_AndroidContext context)
        {
            _context = context;
        }

        // GET: api/Nhacungcaps
        [HttpGet]
        public IEnumerable<Nhacungcap> GetNhacungcap()
        {
            return _context.Nhacungcap;
        }

        // GET: api/Nhacungcaps/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhacungcap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);

            if (nhacungcap == null)
            {
                return NotFound();
            }

            return Ok(nhacungcap);
        }

        // PUT: api/Nhacungcaps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNhacungcap([FromRoute] string id, [FromBody] Nhacungcap nhacungcap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhacungcap.Mancc)
            {
                return BadRequest();
            }

            _context.Entry(nhacungcap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhacungcapExists(id))
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

        // POST: api/Nhacungcaps
        [HttpPost]
        public async Task<IActionResult> PostNhacungcap([FromBody] Nhacungcap nhacungcap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Nhacungcap.Add(nhacungcap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NhacungcapExists(nhacungcap.Mancc))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNhacungcap", new { id = nhacungcap.Mancc }, nhacungcap);
        }

        // DELETE: api/Nhacungcaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhacungcap([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nhacungcap = await _context.Nhacungcap.FindAsync(id);
            if (nhacungcap == null)
            {
                return NotFound();
            }

            _context.Nhacungcap.Remove(nhacungcap);
            await _context.SaveChangesAsync();

            return Ok(nhacungcap);
        }

        private bool NhacungcapExists(string id)
        {
            return _context.Nhacungcap.Any(e => e.Mancc == id);
        }
    }
}