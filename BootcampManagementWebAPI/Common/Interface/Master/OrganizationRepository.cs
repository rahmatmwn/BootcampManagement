using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class OrganizationRepository : IOrganizationRepository
    {
        bool status = false;
        MyContext myContext = new MyContext();
        Organization organization = new Organization();
        public bool delete(int? id)
        {
            var result = 0;
            organization = myContext.Organizations.Find(id);
            organization.IsDelete = true;
            organization.DeleteDate = DateTimeOffset.Now.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public List<Organization> Get()
        {
            var getAll = myContext.Organizations.Where(x => x.IsDelete == false).ToList();
            return getAll;

        }

        public Organization Get(int? id)
        {
            var get = myContext.Organizations.Find(id);
            return get;
        }

        public bool insert(OrganizationParam organizationParam)
        {
            var result = 0;
            organization.Name = organizationParam.Name;
            organization.Position = organizationParam.Position;
            organization.Description = organizationParam.Description;
            organization.StartDate = organizationParam.StartDate;
            organization.EndDate = organizationParam.EndDate;
            var getStudentId = myContext.Students.Find(organizationParam.Student_Id);
            organization.Students = getStudentId;
            organization.CreateDate = DateTimeOffset.Now.LocalDateTime;
            organization.IsDelete = false;
            myContext.Organizations.Add(organization);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool update(int? id, OrganizationParam organizationParam)
        {
            var result = 0;
            organization = myContext.Organizations.Find(id);
            organization.Name = organizationParam.Name;
            organization.Position = organizationParam.Position;
            organization.Description = organizationParam.Description;
            organization.StartDate = organizationParam.StartDate;
            organization.EndDate = organizationParam.EndDate;
            var getStudentId = myContext.Students.Find(organizationParam.Student_Id);
            organization.Students = getStudentId;
            organization.CreateDate = DateTimeOffset.Now.LocalDateTime;
            organization.IsDelete = false;
            myContext.Organizations.Add(organization);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;

        }
    }
}
