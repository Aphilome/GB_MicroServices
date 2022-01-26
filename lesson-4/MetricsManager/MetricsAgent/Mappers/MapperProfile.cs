using AutoMapper;
using Metrics.Data.Dto;
using Metrics.Data.Entity;

namespace MetricsAgent.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
        }
    }
}
