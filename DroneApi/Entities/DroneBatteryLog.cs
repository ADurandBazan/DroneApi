namespace DroneApi.Entities
{
    public class DroneBatteryLog : Entitity<int>
    {
        #region Fields
        
        public DateTime Date { get; set; }
        public string SerialNumber { get; set; }
        public int BatteryCapacity { get; set; }
        
        #endregion

    }
}

