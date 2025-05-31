using Database.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.dto
{
    public class SearchFilterDTO
    {
        public DateTime createDateFirst = DateTime.MinValue;
        public DateTime createDateLast = DateTime.MaxValue;
        public string firstName;
        public string lastName;
        public string surname;
        public Device device;
    }
}
