using AutoMapper;
using BeginnerApiProject.WebApi.Context;
using BeginnerApiProject.WebApi.Dtos.FeatureDtos;
using BeginnerApiProject.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BeginnerApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFeatures()
        {
            var values = _context.Features.ToList();
            return Ok(_mapper.Map<List<ResultFeatureDto>>(values));
        }

        [HttpPost]
        public IActionResult AddFeature(CreateFeatureDto createFeatureDto)
        {
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _context.Features.Find(id);
            if (feature == null)
            {
                return NotFound();
            }
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var feature = _context.Features.Find(id);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetByIdFeatureDto>(feature));
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok();
        }
    }
}
