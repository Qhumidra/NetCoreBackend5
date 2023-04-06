using Autofac;
using Autofac.Extras.DynamicProxy;
using Blog.Net.Core.Utilities.Security.JWT;
using Blog.Net.Data.Abstract;
using Blog.Net.Data.Concrete;
using Blog.Net.Services.Abstract;
using Blog.Net.Services.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Blog.Services.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<PostDal>().As<IPostDal>();
            builder.RegisterType<PostServices>().As<IPostServices>();

            builder.RegisterType<OperationClaimServices>().As<IOperationClaimServices>();
            builder.RegisterType<OperationClaimsDal>().As<IOperationClaimsDal>();

            builder.RegisterType<UserService>().As<IUserServices>();
            builder.RegisterType<UserDal>().As<IUserDal>();

            builder.RegisterType<AuthServices>().As<IAuthServices>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
