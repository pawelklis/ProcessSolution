namespace ProcessSolution
{
    public class LocationType : DBController, ILocation
    {
        public string Name { get; set; }
        public AddressType Address { get; set; }
        public int Id { get; set; }

        public LocationType()
        {
            Address = new AddressType();
        }
    }
}