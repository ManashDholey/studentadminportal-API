using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;
using studentadminportal_API.Helpers;

namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [AuthorizeAttribute]
    public class ExpenseController : BaseApiController
    {
        private readonly IExpenseServices _expenseServices;
        private readonly IMapper _mapper;

        public ExpenseController(IExpenseServices expenseServices, IMapper mapper)
        {
            _expenseServices = expenseServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teacher = await _expenseServices.GetAllAsync();

            return Ok(_mapper.Map<List<ExpenseDTO>>(teacher));
        }

        [HttpGet]
        [Route("{expenseId:guid}"), ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid expenseId)
        {
            // Fetch Teacher Details
            var expance = await _expenseServices.GetByIdAsync(expenseId);
            // Return teacher
            if (expance == null){
                return NotFound();
            }
            return Ok(_mapper.Map<ExpenseDTO>(expance));
        }

        [HttpPut]
        [Route("{expenseId:guid}")]
        public async Task<IActionResult> UpdatAsync([FromRoute] Guid expenseId, [FromBody] ExpenseDTO request)
        {
            if (await _expenseServices.Exists(expenseId))
            {
                // Update Details
                var updatedTeacher = await _expenseServices.Update(expenseId, _mapper.Map<Expense>(request));

                if (updatedTeacher != null)
                {
                    return Ok(_mapper.Map<ExpenseDTO>(updatedTeacher));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{expenseId:guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid expenseId)
        {
            if (await _expenseServices.Exists(expenseId))
            {
                var expense = await _expenseServices.Delete(expenseId);
                return Ok(_mapper.Map<ExpenseDTO>(expense));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddAsync([FromBody] ExpenseDTO request)
        {
            var teacher = await _expenseServices.Add(_mapper.Map<Expense>(request));
            return CreatedAtAction(nameof(GetByIdAsync), new { expenseId = teacher.Id },
                _mapper.Map<ExpenseDTO>(teacher));
        }

    }
}
