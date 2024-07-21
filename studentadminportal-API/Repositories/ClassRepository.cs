using Microsoft.EntityFrameworkCore;
using studentadminportal_API.DataModels;
using studentadminportal_API.Repositories.Interfaces;

namespace studentadminportal_API.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly StudentAdminContext _context;

        public ClassRepository(StudentAdminContext context)
        {
            _context = context;
        }
        public async Task<ClassDetail> AddClass(ClassDetail request)
        {
            var classAdd = await _context.ClassDetails.AddAsync(request);
            await _context.SaveChangesAsync();
            return classAdd.Entity;
        }

        public async Task<ClassDetail> GetClassAsync(Guid classId)
        {
            return await _context.ClassDetails
                .FirstOrDefaultAsync(x => x.Id == classId);
        }
        public async Task<ClassDetail> DeleteClass(Guid classId)
        {
            var classDetails = await GetClassAsync(classId);

            if (classDetails != null)
            {
                _context.ClassDetails.Remove(classDetails);
                await _context.SaveChangesAsync();
                return classDetails;
            }
            return null;
        }

        public async Task<bool> Exists(Guid classId)
        {
            return await _context.ClassDetails.AnyAsync(x => x.Id == classId);
        }

        public async Task<List<ClassDetail>> GetClassAsync()
        {
            return await _context.ClassDetails.ToListAsync();
        }

        public async Task<ClassDetail> UpdateClass(Guid classId, ClassDetail request)
        {
            var existingClass = await GetClassAsync(classId);
            if (existingClass != null)
            {
                existingClass.ClassName = request.ClassName;
                existingClass.Status = request.Status;
                await _context.SaveChangesAsync();
                return existingClass;
            }
            return null;
        }
    }
}
