using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistration.Models
{
	public class Client
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Name is required.")]
		[StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
		public string Name { get; set; } = string.Empty;

		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Invalid email format.")]
		[StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
		public string Email { get; set; } = string.Empty;

		[Required(ErrorMessage = "Gender is required.")]
		[RegularExpression("M|F", ErrorMessage = "Gender must be 'M' or 'F'.")]
		public char Gender { get; set; }

		[Required(ErrorMessage = "Date registered is required.")]
		[DataType(DataType.Date)]
		[Range(typeof(DateTime), "2019-01-01", "2019-06-30",
			ErrorMessage = "Date must be between 01-Jan-2019 and 30-Jun-2019.")]
		public DateTime DateRegistered { get; set; } = DateTime.Now;

		public string SelectedDays { get; set; } = string.Empty;

		[StringLength(100, ErrorMessage = "Additional request cannot exceed 100 characters.")]
		public string AdditionalRequest { get; set; } = string.Empty;
	}
}
