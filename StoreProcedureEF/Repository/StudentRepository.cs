using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreProcedureEF.Models;
using StoreProcedureEF.Extensions;
using StoreProcedureEF.Common;
using StoreProcedureEF.Configurations;
namespace StoreProcedureEF.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DemoStoreProcedureContext context;
        public StudentRepository()
        {
            if(context == null)
            {
                context = new DemoStoreProcedureContext();
            }
        }
        public IList<Student> GetAll()
        {
            SqlRequest request = new SqlRequest()
            {
                CommandName = SqlName.spAllStudent,
                CommandParams = null
            };
            return context.ExecuteSqlCommand<Student>(request).ToList();
        }
        public Student Find(int id)
        {
            SqlRequest request = new SqlRequest
            {
                CommandName = SqlName.spFindStudent,
                CommandParams = new
                {
                    StudentId = id
                }
            };
            return context.ExecuteSqlCommand<Student>(request).SingleOrDefault();
        }
    }
}
