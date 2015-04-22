using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crux.Domain.Entities;
using Crux.NancyFx.Infrastructure.Extensions;
using Nancy;
using __NAME__.Domain.Examples;
using __NAME__.MessageBus.Client.Examples;
using __NAME__.Models.Examples;

namespace __NAME__.Api.App.Example
{
    public class ExampleModule : NancyModule
    {
        public ExampleModule(IRepositoryOfId<int> repository, IMappingEngine engine, ExampleSender sender)
        {
            Get["/examples"] = _ => repository.Query<ExampleEntity>()
                .Project().To<ExampleModel>()
                .ToList();

            Get["/example/{id:int}"] = _ => {
                var entity = repository.Load<ExampleEntity>(_.id);
                return engine.Map<ExampleEntity, ExampleModel>(entity);
            };

            Post["/examples"] = _ => {
                var model = this.BindAndValidateModel<NewExampleModel>();
                var entity = new ExampleEntity(model.Name);
                repository.Save(entity);

                return new NewExampleCreatedModel { Id = entity.ID };
            };

            Post["/examples/close"] = _ => {
                var model = this.BindAndValidateModel<CloseExampleModel>();

                sender.CloseExample(model.Id);

                return HttpStatusCode.OK;
            };

            Delete["/example/{id:int}"] = _ => {
                repository.Delete<ExampleEntity>(_.id);
                return HttpStatusCode.OK;
            };
        }
    }
}