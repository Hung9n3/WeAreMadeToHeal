using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeAreMadeToHeal;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterModel, User>();
    }
}
