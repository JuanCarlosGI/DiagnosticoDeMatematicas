using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.DataVisualization.Charting;

namespace DiagnosticoDeMatematicas.Charts
{
    public class FunctionSeries : Series
    {
        private const int AMOUNT_OF_INTERVALS = 200;

        public Function Function { get; }
        public ChartArea ChartAreaObject { get; }

        public FunctionSeries(Function function, ChartArea chartArea)
        {
            Function = function;
            ChartAreaObject = chartArea;
            ChartType = SeriesChartType.Line;

            var delta = (ChartAreaObject.AxisX.Maximum - ChartAreaObject.AxisX.Minimum) / AMOUNT_OF_INTERVALS;
            for (int point = 0; point <= AMOUNT_OF_INTERVALS + 1; point++)
            {
                var x = ChartAreaObject.AxisX.Minimum + point * delta;
                Points.AddXY(x, Function.Evaluate(x));
            }
        }

        public FunctionSeries Derivate()
        {
            return new FunctionSeries(Function.Derivate(), ChartAreaObject);
        }
    }

    public abstract class Function
    {
        public abstract double Evaluate(double x);
        public abstract Function Derivate();
    }

    public class Polynomial : Function
    {
        private List<double> _coefficients;

        public int Degree { get { return Coefficients.Length - 1; } }
        public double[] Coefficients { get { return _coefficients.ToArray(); } }

        public Polynomial(params double[] coefficients)
        {
            _coefficients = new List<double>();
            foreach(var coefficient in coefficients)
            {
                _coefficients.Add(coefficient);
            }
        }

        public override double Evaluate(double x)
        {
            double result = 0;
            for (int degree = Degree; degree >= 0; degree--)
            {
                result += Math.Pow(x, degree) * Coefficients[Degree - degree];
            }
            return result;
        }

        public override Function Derivate()
        {
            List<double> newCoefficients = new List<double>();
            for (int degree = Degree; degree > 0; degree--)
            {
                newCoefficients.Add(degree * Coefficients[Degree - degree]);
            }
            return new Polynomial(newCoefficients.ToArray());
        }
    }
}