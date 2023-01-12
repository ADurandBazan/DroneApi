namespace DroneApi.Entities
{
    public class Drone : Entitity<int>
    {
        #region Fields

        public string SerialNumber { get; set; }
        public DroneModel Model { get; set; }
        public DroneState State { get; set; }
        public double WeightLimit { get; set; }
        public int BatteryCapacity { get; set; }
       
        #endregion
    }
}
