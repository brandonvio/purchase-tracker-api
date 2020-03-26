using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PurchaseTracker.Api.Models;
using PurchaseTracker.Api.Services;

namespace PurchaseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly BudgetDb _context;

        public PurchaseController(BudgetDb context)
        {
            _context = context;
        }

        // GET: api/Purchase
        [HttpGet]
        public async Task<ActionResult<PurchaseResponseModel>> GetPurchases()
        {
            var purchases = await _context
                .Purchases
                .Include(p => p.Category)
                .OrderBy(p => p.PurchaseDate)
                .ToListAsync();

            var responseModel = new PurchaseResponseModel
            {
                Purchases = purchases,
                PurchaseSummary =
                {
                    TotalPurchaseAmount = purchases.Sum(p => p.PurchaseAmount),
                    AveragePurchaseAmount = purchases.Average(p => p.PurchaseAmount),
                    TransactionCount = purchases.Count()
                }
            };

            return responseModel;
        }

        // GET: api/Purchase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseModel>> GetPurchaseModel(int id)
        {
            var purchaseModel = await _context.Purchases.FindAsync(id);

            if (purchaseModel == null)
            {
                return NotFound();
            }

            return purchaseModel;
        }

        // PUT: api/Purchase/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchaseModel(int id, PurchaseModel purchaseModel)
        {
            if (id != purchaseModel.PurchaseId)
            {
                return BadRequest();
            }

            _context.Entry(purchaseModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseModelExists(id))
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

        // POST: api/Purchase
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PurchaseModel>> PostPurchaseModel(PurchaseModel purchaseModel)
        {
            _context.Purchases.Add(purchaseModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchaseModel", new { id = purchaseModel.PurchaseId }, purchaseModel);
        }

        // DELETE: api/Purchase/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PurchaseModel>> DeletePurchaseModel(int id)
        {
            var purchaseModel = await _context.Purchases.FindAsync(id);
            if (purchaseModel == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchaseModel);
            await _context.SaveChangesAsync();

            return purchaseModel;
        }

        private bool PurchaseModelExists(long id)
        {
            return _context.Purchases.Any(e => e.PurchaseId == id);
        }
    }
}
