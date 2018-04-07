using Business.Data;

namespace Business.Entities
{
    public class Driver
    {
        private readonly DriverData data;

        protected Driver(DriverData data)
        {
            this.data = data;
        }

        public long Id => data.Id;

        internal static Driver From(DriverData data) => data == null ? null : new Driver(data);

        internal static Driver Create() => new Driver(new DriverData());
    }
}
