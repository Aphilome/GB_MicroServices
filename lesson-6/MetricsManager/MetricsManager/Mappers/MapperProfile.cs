using AutoMapper;
using Metrics.Data.Dto;
using Metrics.Data.Entity;

namespace MetricsManager.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CpuMetric, CpuMetricDto>();
            CreateMap<DotNetMetric, DotNetMetricDto>();
            CreateMap<HddMetric, HddMetricDto>();
            CreateMap<NetworkMetric, NetworkMetricDto>();
            CreateMap<RamMetric, RamMetricDto>();

            CreateMap<CpuMetricDto, CpuMetric>();
            CreateMap<DotNetMetricDto, DotNetMetric>();
            CreateMap<HddMetricDto, HddMetric>();
            CreateMap<NetworkMetricDto, NetworkMetric>();
            CreateMap<RamMetricDto, RamMetric>();
        }
    }
}
