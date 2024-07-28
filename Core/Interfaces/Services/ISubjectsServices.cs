using Core.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ISubjectsServices
    {
        Task<IReadOnlyList<Subject>> GetAllAsync();
        Task<Subject> GetByIdAsync(Guid Id);
        Task<bool> Exists(Guid Id);
        Task<Subject> Update(Guid Id, Subject request);
        Task<Subject> Delete(Guid Id);
        Task<Subject> Add(Subject request);
        Task<IReadOnlyList<Subject>> GetByClassIdAsync(Guid? ClassDetailsId);
    }
}
