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
        public TestNHibernateInitializer() : base("_")
        {
        }


        protected override bool ShouldExpose => true;


        protected override IPersistenceConfigurer GetDatabaseConfiguration()
        {
            string databaseFilename = "test.db";
            string databaseFilePath = Path.Combine(Path.GetTempPath(), databaseFilename);

            if (File.Exists(databaseFilePath))
                File.Delete(databaseFilePath);

            return SQLiteConfiguration
                .Standard
                .UsingFile(databaseFilePath)
                .Driver<SQLite20Driver>();
        }


        protected override void Expose(Configuration configuration)
        {
            new SchemaExport(configuration).Create(true, true);
        }
    }
}