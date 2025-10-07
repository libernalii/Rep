using BLL.Models;
using DLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        private readonly SchooleContext _context;

        public TeacherRepository(SchooleContext context)
        {
            _context = context;
        }

        public async Task Add(Teacher item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Teacher item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Teacher[]> GetAll()
        {
            return await _context.Set<Teacher>().ToArrayAsync();
        }

        public Task<Teacher> GetById(int id)
        {
            return _context.Set<Teacher>().FirstAsync(x => x.Id == id);
        }

        public async Task Update(int id, Teacher item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
