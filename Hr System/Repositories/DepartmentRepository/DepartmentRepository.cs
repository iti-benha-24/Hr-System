using Hr_System.Data;
using Hr_System.Models;

namespace Hr_System.Repositories.DepartmentRepository
{
    public class DepartmentRepository : IDeparmentRepository
    {
        private readonly HrDbContext _context;
        

        public DepartmentRepository(HrDbContext context)
        {
            _context = context;
        }
        public List<Department> GetAll()
        {
            return _context.Departments.ToList();
        }
        public void Add(Department dept)
        {

            _context.Departments.Add(dept);
            _context.SaveChanges();
           
        }


        public void Delete(Department dept)
        {
            _context.Departments.Remove(dept);
            _context.SaveChanges();

        }


        public void Update(Department dept)
        {
            _context.Departments.Update(dept);
            _context.SaveChanges();
        }

        public Department getById(int id)
        {
            var dept = _context.Departments.Find(id);
            return dept;

        }

    }
}
