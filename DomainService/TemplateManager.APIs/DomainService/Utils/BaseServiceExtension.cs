using System;
using System.Transactions;

namespace TemplateManager.APIs.DomainService
{
    public abstract class BaseServiceExtension
    {

        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        #region PUBLIC

        protected static void DoSQLTransaction(
            Action action
        )
        {
            using TransactionScope transactionScope = new(TransactionScopeOption.Required, new TimeSpan(0, 0, 120));
            try
            {
                action();
                transactionScope.Complete();
            }
            catch (Exception ex)
            {
                //ok = false;
                throw;
            }
            finally
            {
                transactionScope.Dispose();
            }
        }


        #endregion

        #region NOT PUBLIC

        #endregion

        #endregion

    }
}
