using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specifications
{
    /// <summary>
    /// Se utiliza el nuget Specification, para establecer como se quiere organizar o filtrar la consulta
    /// </summary>
    public class PagedOwnersSpecification : Specification<Owner>
    {
        public PagedOwnersSpecification(int pageSize, int pageNumber, string name, string email)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if(string.IsNullOrEmpty(name))
            {
                Query.Search(c => c.Name, "%" + name + "%");
            }
            if (string.IsNullOrEmpty(email))
            {
                Query.Search(c => c.Email, "%" + email + "%");
            }
        }
    }
}
