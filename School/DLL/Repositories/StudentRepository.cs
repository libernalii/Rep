using BLL.Models;
using DLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SchooleContext _context;

        public StudentRepository(SchooleContext context)
        {
            _context = context;
        }

        public async Task Add(Student item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Student[]> GetAll()
        {
            return await _context.Set<Student>().ToArrayAsync();
        }

        public Task<Student> GetById(int id)
        {
            return _context.Set<Student>().FirstAsync(x => x.Id == id);
        }

        public async Task Update(int id, Student item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
