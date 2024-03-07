using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD._9951.DAL.Models
{
	public class FitnessActivity
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public User User { get; set; }
		public DateTime Date { get; set; }
		public string ActivityType { get; set; }
		public int DurationInMinutes { get; set; }
		public decimal CaloriesBurned { get; set; }
	}
}
