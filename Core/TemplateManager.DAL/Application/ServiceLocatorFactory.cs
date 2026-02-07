using System;
using System.Collections.Generic;

namespace TemplateManager.DAL.Application
{
    /// <summary>
    /// Classe da cui recuperare le istanze di
    /// <list type="circle">
    ///     <item>service che operano a livello di Domain</item>
    ///     <item>validatori per le entità a livello di Domain</item>
    /// </list>
    /// </summary>
    internal sealed class ServiceLocatorFactory : IServiceLocatorFactory
    {
        #region DYNAMIC

        #region EVENTS

        #region PUBLIC
        #endregion

        #region NOT PUBLIC
        #endregion

        #endregion

        #region FIELDS

        #region PUBLIC
        #endregion

        #region NOT PUBLIC

        static readonly ServiceLocatorFactory _instance = new();
        public static ServiceLocatorFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #endregion

        #region CONSTRUCTORS

        #region PUBLIC
        #endregion

        #region NOT PUBLIC

        ServiceLocatorFactory()
        {

        }

        #endregion

        #endregion

        #region PROPERTIES

        #region PUBLIC
        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion


        #region METHODS

        #region PUBLIC

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetDomainService<T>()
        {
            try
            {
                return GetNewObject<T>();
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
            catch (Exception)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }

        #endregion

        #region NOT PUBLIC

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetNewObject<T>()
        {
            try
            {
                return (T)typeof(T).GetConstructor(Array.Empty<Type>()).Invoke(Array.Empty<object>());
            }
            catch
            {
                return default;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IServiceLocatorFactory NewInstance() => new ServiceLocatorFactory();

        #endregion

        #endregion

        #endregion
    }
}
