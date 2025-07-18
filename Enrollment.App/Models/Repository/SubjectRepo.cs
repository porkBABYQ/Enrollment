using Enrollment.DataModel;
using Entprog.DataModel.Repository;

namespace Enrollment.App.Models.Repository
{
    public class SubjectRepo : GenericRepo<Subject>, ISubjectRepo
    {
        public SubjectRepo(AppDbContext context) : base(context)
        {

        }
    }
}
