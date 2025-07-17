using Enrollment.DataModel;
using Entprog.DataModel.Repository;

namespace Enrollment.App.Models.Repository
{
    public class TeacherRepo : GenericRepo<Teacher>, ITeacherRepo
    {
        public TeacherRepo(AppDbContext context) : base(context)
        {

        }
    }
}
