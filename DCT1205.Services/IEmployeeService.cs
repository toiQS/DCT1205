using DCT1205.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT1205.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Task CreateAsSync(Employee employee);
        Task UpdateAsSync(Employee employee);
        Task UpdateById(int id);
        Task DeleteAsSync(int id);
    }
}
