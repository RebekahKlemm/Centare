using System.Collections.Generic;

namespace CheckInWeb.Models
{

    public class MyCheckInViewModel
    {
        public IEnumerable<CheckInViewModel> CheckIns { get; set; }
    }
}