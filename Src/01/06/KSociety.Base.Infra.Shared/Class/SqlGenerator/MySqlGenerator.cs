﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Pomelo.EntityFrameworkCore.MySql.Migrations;
using System;

namespace KSociety.Base.Infra.Shared.Class.SqlGenerator
{
    public class MySqlGenerator : MySqlMigrationsSqlGenerator
    {
        private readonly ILogger<MySqlGenerator> _logger;

        //It must be public
#if NETSTANDARD2_1_OR_GREATER
        public MySqlGenerator(
            ILoggerFactory loggerFactory,
            MigrationsSqlGeneratorDependencies dependencies,
            IRelationalAnnotationProvider relationalAnnotationProvider,
            IMySqlOptions options)
            : base(dependencies, relationalAnnotationProvider, options)
        {
            _logger = loggerFactory.CreateLogger<MySqlGenerator>();
            _logger.LogTrace("MySqlGenerator");
        }
#elif NET5_0
        public MySqlGenerator(
            ILoggerFactory loggerFactory,
            MigrationsSqlGeneratorDependencies dependencies,
            IRelationalAnnotationProvider relationalAnnotationProvider,
            IMySqlOptions options)
            : base(dependencies, relationalAnnotationProvider, options)
        {
            _logger = loggerFactory.CreateLogger<MySqlGenerator>();
            _logger.LogTrace("MySqlGenerator");
        }
#elif NET6_0_OR_GREATER
        public MySqlGenerator(
            ILoggerFactory loggerFactory,
            MigrationsSqlGeneratorDependencies dependencies,
            ICommandBatchPreparer commandBatchPreparer,
            IMySqlOptions options)
            : base(dependencies, commandBatchPreparer, options)
        {
            _logger = loggerFactory.CreateLogger<MySqlGenerator>();
            _logger.LogTrace("MySqlGenerator");
        }
#endif

        protected override void Generate(
            MigrationOperation operation,
            IModel model,
            MigrationCommandListBuilder builder)
        {
            try
            {
                if (operation is CreateViewOperation createViewOperation)
                {
                    //Generate(createViewOperation, builder);
                    SqlGeneratorHelper.Generate(_logger, createViewOperation, builder,
                        Dependencies.SqlGenerationHelper);
                }
                else
                {
                    base.Generate(operation, model, builder);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generate: ");
            }
        }
    }
}