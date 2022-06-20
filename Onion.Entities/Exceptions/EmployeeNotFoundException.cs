namespace Onion.Entities.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException():base("There isn't employee this on the project") { }
        public EmployeeNotFoundException(Guid employeId)
            :base($"The employee with {employeId} doesn't exists.") { }
    }
}
