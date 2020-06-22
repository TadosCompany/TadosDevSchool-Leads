namespace Leads.Persistence.NHibernate
{
    using System;
    using Domain;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using global::NHibernate.Cfg;
    using global::NHibernate.Dialect;
    using global::NHibernate.Tool.hbm2ddl;
    using Infrastructure.NHibernate.AutoMapping.Configuration;
    using Infrastructure.NHibernate.AutoMapping.Conventions;


    public class NHibernateInitializer
    {
        private readonly string _connectionString;


        public NHibernateInitializer(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }


        private bool ShouldExpose => true;


        private IPersistenceConfigurer GetDatabaseConfiguration() =>
            MySQLConfiguration
                .Standard
                .Dialect<MySQL57Dialect>()
                .ConnectionString(_connectionString)
#if DEBUG
                .ShowSql()
#endif
        ;

        private AutoPersistenceModel GetAutoPersistenceModel() =>
            AutoMap.AssemblyOf<DomainAssemblyMarker>(new DomainAutoMappingConfiguration())
                .Conventions.AddFromAssemblyOf<IdConvention>()
                .Conventions.AddFromAssemblyOf<NHibernateInitializer>()
                .UseOverridesFromAssemblyOf<NHibernateInitializer>();

        private void Expose(Configuration configuration)
        {
#if DEBUG
            if (ShouldExpose)
            {
                new SchemaUpdate(configuration).Execute(true, true);
            }
#endif
        }

        public Configuration GetConfiguration() => Fluently
            .Configure()
            .Database(GetDatabaseConfiguration)
            .Mappings(m => m.AutoMappings.Add(GetAutoPersistenceModel))
            .ExposeConfiguration(Expose)
            .BuildConfiguration();
    }
}