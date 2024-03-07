using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD._9951.DAL.Dtos;
using WAD._9951.DAL.Models;

namespace WAD._9951.DAL.Mapping
{
	public class UserMappings : Profile
	{
		public UserMappings()
		{
			CreateMap<User, UserDto>().ReverseMap();
		}
	}
}
