using System;

namespace AMS.Data.Model
{
    public class Lookup
    {
        // Attributes
        public int LookupMajorID { get; set; }
        public int LookupMinorID { get; set; }
        public int LookupMajorType { get; set; }
        public int LookupMinorType { get; set; }
        public bool IsEditable { get; set; }

        // Relations
    }
}
