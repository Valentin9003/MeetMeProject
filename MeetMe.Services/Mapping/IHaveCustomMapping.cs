using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetMe.Services.Mapping
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
