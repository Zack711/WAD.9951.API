using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._9951.DAL.Dtos;
using WAD._9951.DAL.Interfaces;
using WAD._9951.DAL.Models;
using WAD._9951.DAL.Repositories;

namespace WAD._9951.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FitnessActivityController : ControllerBase
	{
		private readonly IFitnessActivityRepository _activityRepository;
		private readonly IMapper _mapper;

		public FitnessActivityController(IFitnessActivityRepository activityRepository, IMapper mapper)
		{
			_activityRepository = activityRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task <ActionResult<List<FitnessActivityDto>>> GetAllActivities()
		{
			var activities = await _activityRepository.GetAll();
			var activityDtos = _mapper.Map<List<FitnessActivityDto>>(activities);
			return Ok(activityDtos);
		}

		[HttpGet("{id}")]
		public async Task <ActionResult<FitnessActivityDto>> GetActivityById(int id)
		{
			var activity = await _activityRepository.GetById(id);
			if (activity == null)
			{
				return NotFound();
			}
			var activityDto = _mapper.Map<FitnessActivityDto>(activity);
			return Ok(activityDto);
		}

		[HttpPost]
		public async Task <ActionResult<FitnessActivityDto>> CreateActivity(FitnessActivityDto activityDto)
		{
			var activity = _mapper.Map<FitnessActivity>(activityDto);
			await _activityRepository.Add(activity);
			return Ok(activityDto);
		}

		[HttpPut("{id}")]
		public async Task <IActionResult> UpdateActivity(int id, FitnessActivityDto activityDto)
		{
			var existingActivity = await _activityRepository.GetById(id);
			if (existingActivity == null)
			{
				return NotFound();
			}

			var activity = _mapper.Map<FitnessActivity>(activityDto);
			await _activityRepository.Update(id, activity);

			return Ok("Updated" + activityDto.Id);
		}

		[HttpDelete("{id}")]
		public async Task <IActionResult> DeleteActivity(int id)
		{
			var activity = await _activityRepository.GetById(id);
			if (activity == null)
			{
				return NotFound();
			}

			await _activityRepository.Delete(id);
			return Ok("Deleted" + activity.Id);
		}
	}
}
