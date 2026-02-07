

namespace TemplateManager.DAL
{
    /// <summary>
    /// interface da cui recuperare le istanze di
    /// <list type="circle">
    ///     <item>service che operano a livello di Domain</item>
    ///     <item>validatori per le entità a livello di Domain</item>
    /// </list>
    /// </summary>
    public interface IServiceLocatorFactory
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
        #endregion

        #endregion

        #region CONSTRUCTORS

        #region PUBLIC
        #endregion

        #region NOT PUBLIC
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
        /// Create new instance of <see cref="IServiceLocatorFactory"/>
        /// </summary>
        /// <returns></returns>
        IServiceLocatorFactory NewInstance();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetDomainService<T>();

        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

        #endregion

    }
}
