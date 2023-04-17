using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(WRMTHDbContext context) : base(context)
        {
        }
    }
}
