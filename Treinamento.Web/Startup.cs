using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using Treinamento.Domain.Classes.Negocio;
using Treinamento.Domain.Classes.Repositorio;
using Treinamento.Domain.Contexto;
using Treinamento.Domain.Interfaces.Negocio;
using Treinamento.Domain.Interfaces.Repositorio;

[assembly: OwinStartup(typeof(Treinamento.Web.Startup))]
namespace Treinamento.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ICursoRepository, CursoRepository>(Lifestyle.Transient);
            container.Register<ICursoNegocio, CursoNegocio>(Lifestyle.Transient);

            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Transient);
            container.Register<IAlunoNegocio, AlunoNegocio>(Lifestyle.Transient);

            container.Register(() => { return new TreinamentoContexto("TreinamentoConnection"); }, Lifestyle.Scoped);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}
