﻿using studentadminportal_API.DataModels;

namespace studentadminportal_API.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<List<ClassDetail>> GetClassAsync();
        Task<ClassDetail> GetClassAsync(Guid classId);
        Task<bool> Exists(Guid classId);
        Task<ClassDetail> UpdateClass(Guid classId, ClassDetail request);
        Task<ClassDetail> DeleteClass(Guid classId);
        Task<ClassDetail> AddClass(ClassDetail request);
    }
}
