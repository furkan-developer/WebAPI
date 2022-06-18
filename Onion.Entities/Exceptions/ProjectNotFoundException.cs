namespace Onion.Entities.Exceptions
{
    public class ProjectNotFoundException : NotFoundException
    {
        public ProjectNotFoundException(Guid projectId) 
            :base($"The project with {projectId} doesn't exists.") { }
    }
}
