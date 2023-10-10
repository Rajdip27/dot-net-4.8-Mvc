using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebAppMvcProject.Mapper;
using WebAppMvcProject.Service;

namespace WebAppMvcProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();
            /// OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterFilterProvider();
            // builder.Register(context => new MapperConfiguration(cfg =>
            // {
            //     //Register Mapper Profile
            //     cfg.AddProfile<CommonMapper>();
            // }
            //)).AsSelf().SingleInstance();
            //builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();



            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new CommonMapper());});

            
            var mapper = mapperConfiguration.CreateMapper();

            
            builder.RegisterInstance<IMapper>(mapper);



            builder.Register(x => ApplicationDbContext.Create()).AsSelf();
           
            builder.RegisterType<StudentInfoRepository>().AsImplementedInterfaces().AsSelf().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
    }
}
