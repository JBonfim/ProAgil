using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Model;
using ProAgil.Repository.Data;
using ProAgil.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProAgil.Repository.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly DataContext _Context;

        public ProAgilRepository(DataContext Context)
        {
            this._Context = Context;
            _Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            this._Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this._Context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await this._Context.SaveChangesAsync() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            this._Context.Update(entity);
        }



        //Eventos

        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _Context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.Redesociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrateEventos);
                   // .ThenInclude(p => p)
            }

            query = query.AsNoTracking()
                .OrderByDescending(c => c.DataEvento);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventoAsyncById(int EventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _Context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.Redesociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrateEventos)
                    .ThenInclude(p => p.Paletrante);

            }

            query = query.AsNoTracking()
                .OrderByDescending(c => c.DataEvento)
                .Where(c => c.Id == EventoId);

            return await query.AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _Context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.Redesociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrateEventos)
                    .ThenInclude(p => p.Paletrante);
            }

            query = query.AsNoTracking()
                .OrderByDescending(c => c.DataEvento)
                .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        //Palestrantes
        public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string name,bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _Context.Palestrantes
               .Include(c => c.Redesociais);

            if (includeEvento)
            {
                query = query
                    .Include(pe => pe.PalestrateEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query.AsNoTracking()
                .OrderBy(c => c.Nome)
                .Where(c => c.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestranteAsyncById(int PalestranteId, bool includeEvento = false)
        {
            IQueryable<Palestrante> query = _Context.Palestrantes
              .Include(c => c.Redesociais);

            if (includeEvento)
            {
                query = query
                    .Include(pe => pe.PalestrateEventos)
                    .ThenInclude(e => e.Evento);
            }

            query = query
                .AsNoTracking()
                .Where(c => c.Id == PalestranteId);

            return await query.FirstOrDefaultAsync();
        }

       
    }
}
