using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotels.Models
{
    public class SearchCriteriaModel : IValidatableObject
    {
        [Display(Name = "Going to")]
        public string DestinationName { get; set; }

        [Display(Name = "City")]
        public string DestinationCity { get; set; }

        [Display(Name = "Min Trip Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string MinTripStartDate { get; set; }

        [Display(Name = "Max Trip Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string MaxTripStartDate { get; set; }

        [Display(Name = "Length Of Stay")]
        public string LengthOfStay { get; set; }

        [Display(Name = "Min Property Class")]
        public string MinStarRating { get; set; }

        [Display(Name = "Max Property Class")]
        public string MaxStarRating { get; set; }

        [Display(Name = "Min Total Rate")]
        public string MinTotalRate { get; set; }

        [Display(Name = "Max Total Rate")]
        public string MaxTotalRate { get; set; }

        [Display(Name = "Min Guest Rating")]
        public string MinGuestRating { get; set; }

        [Display(Name = "Max Guest Rating")]
        public string MaxGuestRating { get; set; }    

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((!string.IsNullOrEmpty(MaxTripStartDate) && !string.IsNullOrEmpty(MinTripStartDate)) && (DateTime.Parse(MinTripStartDate) > DateTime.Parse(MaxTripStartDate)))
            {
                yield return
                  new ValidationResult(errorMessage: "EndDate must be greater than StartDate",
                                       memberNames: new[] { "MaxTripStartDate" });
            }

            if ((!string.IsNullOrEmpty(MaxStarRating) && !string.IsNullOrEmpty(MinStarRating)) && (int.Parse(MinStarRating) > int.Parse(MaxStarRating)))
            {
                yield return
                  new ValidationResult(errorMessage: "Max Class must be greater than Min Class",
                                       memberNames: new[] { "MaxStarRating" });
            }
        }
    }
}