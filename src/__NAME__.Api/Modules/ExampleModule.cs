using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crux.Domain.Entities;
using Crux.NancyFx.Infrastructure.Extensions;
using Nancy;
using Nancy.ModelBinding;
using NServiceBus;
using __NAME__.Domain;
using __NAME__.Messages.Commands;
using __NAME__.Models.Example;

namespace __NAME__.Api.Modules
{
    public class ExampleModule : NancyModule
    {
        public ExampleModule(IRepositoryOfId<int> repository, IMappingEngine engine, IBus bus)
        {
            Get["/examples"] = _ => repository.Query<ExampleEntity>().Project().To<ExampleModel>().ToList();

            Get["/example/{id:int}"] = _ => {
                var entity = repository.Load<ExampleEntity>(_.id);
                return engine.Map<ExampleEntity, ExampleModel>(entity);
            };

            Post["/examples"] = _ => {
                var model = this.Bind<NewExampleModel>();
                this.ValidateModel(model);

                var entity = new ExampleEntity(model.Name);
                repository.Save(entity);

                return new NewExampleCreatedModel { Id = entity.ID };
            };

            Post["/examples/close"] = _ => {
                var model = this.Bind<CloseExampleModel>();
                this.ValidateModel(model);

                bus.Send(new CloseExampleCommand {Id = model.Id});

                return HttpStatusCode.OK;
            };

            Delete["/example/{id:int}"] = _ => {
                repository.Delete<ExampleEntity>(_.id);
                return HttpStatusCode.OK;
            };
        }
    }
}