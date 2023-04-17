using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(WRMTHDbContext context) : base(context)
        {
        }
    }
}
