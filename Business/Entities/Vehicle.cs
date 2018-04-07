using Business.Data;

namespace Business.Entities
{
    public class Vehicle
    {
        private readonly VehicleData data;

        protected Vehicle(VehicleData data)
        {
            this.data = data;
        }

        public long Id => data.Id;        

        internal static Vehicle From(VehicleData data) => data == null ? null : new Vehicle(data);

        internal static Vehicle Create() => new Vehicle(new VehicleData());
    }
}
