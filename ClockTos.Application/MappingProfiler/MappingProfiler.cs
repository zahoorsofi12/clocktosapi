using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClockTos.Application.RRModels;
using ClockTos.Domain.Entities;

namespace ClockTos.Application.MappingProfiler
{
    public class College:Profile
    {
        public College()
        {
            CreateMap<CollegeRequest, Colleges>();
            CreateMap<Colleges, CollegeResponse>();
        }
    }
    public class Designation:Profile
    {
        public Designation()
        {
            CreateMap<DesignationRequest, Designations>();
            CreateMap<Designations, DesignationResponse>();
        }
    }
}
