﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD._9951.DAL.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public DateTime RegistrationDate { get; set; }
		public ICollection<FitnessActivity> FitnessActivities { get; set; }
	}
}
