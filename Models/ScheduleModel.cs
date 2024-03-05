using System.ComponentModel.DataAnnotations;

namespace projApp.Model
{
    public class ScheduleModel {
        //prop

        public int Id { get; set; }
        // date and time
        [Required]
        public string? Date { get; set; }
        // therapy type
        [Required]
        public string? Therapy { get; set; }
        // therapy length, minutes
        [Required]
        public int? Length {get; set; }
        // if booked then fill booked By
        public string? BookedBy { get; set; }
        // true = booked time
        public bool Booked {get; set; } = false;

    }   
}