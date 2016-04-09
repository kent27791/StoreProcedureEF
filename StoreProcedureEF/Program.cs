using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StoreProcedureEF.Repository;
namespace StoreProcedureEF
{
    public class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository studentRepository = new StudentRepository();
            var all = studentRepository.GetAll();
            var findIdOne = studentRepository.Find(1);
        }
    }
}
