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
    public class LoaihangsController : ControllerBase
    {
        private readonly Ql_CuaHangDT_AndroidContext _context;

        public LoaihangsController(Ql_CuaHangDT_AndroidContext context)
        {
            _context = context;
        }

        // GET: api/Loaihangs
        [HttpGet]
        public IEnumerable<Loaihang> GetLoaihang()
        {
            return _context.Loaihang;
        }

        // GET: api/Loaihangs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoaihang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loaihang = await _context.Loaihang.FindAsync(id);

            if (loaihang == null)
            {
                return NotFound();
            }

            return Ok(loaihang);
        }

        // PUT: api/Loaihangs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaihang([FromRoute] string id, [FromBody] Loaihang loaihang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != loaihang.Maloai)
            {
                return BadRequest();
            }

            _context.Entry(loaihang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaihangExists(id))
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

        // POST: api/Loaihangs
        [HttpPost]
        public async Task<IActionResult> PostLoaihang([FromBody] Loaihang loaihang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Loaihang.Add(loaihang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoaihangExists(loaihang.Maloai))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoaihang", new { id = loaihang.Maloai }, loaihang);
        }

        // DELETE: api/Loaihangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoaihang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var loaihang = await _context.Loaihang.FindAsync(id);
            if (loaihang == null)
            {
                return NotFound();
            }

            _context.Loaihang.Remove(loaihang);
            await _context.SaveChangesAsync();

            return Ok(loaihang);
        }

        private bool LoaihangExists(string id)
        {
            return _context.Loaihang.Any(e => e.Maloai == id);
        }
    }
}