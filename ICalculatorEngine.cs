namespace StretchyCalculator
{
    interface ICalculatorEngine
    {
        float Add(float A, float B);
        float Subtract(float A, float B);
        float Multiply(float A, float B);
        float Divide(float A, float B);
        float sqrt(float A);
    }
}
