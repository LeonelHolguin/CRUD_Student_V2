using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTwoApi.Shared
{
    public class CareerDTO
    {
        public int CareerId { get; set; }

        [Required(ErrorMessage = "The field {0} must be filled")]
        [DisplayName("Career Name")]
        public string? CareerName { get; set; }
    }
}
