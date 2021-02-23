using Data.Repository;
using Data.Repository.Interface;
using Unity;
using Unity.Extension;

namespace Business.RepositoryHelper
{
    public class RepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPassengerRepository, PassengerRepository>();
        }
    }
}