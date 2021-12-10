namespace ProcessSolution
{
    public interface IContact:IEntity
    {
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}