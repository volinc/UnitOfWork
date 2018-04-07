using Business.Data;

namespace Business.Entities
{
    public class Shift
    {
        private readonly ShiftData data;

        public Shift(ShiftData data)
        {
            this.data = data;
        }

        public long Id => data.Id;

        public long VehicleId => data.VehicleId;

        public long DriverId => data.DriverId;

        internal static Shift From(ShiftData data) => data == null ? null : new Shift(data);
    }
}
