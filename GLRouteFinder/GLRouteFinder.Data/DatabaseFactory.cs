using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace GLRouteFinder.Data
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private DbContextMain dataContext;
        public  IOptions<ConnectionStrings> _appSettings;
        public DataBaseFactory(IOptions<ConnectionStrings> appsettings)
        {
            _appSettings = appsettings;
        }
        public DbContextMain Get() => dataContext ?? (dataContext = new DbContextMain(_appSettings.Value.DefaultConnection));
        protected override void DisposeCore()
        {
            if (dataContext != null)
            {
                // dataContext.Dispose();
            }

        }
    }
    public interface IDataBaseFactory
    {
        DbContextMain Get();
    }
    public class Disposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }

    }
}
