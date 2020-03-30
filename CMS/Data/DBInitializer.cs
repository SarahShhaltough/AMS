using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Data
{
    public static class DBInitializer
    {
        public static void Initialize(AppDBContext context) {
            context.Database.EnsureCreated();
        }
    }
}
