using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsCRUD.Shared
{
    public class Contact
    {
        // Model reprezentujący kontakt
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public Category? Category { get; set; }
        public string Note { get; set; } = string.Empty;
        public int CategoryId { get; set; }

    }
}
