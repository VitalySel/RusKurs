using System;
using System.Collections.Generic;
using System.Text;

namespace RusKurs
{
        public class Logic
        {
            double [] x0 = { 5, 5 };
            double h = 1;
            int iterationCount = 0;
            int maxIterationCount = 50;
            double quotient = 0.5;
            double minH = 0.005;

            List<double> arrayVectors = new List<double>();
            List<double> arrayValues = new List<double>();
            int testCount = 5;

            static double getFunctionValue (double x,double y)
            {
                return Math.Pow(x, 2) + Math.Pow(y, 2);
            }

            static double getVectorLength(double x, double y)
            {
                return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            }

            static double random (double min,double max)
            {
                Random rnd = new Random();
                return rnd.NextDouble() * (max - min) + min;
            }

            static List<double> getUnitVector()
            {
                double x, y, length;
                List<double> vector = new List<double>();

                x = random(-1, 1);
                y = random(-1, 1);
                length = getVectorLength(x, y);
                x = x / length;
                y = y / length;

                vector.Add(x);
                vector.Add(y);

                return vector;
            }

            List<double> getVectors ()
            {
                for (int j = 1; j <= testCount; j++)
                {
                    
                    arrayVectors.AddRange(getUnitVector());
                }
                return arrayVectors;
            }

            double getMinValue()
            {
                List<double> arrayTest = new List<double>();
                List<double> min = new List<double>();
                int index = 0;
                int length;
                for (int i = 0; i < testCount; i++)
                {
                    
                    arrayTest.Add(getFunctionValue(arrayValues[i], arrayValues[i + 1]));
                }
                
                min.Add(arrayTest[0]);
               
                length = arrayTest.Count;

                for (int j = 1; j < length; j++)
                {
                    if (arrayTest[j] < min[0])
                    {
                        
                        min.Add(arrayTest[j]);
                        index = j;
                    }
                }
                return index;
            }

            public double randomSearchMethod()
            {
                
                arrayVectors.Clear();
                int index;
                getVectors();

                for (int i = 0; i < testCount; i++)
                {
                    arrayValues.Add(x0[0] + h * arrayVectors[i]);
                    arrayValues.Add(x0[1] + h * arrayVectors[i + 1]);
                }
              
                arrayVectors.Clear();

                index = (int)getMinValue();

                if (getFunctionValue(arrayValues[index],arrayValues[index+1]) < getFunctionValue(x0[0],x0[1]))
                {
                    x0[0] = arrayValues[index];
                    x0[0] = arrayValues[index + 1];
                    if (iterationCount<maxIterationCount)
                    {
                        
                        arrayValues.Clear();
                        randomSearchMethod();
                    }
                    else if (iterationCount == maxIterationCount)
                    {
                        Console.WriteLine("Наименьшее значение функции:" );
                        Console.WriteLine(getFunctionValue(x0[0],x0[1]));
                        return getFunctionValue(x0[0], x0[1]);
                    }
                }
                else
                {
                    if (h<=minH)
                    {
                        x0[0] = arrayValues[index];
                        x0[0] = arrayValues[index + 1];
                        Console.WriteLine("Наименьшее значение функции:");
                        Console.WriteLine(getFunctionValue(x0[0], x0[1]));
                        return getFunctionValue(x0[0], x0[1]);
                    }
                    else
                    {
                        h = h * quotient;
                        arrayValues.Clear();
                        randomSearchMethod();
                    }
                }
                iterationCount++;
                return getFunctionValue(x0[0], x0[1]);
            }
        }
}
