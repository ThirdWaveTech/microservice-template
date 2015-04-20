using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Crux.Domain.Entities;
using Crux.NancyFx.Infrastructure.Extensions;
using Nancy;
using Nancy.ModelBinding;
using __NAME__.Domain;
using __NAME__.Models.Example;

namespace __NAME__.Api.Modules
{
    public class ExampleModule : NancyModule
    {
        public ExampleModule(IRepositoryOfId<int> repository, IMappingEngine engine)
        {
            Get["/examples"] = _ => repository.Query<ExampleEntity>().Project().To<ExampleModel>().ToList();

            Get["/example/{id}"] = _ => {
                var entity = repository.Load<ExampleEntity>(_.id);
                return engine.Map<ExampleEntity, ExampleModel>(entity);
            };

            Post["/examples"] = _ => {
                var model = this.Bind<NewExampleModel>();
                this.ValidateModel(model);

                var entity = new ExampleEntity(model.Name);
                repository.Save(entity);

                return HttpStatusCode.OK;
            };

            Post["/examples/close"] = _ => {
                var entity = repository.Load<ExampleEntity>(_.id);
                entity.Close();
                repository.Save(entity);

                return HttpStatusCode.OK;
            };

            Delete["/example/{id}"] = _ => {
                repository.Delete<ExampleEntity>(_.id);
                return HttpStatusCode.OK;
            };
        }
    }
}