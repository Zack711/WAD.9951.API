using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._9951.DAL.Dtos;
using WAD._9951.DAL.Models;
using WAD._9951.DAL.Repositories;

namespace WAD._9951.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FitnessActivityController : ControllerBase
	{
		private readonly FitnessActivityRepository _activityRepository;
		private readonly IMapper _mapper;

		public FitnessActivityController(FitnessActivityRepository activityRepository, IMapper mapper)
		{
			_activityRepository = activityRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<List<FitnessActivityDto>> GetAllActivities()
		{
			var activities = _activityRepository.GetAll();
			var activityDtos = _mapper.Map<List<FitnessActivityDto>>(activities);
			return Ok(activityDtos);
		}

		[HttpGet("{id}")]
		public ActionResult<FitnessActivityDto> GetActivityById(int id)
		{
			var activity = _activityRepository.GetById(id);
			if (activity == null)
			{
				return NotFound();
			}
			var activityDto = _mapper.Map<FitnessActivityDto>(activity);
			return Ok(activityDto);
		}

		[HttpPost]
		public ActionResult<FitnessActivityDto> CreateActivity(FitnessActivityDto activityDto)
		{
			var activity = _mapper.Map<FitnessActivity>(activityDto);
			_activityRepository.Add(activity);
			activityDto.Id = activity.Id; // Update the DTO with the newly generated ID
			return Ok(activityDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateActivity(int id, FitnessActivityDto activityDto)
		{
			if (id != activityDto.Id)
			{
				return BadRequest();
			}

			var existingActivity = _activityRepository.GetById(id);
			if (existingActivity == null)
			{
				return NotFound();
			}

			var activity = _mapper.Map<FitnessActivity>(activityDto);
			_activityRepository.Update(activity);

			return Ok("Updated");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteActivity(int id)
		{
			var activity = _activityRepository.GetById(id);
			if (activity == null)
			{
				return NotFound();
			}

			_activityRepository.Delete(id);
			return Ok("Deleted");
		}
	}
}
