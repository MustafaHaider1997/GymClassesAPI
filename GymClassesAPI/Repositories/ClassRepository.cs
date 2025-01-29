using GymClassesAPI.Models;

namespace GymClassesAPI.Repositories
{
    public class ClassRepository
    {
        private readonly List<ClassModel> _classes = new();

        public IEnumerable<ClassModel> GetAllClasses() => _classes;

        public ClassModel? GetClassById(Guid id) => _classes.FirstOrDefault(c => c.Id == id);

        public void AddClass(ClassModel newClass) => _classes.Add(newClass);
    }
}