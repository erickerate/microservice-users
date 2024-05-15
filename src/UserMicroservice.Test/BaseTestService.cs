using AutoMapper;
using CrossCutting.Mappings;

namespace UserMicroservice.Test
{
    /// <summary>
    /// Serviço de teste base
    /// </summary>
    public abstract class BaseTestService
    {
        #region Constructors

        /// <summary>
        /// Serviço de teste base
        /// </summary>
        public BaseTestService()
        {
            this.Mapper = new AutoMapperFixture().GetMapper();
        }

        #endregion

        #region Members 'Mapper' :: Mapper

        /// <summary>
        /// Mapeador
        /// </summary>
        public IMapper Mapper { get; set; }

        #endregion

        #region Class 'AutoMapperFixture'

        public class AutoMapperFixture : IDisposable
        {
            #region Members 'Mapper' :: GetMapper(), Dispose()

            public IMapper GetMapper()
            {
                MapperConfiguration config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ModelToEntityProfile());
                    cfg.AddProfile(new DtoToModelProfile());
                    cfg.AddProfile(new EntityToDtoProfile());
                });

                return config.CreateMapper();
            }

            public void Dispose()
            {
            }

            #endregion
        }

        #endregion
    }
}