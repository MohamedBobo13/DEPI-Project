﻿using Microsoft.EntityFrameworkCore;
using OnlineEducationPlatform.DAL.Data.DBHelper;
using OnlineEducationPlatform.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEducationPlatform.DAL.Repo.AnswerRepo
{
    public class AnswerRepo : IAnswerRepo
    {
        private readonly EducationPlatformContext _context;

        public AnswerRepo(EducationPlatformContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Answer>> GetAllAsync()
        {
            return await _context.Answer.AsNoTracking().ToListAsync();
        }
        public async Task<Answer> GetByIdAsnyc(int id)
        {
            return await _context.Answer.FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task AddAsync(Answer answer)
        {
            await _context.AddAsync(answer);
            await SaveChangeAsync();
        }
        public async Task UpdateAsync(Answer answer)
        {
            _context.Update(answer);
            await SaveChangeAsync();
        }
        public async Task DeleteAsync(Answer answer)
        {
            answer.IsDeleted = true;
            _context.Update(answer);
            await SaveChangeAsync();
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}