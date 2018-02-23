namespace Assets.Scripts.Core
{
    public class TemperatureHolder : ITemperatureHolder
    {
        public int Temperature;

        public int GetTemperature()
        {
            return Temperature;
        }
    }
}