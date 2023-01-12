namespace DroneApi.Entities
{
    public class Medication : Entitity<int>
    {
        #region Fields

        public string Name { get; set; }
        public string Code { get; set; }
        public double Weight { get; set; }
        public string? Image { get; set; }
        //Navigation Properties
        public int DroneId { get; set; }
        public Drone? Drone { get; set; }

        #endregion
    }
}
