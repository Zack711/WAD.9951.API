using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._9951.DAL.Dtos;
using WAD._9951.DAL.Models;
using WAD._9951.DAL.Repositories;

namespace WAD._9951.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly UserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserController(UserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public ActionResult<List<UserDto>> GetAllUsers()
		{
			var users = _userRepository.GetAll();
			var userDtos = _mapper.Map<List<UserDto>>(users);
			return Ok(userDtos);
		}

		[HttpGet("{id}")]
		public ActionResult<UserDto> GetUserById(int id)
		{
			var user = _userRepository.GetById(id);
			if (user == null)
			{
				return NotFound();
			}
			var userDto = _mapper.Map<UserDto>(user);
			return Ok(userDto);
		}

		[HttpPost]
		public ActionResult<UserDto> CreateUser(UserDto userDto)
		{
			var user = _mapper.Map<User>(userDto);
			_userRepository.Add(user);
			userDto.Id = user.Id; // Update the DTO with the newly generated ID
			return Ok(userDto);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateUser(int id, UserDto userDto)
		{
			if (id != userDto.Id)
			{
				return BadRequest();
			}

			var existingUser = _userRepository.GetById(id);
			if (existingUser == null)
			{
				return NotFound();
			}

			var user = _mapper.Map<User>(userDto);
			_userRepository.Update(user);

			return Ok("Updated");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteUser(int id)
		{
			var user = _userRepository.GetById(id);
			if (user == null)
			{
				return NotFound();
			}

			_userRepository.Delete(id);
			return Ok("Deleted");
		}
	}
}
