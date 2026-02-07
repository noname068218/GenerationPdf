using TemplateManager.DAL.Application;
using TemplateManager.DAL.ContexManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateManager.DAL
{
    public abstract class BaseTransacService
    {
        #region STATIC

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

        #region PROPERTIES
        #region PUBLIC

        public MainContext Context
        {
            get
            {
                return ApplicationContext.CurrentContext;
            }
        }

        #endregion
        #region NOT PUBLIC
        #endregion
        #endregion

        #region EVENT HANDLER
        #region PUBLIC
        #endregion
        #region PRIVATE
        #endregion
        #endregion

        #region METHODS
        #region PUBLIC
        #endregion
        #region NOT PUBLIC

        private void Do(Action _action, bool _transaction)
        {
            Exception exception = (Exception)null;
            try
            {
                this.Context.Database.BeginTransaction();
                _action();
                this.Context.Database.CommitTransaction();
            }
            catch (Exception ex1)
            {
                try
                {
                    this.Context.Database.RollbackTransaction();
                }
                catch (Exception ex2)
                {
                    exception = new Exception("Problemi durante il Rollback: " + ex2.Message, ex1);
                    throw exception;
                }
                throw;
            }
            finally
            {
                try{
                    this.Context.Dispose();
                }
                catch
                {
                    if (exception != null)
                        throw exception;

                    throw;
                }
            }
        }

        private T DoAndReturn<T>(Func<T> _function, bool _transaction)
        {
            Exception exception = (Exception)null;
            try
            {
                this.Context.Database.BeginTransaction();
                T obj = _function();
                this.Context.Database.CommitTransaction();
                return obj;
            }
            catch (Exception ex1)
            {
                try
                {
                    this.Context.Database.RollbackTransaction();
                }
                catch (Exception ex2)
                {
                    exception = new Exception("Problemi durante il Rollback: " + ex2.Message, ex1);
                    throw exception;
                }
                throw;
            }
            finally
            {
                try
                {
                    this.Context.Dispose();
                }
                catch
                {
                    if (exception != null)
                        throw exception;
                    throw;
                }
            }
        }


        #endregion
        #endregion

        #endregion
    }
}
