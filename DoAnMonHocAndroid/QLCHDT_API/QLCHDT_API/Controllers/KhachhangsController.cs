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
    public class KhachhangsController : ControllerBase
    {
        private readonly Ql_CuaHangDT_AndroidContext _context;

        public KhachhangsController(Ql_CuaHangDT_AndroidContext context)
        {
            _context = context;
        }

        // GET: api/Khachhangs
        [HttpGet]
        public IEnumerable<Khachhang> GetKhachhang()
        {
            return _context.Khachhang;
        }

        // GET: api/Khachhangs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKhachhang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var khachhang = await _context.Khachhang.FindAsync(id);

            if (khachhang == null)
            {
                return NotFound();
            }

            return Ok(khachhang);
        }

        // PUT: api/Khachhangs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhachhang([FromRoute] string id, [FromBody] Khachhang khachhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != khachhang.Makhachhang)
            {
                return BadRequest();
            }

            _context.Entry(khachhang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhachhangExists(id))
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

        // POST: api/Khachhangs
        [HttpPost]
        public async Task<IActionResult> PostKhachhang([FromBody] Khachhang khachhang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Khachhang.Add(khachhang);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhachhangExists(khachhang.Makhachhang))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhachhang", new { id = khachhang.Makhachhang }, khachhang);
        }

        // DELETE: api/Khachhangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhachhang([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }

            _context.Khachhang.Remove(khachhang);
            await _context.SaveChangesAsync();

            return Ok(khachhang);
        }

        private bool KhachhangExists(string id)
        {
            return _context.Khachhang.Any(e => e.Makhachhang == id);
        }
    }
}