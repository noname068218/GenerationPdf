
using System;

namespace TemplateManager.APIs.Application
{
    public class BootStrapper
    {

        /// <summary>
        /// Inizializza StructureMap per la parte di IoC.
        /// </summary>
        public static void Initialize()
        {

            try
            {
                InitEntityMapping();
            }
            catch (System.Exception ex)
            {

                throw new Exception("Error Automapper - " + ex.Message);
            }


        }

        /// <summary>
        /// Esegie InitEntity Mapping 
        /// </summary>
        private static void InitEntityMapping()
        {
            //var config = new MapperConfiguration(cfg => {

            //});

            //IMapper mapper = config.CreateMapper();

        }

    }
}
