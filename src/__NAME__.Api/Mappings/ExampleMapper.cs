using AutoMapper;
using Crux.Core.Bootstrapping;
using __NAME__.Domain;
using __NAME__.Models.Example;

namespace __NAME__.Api.Mappings
{
    public class ExampleMapper : IRunAtStartup
    {
        public void Init()
        {
            Mapper.CreateMap<ExampleEntity, ExampleModel>()
                .ForMember(x => x.Id, m => m.MapFrom(x => x.ID))
                .ForMember(x => x.Status, m => m.MapFrom(x => (int)x.Status))
                .ForMember(x => x.DateCreated, m => m.MapFrom(x => x.Timestamp.DateCreated))
                .ForMember(x => x.DateUpdated, m => m.MapFrom(x => x.Timestamp.DateUpdated))
                ;
        }
    }
}