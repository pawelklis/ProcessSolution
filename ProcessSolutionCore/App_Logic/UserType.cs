namespace ProcessSolution
{
    public class UserType :DBController, IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public PersonType Person { get; set; }
        public EmployeeType Employee { get; set; }
        public int Id { get; set; }

        public UserType()
        {
            Person = new PersonType();
            Employee = new EmployeeType();
        }
    }
}