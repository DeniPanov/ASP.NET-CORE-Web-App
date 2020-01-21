using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiaryDiary.Data
{
    public class ApiaryDiaryDbContext : IdentityDbContext
    {
        public ApiaryDiaryDbContext(DbContextOptions<ApiaryDiaryDbContext> options)
            : base(options)
        {
        }
    }
}
