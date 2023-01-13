using DroneApi.Helpers;

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
        public ICollection<Medication> Medications { get; set; } = new List<Medication>();
        public ICollection<DroneBatteryLog> Logs { get; set; } = new List<DroneBatteryLog>();
        #endregion

        #region Medications
        public virtual void AddMedication(Medication medication)
        {
            if (WeightLimit < (Medications.Sum(m => m.Weight) + medication.Weight))
            {
                State = DroneState.LOADED;
                throw new AppException("Weight limit was exceeded. Drone is full");
            }

            else if (!Medications.Contains(medication))
            {

                medication.Drone = this;
                medication.DroneId = Id;
                Medications.Add(medication);

            }

        }
        public virtual void AddMedications(IEnumerable<Medication> medications)
        {
            foreach (var medication in medications)
            {
                AddMedication(medication);
            }
        }
        public virtual void RemoveMedication(Medication medication)
        {
            Medications.Remove(medication);


        }
        public virtual void RemoveMedications(IEnumerable<Medication> medications)
        {
            foreach (var medication in medications)
            {
                RemoveMedication(medication);

            }

        }
        public virtual void RemoveAllMedications()
        {
            Medications.Clear();
        }
        #endregion

        #region Logs
        public virtual void AddLog(DroneBatteryLog log)
        {
             if (!Logs.Contains(log))
             {
                log.Drone = this;
                log.DroneId = Id;
                Logs.Add(log);
             }

        }
        public virtual void AddLogs(IEnumerable<DroneBatteryLog> logs)
        {
            foreach (var log in logs)
            {
                AddLog(log);
            }
        }
        public virtual void RemoveLog(DroneBatteryLog log)
        {
            Logs.Remove(log);


        }
        public virtual void RemoveLogs(IEnumerable<DroneBatteryLog> logs)
        {
            foreach (var log in logs)
            {
                RemoveLog(log);

            }

        }
        public virtual void RemoveAllLogs()
        {
            Logs.Clear();
        }
        #endregion
    }
}
