using Hr_System.Models;

namespace Hr_System.Repositories.DepartmentRepository
{
    public interface IDeparmentRepository
    {
        List<Department> GetAll();
        void Add(Department dept);
        void Delete(Department dept);
        void Update(Department dept);
        Department getById(int id);
    }
}
