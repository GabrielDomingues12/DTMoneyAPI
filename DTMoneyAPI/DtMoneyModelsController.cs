using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DTMoneyAPI.Models;

namespace DTMoneyAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class DtMoneyModelsController : ControllerBase
    {
        private readonly DtMoneyContext _context;

        public DtMoneyModelsController(DtMoneyContext context)
        {
            _context = context;
        }

        // GET: api/DtMoneyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DtMoneyModel>>> GetdtMoneyModels()
        {
            return await _context.dtMoneyModels.ToListAsync();
        }

        // GET: api/DtMoneyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DtMoneyModel>> GetDtMoneyModel(int id)
        {
            var dtMoneyModel = await _context.dtMoneyModels.FindAsync(id);

            if (dtMoneyModel == null)
            {
                return NotFound();
            }

            return dtMoneyModel;
        }

        // PUT: api/DtMoneyModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDtMoneyModel(int id, DtMoneyModel dtMoneyModel)
        {
            if (id != dtMoneyModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(dtMoneyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DtMoneyModelExists(id))
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

        // POST: api/DtMoneyModels
        [HttpPost]
        public async Task<ActionResult<DtMoneyModel>> PostDtMoneyModel(DtMoneyModel dtMoneyModel)
        {
            _context.dtMoneyModels.Add(dtMoneyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDtMoneyModel), new { id = dtMoneyModel.Id }, dtMoneyModel);
        }

        // DELETE: api/DtMoneyModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDtMoneyModel(int id)
        {
            var dtMoneyModel = await _context.dtMoneyModels.FindAsync(id);
            if (dtMoneyModel == null)
            {
                return NotFound();
            }

            _context.dtMoneyModels.Remove(dtMoneyModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DtMoneyModelExists(int id)
        {
            return _context.dtMoneyModels.Any(e => e.Id == id);
        }
    }
}
