using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTwoApi.Shared
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "The field {0} must be filled")]
        [DisplayName("First Name")]
        public string? StudentFirstName { get; set; }

        [Required(ErrorMessage = "The field {0} must be filled")]
        [DisplayName("Last Name")]
        public string? StudentLastName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be filled")]
        [DisplayName("Career")]
        public int? StudentCareerId { get; set; }

        [Required(ErrorMessage = "The field {0} must be filled")]
        [DisplayName("Admission Date")]
        public DateTime? StudentAdmissionDate { get; set; }

        public DateTime? RegisterDate { get; set; }

        public CareerDTO? Career { get; set; }
    }
}
