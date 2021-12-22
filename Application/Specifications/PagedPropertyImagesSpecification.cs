using Ardalis.Specification;
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
    public class PagedPropertyImagesSpecification : Specification<Domain.Entities.PropertyImage>
    {
        public PagedPropertyImagesSpecification(int pageSize, int pageNumber, int idProperty)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (string.IsNullOrEmpty(idProperty.ToString()))
            {
                Query.Search(c => c.IdProperty.ToString(), "%" + idProperty + "%");
            }
        }
    }
}
