using System;
using System.Configuration;
using Autofac;
using Practicum.Entities;

namespace Practicum.Components
{
    /// <summary>
    /// 
    /// </summary>
    internal class PracticumContainerBuilder
    {
        private const string ScannerFullyQualifiedTypeNameAppSettingName = "ScannerFullyQualifiedTypeName";
        private const string ParserFullyQualifiedTypeNameAppSettingName = "ParserFullyQualifiedTypeName";
        private const string ValidatorFullyQualifiedTypeNameAppSettingName = "ValidatorFullyQualifiedTypeName";
        private const string OutputWriterFullyQualifiedTypeNameAppSettingName = "OutputWriterFullyQualifiedTypeName";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            Register(containerBuilder);
            var container = containerBuilder.Build();
            return container;
        }

        private static void Register(ContainerBuilder containerBuilder)
        {
            // Register individual components
            containerBuilder.RegisterInstance<IMeal>(new Meal());
            var scannerFullyQualifiedTypeName =
                ConfigurationManager.AppSettings[ScannerFullyQualifiedTypeNameAppSettingName];
            var scannerType = Type.GetType(scannerFullyQualifiedTypeName, throwOnError: true);
            var scanner = (IScanner) Activator.CreateInstance(scannerType);
            containerBuilder.RegisterInstance(scanner);
            var parserFullyQualifiedTypeName =
                ConfigurationManager.AppSettings[ParserFullyQualifiedTypeNameAppSettingName];
            var parserType = Type.GetType(parserFullyQualifiedTypeName, throwOnError: true);
            var parser = (IParser)Activator.CreateInstance(parserType);
            RegistrationExtensions.RegisterInstance(containerBuilder, parser);
            var validatorFullyQualifiedTypeName =
                ConfigurationManager.AppSettings[ValidatorFullyQualifiedTypeNameAppSettingName];
            var validatorType = Type.GetType(validatorFullyQualifiedTypeName, throwOnError: true);
            var validator = (IValidator)Activator.CreateInstance(validatorType);
            containerBuilder.RegisterInstance(validator);
            var outputWriterFullyQualifiedTypeName =
                ConfigurationManager.AppSettings[OutputWriterFullyQualifiedTypeNameAppSettingName];
            var outputWriterType = Type.GetType(outputWriterFullyQualifiedTypeName, throwOnError: true);
            var outputWriter = (IOutputWriter)Activator.CreateInstance(outputWriterType);
            containerBuilder.RegisterInstance(outputWriter);
        }
    }
}
