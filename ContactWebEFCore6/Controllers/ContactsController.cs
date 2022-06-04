using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactWebModels;
using MyContactManagerData;
using ContactWebEFCore6.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ContactWebEFCore6.Controllers
{
    public class ContactsController : Controller
    {
        private readonly MyContactManagerDBContext _context;
        private static List<State> _allStates;
        private static SelectList _statesData;
        private IMemoryCache _cache;

        public ContactsController(MyContactManagerDBContext context, IMemoryCache cache)
        {
            _cache = cache;
            _context = context;
            SetAllStatesCachingData();
            _statesData = new SelectList(_allStates, "Id", "Abbreviation");

        }

        private void SetAllStatesCachingData()
        {
            var allStates = new List<State>();
            if (!_cache.TryGetValue(ContactCacheConstants.ALL_STATES, out allStates))
            {
                var allStatesData = Task.Run(() => _context.States.ToListAsync()).Result;
                _cache.Set(ContactCacheConstants.ALL_STATES, allStatesData, TimeSpan.FromDays(1));
                allStates = allStatesData;
            }
            _allStates = allStates;

        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var myContactManagerDBContext = _context.Contacts.Include(c => c.State);
            return View(await myContactManagerDBContext.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Birthday,PhonePrimary,PhoneSecondary,StreetAddress1,StreetAddress2,City,Zip,StateId,UserId")] Contact contact)
        {
            await UpdateStateAndResetModelState(contact);

            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation", contact.StateId);
            return View(contact);
        }

        private Task UpdateStateAndResetModelState(Contact contact)
        {
            ModelState.Clear();
            var state = _context.States.SingleOrDefault(x => x.Id == contact.StateId);
            contact.State = state;
            TryValidateModel(contact);
            return Task.CompletedTask;

        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation", contact.StateId);
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Birthday,PhonePrimary,PhoneSecondary,StreetAddress1,StreetAddress2,City,Zip,StateId,UserId")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
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
            ViewData["StateId"] = new SelectList(_context.States, "Id", "Abbreviation", contact.StateId);
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.State)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'MyContactManagerDBContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
