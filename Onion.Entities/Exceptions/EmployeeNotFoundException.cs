namespace Onion.Entities.Exceptions
{
    public class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid employeId)
            :base($"The project with {employeId} doesn't exists.") { }
    }
}
