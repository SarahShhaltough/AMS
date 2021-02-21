using AMS.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Data
{
    public static class DBInitializer
    {
        public static void Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();
            //context.Database.Migrate();

            if (!context.Branches.Any())
            {
                var branches = new Branch[]
                   {
                    new Branch { BranchName = "DrNartClinic", IsActive = true},
                   };
                context.Branches.AddRange(branches);
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                var roles = new Role[]
                   {
                    new Role { RoleName = "Admin", IsActive = true},
                    new Role { RoleName = "Docotr", IsActive = true},
                    new Role { RoleName = "Patient", IsActive = true},
                   };
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new User[]
                   {
                    new User { UserFullName = "Nart Wardam",  UserName = "NWardam" ,UserEmail = "adiga-s@hotmail.com", UserPassword = "123456", IsActive = true , BranchID = 1,RoleID = 1},
                    new User { UserFullName = "Sarh Mohammad",  UserName = "SarahMohammad" , IsActive = true , BranchID = 1, RoleID = 2},
                    new User { UserFullName = "Osama Alsoqi",  UserName = "OAlsoqi" , IsActive = true , BranchID = 1, RoleID = 2},
                    new User { UserFullName = "Omar Ghalib",  UserName = "OGhalib" , IsActive = true , BranchID = 1, RoleID = 2},
                   };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}
