using System;
using Autofac;

namespace Practicum
{
    /// <summary>
    /// 
    /// </summary>
    internal class PracticumRunner
    {
        private readonly IScanner _scanner;
        private readonly IParser _parser;
        private readonly IValidator _validator;
        private readonly IOutputWriter _outputWriter;

        /// <summary>
        /// 
        /// </summary>
        public PracticumRunner()
        {
            _scanner = ContainerManager.Container.Resolve<IScanner>();
            if (_scanner == null)
            {
                throw new InvalidOperationException("Cannot Resolve IScanner.");
            }
            _parser = ContainerManager.Container.Resolve<IParser>();
            if (_parser == null)
            {
                throw new InvalidOperationException("Cannot Resolve IParser.");
            }
            _validator = ContainerManager.Container.Resolve<IValidator>();
            if (_validator == null)
            {
                throw new InvalidOperationException("Cannot Resolve IValidator.");
            }
            _outputWriter = ContainerManager.Container.Resolve<IOutputWriter>();
            if (_outputWriter == null)
            {
                throw new InvalidOperationException("Cannot Resolve IOutputWriter.");
            }
        }

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

        private void ProcessLine()
        {
            var inputLine = _scanner.ReadInputLine();
            _parser.ParseMeal(inputLine);
            _validator.ValidateMeal();
            _outputWriter.WriteOutput();
        }
    }
}
