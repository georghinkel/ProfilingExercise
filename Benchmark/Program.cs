using Benchmark.Railway;
using NMF.Expressions;
using NMF.Expressions.Linq;
using NMF.Models;
using NMF.Models.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Benchmark
{
    internal class Program
    {
        const int Iterations = 100;

        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            Console.WriteLine("Creating repository...");
            if (Debugger.IsAttached)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning, debugger is attached and might falsify benchmark results.");
            }
            stopwatch.Start();
            var repository = new ModelRepository();
            stopwatch.Stop();
            Console.WriteLine($"Repository created in {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Loading model...");
            stopwatch.Restart();
            var model = repository.Resolve("railway.railway");
            var railwayContainer = (IRailwayContainer)model.RootElements[0];
            stopwatch.Stop();
            Console.WriteLine($"Models loaded in {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine("Starting Benchmark...");
            stopwatch.Restart();

            var routes = railwayContainer.Descendants().OfType<IRoute>();

            var wrongSwitchPositions = from route in routes
                                       where route.Entry != null && route.Entry.Signal == Signal.GO
                                       from positionRequirement in route.Follows
                                       where positionRequirement.Switch.CurrentPosition != positionRequirement.Position
                                       select positionRequirement;

            if (args.Length > 0 && args[0] == "incremental")
            {

                var connectedRoute = ObservingFunc<IRoute, IRoute>.FromExpression(
                    route => (from sensor1 in route.DefinedBy
                              from te1 in sensor1.Elements
                              from te2 in te1.ConnectsTo
                              where te2.Sensor != null && te2.Sensor.Parent != route
                              select te2.Sensor.Parent as IRoute).FirstOrDefault());

                var wrongContinuations = from route in routes
                                         let nextRoute = connectedRoute.Evaluate(route)
                                         where nextRoute != null && nextRoute.Entry != null && nextRoute.Entry != route.Exit
                                         select ValueTuple.Create(route, nextRoute);

                var notifiableWrongSwitchPositions = wrongSwitchPositions.AsNotifiable();
                var notifiableWrongRouteContinuations = wrongContinuations.AsNotifiable();
                Console.WriteLine($"Found {notifiableWrongSwitchPositions.Count()} wrong switch positions");
                Console.WriteLine($"Found {notifiableWrongRouteContinuations.Count()} wrong route continuations");
                for (int i = 0; i < Iterations; i++)
                {
                    CorrectSwitchPositions(notifiableWrongSwitchPositions);
                    CorrectRouteContinuations(notifiableWrongRouteContinuations);
                }
            }
            else
            {

                IRoute connectedRoute(IRoute route)
                    => (from sensor1 in route.DefinedBy
                        from te1 in sensor1.Elements
                        from te2 in te1.ConnectsTo
                        where te2.Sensor != null && te2.Sensor.Parent != route
                        select te2.Sensor.Parent as IRoute).FirstOrDefault();

                var wrongContinuations = from route in routes.AsEnumerable()
                                         let nextRoute = connectedRoute(route)
                                         where nextRoute != null && nextRoute.Entry != null && nextRoute.Entry != route.Exit
                                         select ValueTuple.Create(route, nextRoute);

                Console.WriteLine($"Found {wrongSwitchPositions.Count()} wrong switch positions");
                Console.WriteLine($"Found {wrongContinuations.Count()} wrong route continuations");
                for (int i = 0; i < Iterations; i++)
                {
                    CorrectSwitchPositions(wrongSwitchPositions);
                    CorrectRouteContinuations(wrongContinuations);
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Completed in {stopwatch.Elapsed.TotalMilliseconds} ms");
        }

        static void CorrectSwitchPositions(IEnumerable<ISwitchPosition> wrongSwitchPositions)
        {
            var nextToCorrect = wrongSwitchPositions.FirstOrDefault();
            if (nextToCorrect != null)
            {
                Console.WriteLine($"Correcting position of switch {nextToCorrect.Switch.Id}");
                nextToCorrect.Switch.CurrentPosition = nextToCorrect.Position;
            }
        }

        static void CorrectRouteContinuations(IEnumerable<(IRoute route, IRoute next)> wrongRouteContinuations)
        {
            var nextToCorrect = wrongRouteContinuations.FirstOrDefault();
            if (nextToCorrect.route != null)
            {
                Console.WriteLine($"Correcting continuation of route {nextToCorrect.route.Id} to route {nextToCorrect.next.Id}");
                nextToCorrect.next.Entry = nextToCorrect.route.Exit;
            }
        }
    }
}
