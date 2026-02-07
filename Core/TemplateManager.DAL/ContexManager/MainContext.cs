using System.Reflection;
using Epy.Standard.ef;
using Microsoft.EntityFrameworkCore;
using TemplateManager.DAL.DomainModel;

namespace TemplateManager.DAL.ContexManager
{
    /// <summary>
    /// 
    /// </summary>
    public class MainContext : EFContext
    {

        #region DYNAMIC
        private readonly string _connectionString;
        #region CONSTRUCTORS

        public MainContext(DbContextOptions options) : base(options)
        {
            // Inizializzare i DbSet a livello di costruttore consente di poter mantenere le implementazioni
            // concrete per le interfacce I<Entity>ObjectModel con visibilità internal.

        #region Template 

            Templates = Set<Template>();

        #endregion

        #region TemplateParagraph 

            TemplateParagraphs = Set<TemplateParagraph>();

        #endregion


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        #endregion

        #region PROPERTIES

        #region Template 

        /// <summary>
        /// Collection relativa a tutte le istanze dell'entità <see cref=TemplateManager.DAL.Template/> a livello di DB.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref=TemplateManager.DAL.Template/>).</returns>
        internal DbSet<Template> Templates { set; get; }

        #endregion

        #region TemplateParagraph 

        /// <summary>
        /// Collection relativa a tutte le istanze dell'entità <see cref=TemplateManager.DAL.TemplateParagraph/> a livello di DB.
        /// </summary>
        /// <returns>L'istanza di tipo (<see cref=TemplateManager.DAL.TemplateParagraph/>).</returns>
        internal DbSet<TemplateParagraph> TemplateParagraphs { set; get; }

        #endregion



        #endregion

        #region METHODS
        #region NOT PUBLIC
        /// <summary>
        /// This method is called when the model for a derived ContextTemplateManager has been initialized, but
        /// before the model has been locked down and used to initialize the ContextTemplateManager.DAL.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the ContextTemplateManager being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived ContextTemplateManager
        /// is created.  The model for that ContextTemplateManager is then cached and is for all further instances of
        /// the ContextTemplateManager in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(
            ModelBuilder modelBuilder
            )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            #region Mapping Table

            //mappo le due entità sulla stessa tabella
        #region Template 

        modelBuilder.Entity<Template>().ToTable("Template");

        #endregion

        #region TemplateParagraph 

        modelBuilder.Entity<TemplateParagraph>().ToTable("TemplateParagraph");

        #endregion



            #endregion


        }

        #endregion

        #region PUBLIC

        #endregion

        #endregion

        #endregion


    }
}
