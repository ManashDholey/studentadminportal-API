using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;

namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ClassFeeController : BaseApiController
    {
        private readonly IClassFeeServices _classFeeServices;
        private readonly IMapper _mapper;

        public ClassFeeController(IClassFeeServices classFeeServices, IMapper mapper)
        {
            _classFeeServices = classFeeServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassFeesAsync()
        {
            var classFees = await _classFeeServices.GetClassFeesAsync();

            return Ok(_mapper.Map<List<FeesDTO>>(classFees));
        }

        [HttpGet]
        [Route("{classFeesId:guid}"), ActionName("GetClassFeesByIdAsync")]
        public async Task<IActionResult> GetClassFeesByIdAsync([FromRoute] Guid classFeesId)
        {
            // Fetch Fees Details
            var classFees = await _classFeeServices.GetClassFeesAsync(classFeesId);

            // Return fees
            if (classFees == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FeesDTO>(classFees));
        }

        [HttpPut]
        [Route("{classFeesId:guid}")]
        public async Task<IActionResult> UpdateClassAsync([FromRoute] Guid classFeesId, [FromBody] ClassDetailDTO request)
        {
            if (await _classFeeServices.Exists(classFeesId))
            {
                // Update Details
                var updatedClassFees = await _classFeeServices.UpdateClassFees(classFeesId, _mapper.Map<Fees>(request));

                if (updatedClassFees != null)
                {
                    return Ok(_mapper.Map<FeesDTO>(updatedClassFees));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{classFeesId:guid}")]
        public async Task<IActionResult> DeleteClassFeesAsync([FromRoute] Guid classFeesId)
        {
            if (await _classFeeServices.Exists(classFeesId))
            {
                var classFeesDetail = await _classFeeServices.DeleteClassFees(classFeesId);
                return Ok(_mapper.Map<FeesDTO>(classFeesDetail));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddClassAsync([FromBody] FeesDTO request)
        {
            var classFeesDetails = await _classFeeServices.AddClassFees(_mapper.Map<Fees>(request));
            return CreatedAtAction(nameof(GetClassFeesByIdAsync), new { classFeesId = classFeesDetails.Id },
                _mapper.Map<FeesDTO>(classFeesDetails));
        }


    }
}
