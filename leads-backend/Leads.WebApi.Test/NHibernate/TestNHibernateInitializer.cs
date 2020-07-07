namespace Leads.WebApi.Test.NHibernate
{
    using System.IO;
    using FluentNHibernate.Cfg.Db;
    using global::NHibernate.Cfg;
    using global::NHibernate.Driver;
    using global::NHibernate.Tool.hbm2ddl;
    using Persistence.NHibernate;

    public class TestNHibernateInitializer : NHibernateInitializer
    {
        private static readonly object FileLockObject = new object();
        private static readonly object ExposeLockObject = new object();
        private static bool _fileRemoved = false;
        private static bool _schemaExposed = false;

        public TestNHibernateInitializer() : base("_")
        {
        }


        protected override bool ShouldExpose => true;


        protected override IPersistenceConfigurer GetDatabaseConfiguration()
        {
            string databaseFilename = "test.db";
            string databaseFilePath = Path.Combine(Path.GetTempPath(), databaseFilename);

            lock (FileLockObject)
            {
                if (File.Exists(databaseFilePath) && !_fileRemoved)
                    File.Delete(databaseFilePath);

                _fileRemoved = true;
            }

            return SQLiteConfiguration
                .Standard
                .UsingFile(databaseFilePath)
                .Driver<SQLite20Driver>();
        }


        protected override void Expose(Configuration configuration)
        {
            lock (ExposeLockObject)
            {
                if (_schemaExposed)
                    return;
                
                new SchemaExport(configuration).Create(true, true);

                _schemaExposed = true;
            }
        }
    }
}