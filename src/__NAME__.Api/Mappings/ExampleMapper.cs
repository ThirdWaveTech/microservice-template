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
            Mapper.CreateMap<ExampleEntity, ExampleModel>();
        }
    }
}