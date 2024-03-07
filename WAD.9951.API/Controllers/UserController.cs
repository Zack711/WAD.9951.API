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
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserController(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<List<UserDto>>> GetAllUsers()
		{
			var users = await _userRepository.GetAll();
			var userDtos = _mapper.Map<List<UserDto>>(users);
			return Ok(userDtos);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<UserDto>> GetUserById(int id)
		{
			var user = await _userRepository.GetById(id);
			if (user == null)
			{
				return NotFound();
			}
			var userDto = _mapper.Map<UserDto>(user);
			return Ok(userDto);
		}

		[HttpPost]
		public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
		{
			var user = _mapper.Map<User>(userDto);
			await _userRepository.Add(user);
			userDto.Id = user.Id; // Update the DTO with the newly generated ID
			return Ok(userDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(int id, UserDto userDto)
		{
			if (id != userDto.Id)
			{
				return BadRequest();
			}

			var existingUser = await _userRepository.GetById(id);
			if (existingUser == null)
			{
				return NotFound();
			}

			var user = _mapper.Map<User>(userDto);
			await _userRepository.Update(id, user);

			return Ok("Updated");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _userRepository.GetById(id);
			if (user == null)
			{
				return NotFound();
			}

			await _userRepository.Delete(id);
			return Ok("Deleted");
		}
	}
}
