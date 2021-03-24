using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NotarialOfficeRebuild.Data;
using NotarialOfficeRebuild.Models;
using NotarialOfficeRebuild.ViewModels;
using NotarialOfficeRebuild.ViewModels.Filters;

namespace NotarialOfficeRebuild.Controllers
{
    public class ContractsController : Controller
    {
        private readonly NotarialOfficeContext _context;

        public ContractsController(NotarialOfficeContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index(DateTime? subscriptionDate, DateTime? endDate, int? selectedClientId, int page = 1)
        {
            var pageSize = 10;
            var itemCount = _context.Contracts.Count();

            IQueryable<Contract> notarialOfficeContext = _context.Contracts;

            if (selectedClientId.HasValue && selectedClientId.Value != 0)
            {
                notarialOfficeContext = notarialOfficeContext.Where(c => c.ClientId == selectedClientId);
            }

            if (subscriptionDate.HasValue)
            {
                notarialOfficeContext = notarialOfficeContext.Where(c => c.SubscriptDate >= subscriptionDate.Value);
            }

            if (endDate.HasValue)
            {
                notarialOfficeContext = notarialOfficeContext.Where(c => c.EndDate <= endDate.Value);
            }

            notarialOfficeContext = notarialOfficeContext
                .Include(c => c.Client)
                .Include(c => c.Employee)
                .Include(c => c.Service)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return View(new ContractViewModel()
            {
                Contracts = await notarialOfficeContext.ToListAsync(),
                PageViewModel = new PageViewModel(itemCount, page, pageSize),
                ContractFilter = new ContractFilter(subscriptionDate, endDate, selectedClientId, await _context.Clients.ToListAsync())
            });
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Client)
                .Include(c => c.Employee)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FullName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName");
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubscriptDate,EndDate,ServiceId,EmployeeId,ClientId")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FullName", contract.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", contract.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", contract.ServiceId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FullName", contract.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", contract.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", contract.ServiceId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubscriptDate,EndDate,ServiceId,EmployeeId,ClientId")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "FullName", contract.ClientId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FullName", contract.EmployeeId);
            ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name", contract.ServiceId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts
                .Include(c => c.Client)
                .Include(c => c.Employee)
                .Include(c => c.Service)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.FindAsync(id);
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
