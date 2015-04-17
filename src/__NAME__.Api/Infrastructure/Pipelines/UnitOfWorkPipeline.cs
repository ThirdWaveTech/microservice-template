using System;
using System.Collections.Generic;
using System.Linq;
using Crux.Domain.Persistence.NHibernate;
using Crux.Domain.UoW;
using Crux.NancyFx.Infrastructure.Extensions;
using Nancy;
using StructureMap;

namespace __NAME__.Api.Infrastructure.Pipelines
{
    public class UnitOfWorkPipeline
    {
        private const string UNIT_OF_WORK_SCOPE = "__NAME__.UnitOfWorkScope";
        private const string UNIT_OF_WORK_OPTIONS = "__NAME__.UnitOfWorkOptions";

        private static readonly IEnumerable<string> Exclusions = new[] {
            "/ping"
        };

        public static Func<NancyContext, Response> BeforeRequest(IContainer container)
        {
            return ctx => {
                if (ctx.IsHttpOptions() || ShouldExclude(ctx.Request.Path)) return null;
                
                var unitOfWork = container.GetInstance<INHibernateUnitOfWork>();
                ctx.Items[UNIT_OF_WORK_SCOPE] = unitOfWork.CreateTransactionalScope(GetUnitOfWorkOptions(ctx));

                return ctx.Response;
            };
        }

        public static Action<NancyContext> AfterRequest()
        {
            return ctx => {
                var scope = GetUnitOfWorkScope(ctx);
                if (scope != null) scope.Complete();
            };
        }

        private static UnitOfWorkTransactionOptions GetUnitOfWorkOptions(NancyContext ctx)
        {
            object val;
            if (!ctx.Items.TryGetValue(UNIT_OF_WORK_OPTIONS, out val)) {
                return UnitOfWorkTransactionOptions.Default();
            }

            return val as UnitOfWorkTransactionOptions ?? UnitOfWorkTransactionOptions.Default();
        }

        private static ITransactionalUnitOfWorkScope GetUnitOfWorkScope(NancyContext ctx)
        {
            object val;
            ctx.Items.TryGetValue(UNIT_OF_WORK_SCOPE, out val);
            return val as ITransactionalUnitOfWorkScope;
        }

        private static bool ShouldExclude(string path)
        {
            return Exclusions.Any(path.Equals);
        }
    }
}