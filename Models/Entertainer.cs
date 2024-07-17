using System.ComponentModel.DataAnnotations;

namespace FinalMission_pthoma24.Models
{
    public class Entertainer
    {
        [Key]
        [Required]
        public int EntertainerID { get; set; }
        [Required]
        public string? EntStageName { get; set; }
        [Required]
        public string? EntSSN { get; set; }
        [Required]
        public string? EntStreetAddress { get; set; }
        [Required]
        public string? EntCity { get; set; }
        [Required]
        public string? EntState { get; set; }
        [Required]
        public string? EntZipCode { get; set; }
        [Required]
        public string? EntPhoneNumber { get; set; }
        public string EntWebPage { get; set; }
        public string EntEMailAddress { get; set; }
        [Required]
        public string? DateEntered { get; set; }
    }
}
