using System;
using Autofac;
using Practicum.Components;

namespace Practicum
{
    /// <summary>
    /// 
    /// </summary>
    internal class PracticumRunner
    {
        /// <summary>
        /// 
        /// </summary>
        public void Run()
        {
            while (true)
            {
                try
                {
                    ProcessLine();
                }
                catch (Exception exception)
                {
                    var message = string.Format("{0}: {1}.", exception.GetType(), exception.Message);
                    Console.WriteLine(message);
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        private static void ProcessLine()
        {
            var scanner = Scanner;
            var inputLine = scanner.ReadInputLine();
            var parser = Parser;
            parser.ParseMeal(inputLine);
            var validator = Validator;
            validator.ValidateMeal();
            var outputWriter = OutputWriter;
            outputWriter.WriteOutput();
        }

        private static IScanner Scanner
        {
            get
            {
                var scanner = ContainerManager.Container.Resolve<IScanner>();
                if (scanner == null)
                {
                    throw new InvalidOperationException("Cannot Resolve IScanner.");
                }
                return scanner;
            }
        }

        private static IParser Parser
        {
            get
            {
                var parser = ContainerManager.Container.Resolve<IParser>();
                if (parser == null)
                {
                    throw new InvalidOperationException("Cannot Resolve IParser.");
                }
                return parser;
            }
        }

        private static IValidator Validator
        {
            get
            {
                var validator = ContainerManager.Container.Resolve<IValidator>();
                if (validator == null)
                {
                    throw new InvalidOperationException("Cannot Resolve IValidator.");
                }
                return validator;
            }
        }

        private static IOutputWriter OutputWriter
        {
            get
            {
                var outputWriter = ContainerManager.Container.Resolve<IOutputWriter>();
                if (outputWriter == null)
                {
                    throw new InvalidOperationException("Cannot Resolve IOutputWriter.");
                }
                return outputWriter;
            }
        }
    }
}
