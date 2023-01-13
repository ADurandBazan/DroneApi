namespace DroneApi.Entities
{
    public class DroneBatteryLog : Entitity<int>
    {
        #region Fields
        
        public DateTime Date { get; set; }
        public int DroneId { get; set; }
        public Drone Drone { get; set; }
        public int BatteryCapacity { get; set; }
        
        #endregion

    }
}

