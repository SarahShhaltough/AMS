using System;

namespace AMS.Data.Model
{
    public class Lookup
    {
        // Attributes
        public Guid LookupMajorID { get; set; }
        public Guid LookupMinorID { get; set; }
        public Guid LookupMajorType { get; set; }
        public Guid LookupMinorType { get; set; }
        public Guid IsEditable { get; set; }

        // Relations
    }
}
