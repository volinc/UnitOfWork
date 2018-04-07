namespace Business.Data
{
    public class ShiftData
    {
        public long Id { get; set; }

        public long VehicleId { get; set; }

        public long DriverId { get; set; }

        public VehicleData Vehicle { get; set; }

        public DriverData Driver { get; set; }
    }
}
