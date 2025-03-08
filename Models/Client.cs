using Google.Cloud.Firestore;
using System;
using System.ComponentModel.DataAnnotations;

namespace EventRegistration.Models
{
    [FirestoreData]  // ✅ Firestore treats this class as a Firestore document
    public class Client
    {
        [FirestoreDocumentId]  // ✅ Firestore will use this as the unique ID
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [FirestoreProperty]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
        public string Name { get; set; } = string.Empty;

        [FirestoreProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(50, ErrorMessage = "Email cannot exceed 50 characters.")]
        public string Email { get; set; } = string.Empty;

        [FirestoreProperty]
        [Required(ErrorMessage = "Gender is required.")]
        [RegularExpression("M|F", ErrorMessage = "Gender must be 'M' or 'F'.")]
        public string Gender { get; set; } = "M";  // ✅ Changed from `char` to `string`

        [FirestoreProperty]
        [Required(ErrorMessage = "Date registered is required.")]
        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; } = DateTime.UtcNow;


        [FirestoreProperty]
        public string SelectedDays { get; set; } = string.Empty;

        [FirestoreProperty]
        [StringLength(100, ErrorMessage = "Additional request cannot exceed 100 characters.")]
        public string AdditionalRequest { get; set; } = string.Empty;
    }
}
