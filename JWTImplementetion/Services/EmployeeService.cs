using JWTImplementetion.Context;
using JWTImplementetion.Interfaces;
using JWTImplementetion.Model;

namespace JWTImplementetion.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly JwtContext _jwtContext;
        public EmployeeService(JwtContext jwtContext)
        {
                _jwtContext = jwtContext;
        }
        public Employee AddEmployee(Employee employee)
        {
           var result  = _jwtContext.Add(employee);
            _jwtContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                var emp = _jwtContext.employees.Where(x => x.Id == id).FirstOrDefault();
                if (emp != null)
                {
                    _jwtContext.employees.Remove(emp);
                    _jwtContext.SaveChanges();
                    return true;
                }
                else
                {
                       return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public List<Employee> GetEmployeeDetails()
        {
         return _jwtContext.employees.ToList();
        }

        public Employee GetEmployeeDetails(int id)
        {
            return _jwtContext.employees.Where(x => x.Id == id).FirstOrDefault();
        }

        public Employee UpdateEmployee(Employee employee)
        {
          var result = _jwtContext.Update(employee);
            _jwtContext.SaveChanges();
            return result.Entity;
        }
    }
}
