using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Data.DTO
{
    public class NoteDataDTO
    {
        public string Allergies { get; set; }
        public string SpecialPrecautions { get; set; }
        public string PastHistory { get; set; }
        public string FamilyHistory { get; set; }
        public string Notes { get; set; }
    }
}
