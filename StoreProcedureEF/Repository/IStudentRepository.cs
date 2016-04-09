using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreProcedureEF.Models;
namespace StoreProcedureEF.Repository
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        Student Find(int id);
    }
}
