using System;

namespace StretchyCalculator
{
    class Calculator : ICalculatorEngine
    {
        //set up error logging in constructor
        public Calculator()
        {
            //set up appropriate logging framework
        }

        float ICalculatorEngine.Add(float A, float B)
        {
            float result=float.NaN; //NaN returned if error occurs, calling rountine can test for this to handle errors
            try 
            {
                result=A+B;
            }
            catch (Exception ex)
            {
                //Log the error in logging framework
            }
            return result;
        }

        float ICalculatorEngine.Subtract(float A, float B)
        {
            float result=float.NaN; //ditto
            try 
            {
                result=A-B;
            }
            catch (Exception ex)
            {
                //ditto
            }
            return result;
        }
 
        float ICalculatorEngine.Multiply(float A, float B)
        {
            float result=float.NaN; //ditto
            try 
            {
                result=A*B;
            }
            catch (Exception ex)
            {
                //ditto
            }
            return result;
        }

        float ICalculatorEngine.Divide(float A, float B)
        {
            float result=float.NaN; //ditto
            try 
            {
                result=A/B;
            }
            catch (Exception ex)
            {
                //ditto
            }
            return result;
        }

        float ICalculatorEngine.sqrt(float A)
        {
            float result = float.NaN;   //ditto
            try
            {
                result = (float) Math.Sqrt(A);
            }
            catch (Exception ex)
            {
                //ditto
            }
            return result;
        }
    }
}
