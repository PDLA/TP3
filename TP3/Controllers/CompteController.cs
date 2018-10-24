﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3;
using TP3.Models.EntityFramework;

namespace TP3.Controllers
{
    [Produces("application/json")]
    [Route("api/Compte/[action]")]
    public class CompteController : Controller
    {
        private readonly FilmRatingsDBContext _context;

        public CompteController(FilmRatingsDBContext context)
        {
            _context = context;
        }

        // GET: api/Compte/5
        [HttpGet("{id}")]
        [ActionName("GetCompteById")]
        public async Task<IActionResult> GetCompteById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compte = await _context.Compte
                .Include(c => c.AvisCompte)
                .Include(c => c.FavorisCompte)
                .Where(c => c.CompteId == id)
                .SingleOrDefaultAsync();

            if (compte == null)
            {
                return NotFound();
            }

            return Ok(compte);
        }

        // PUT: api/Compte/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompte([FromRoute] int id, [FromBody] Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compte.CompteId)
            {
                return BadRequest();
            }

            _context.Entry(compte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteExists(id))
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

        // POST: api/Compte
        [HttpPost]
        public async Task<IActionResult> PostCompte([FromBody] Compte compte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Compte.Add(compte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompte", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Compte/5
        [HttpDelete("{id}")]
        /*public async Task<IActionResult> DeleteCompte([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compte = await _context.Compte.SingleOrDefaultAsync(m => m.CompteId == id);
            if (compte == null)
            {
                return NotFound();
            }

            _context.Compte.Remove(compte);
            await _context.SaveChangesAsync();

            return Ok(compte);
        }*/

        private bool CompteExists(int id)
        {
            return _context.Compte.Any(e => e.CompteId == id);
        }

        [HttpGet("{email}")]
        [ActionName("GetCompteByEmail")]
        public async Task<IActionResult> GetCompteByEmail([FromRoute] string email){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var compte = await _context.Compte
                .Include(c => c.AvisCompte)
                .Include(c => c.FavorisCompte)
                .Where(c => c.Mel.ToLower() == email.ToLower())
                .SingleOrDefaultAsync();

            if (compte == null)
            {
                return NotFound();
            }

            return Ok(compte);
        }

    }
}