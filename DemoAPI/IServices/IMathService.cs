namespace DemoAPI.IServices
{
    interface IMathService
    {
        /// <summary>
        /// Adds two numbers together.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Add(double a, double b);
        /// <summary>
        /// Subtracts the second number from the first.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Subtract(double a, double b);
        /// <summary>
        /// Multiplies two numbers together.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Multiply(double a, double b);
        /// <summary>
        /// Divides the first number by the second.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        double Divide(double a, double b);
    }
}
