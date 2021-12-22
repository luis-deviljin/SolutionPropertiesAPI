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
    public class PagedPropertyTracesSpecification : Specification<Domain.Entities.PropertyTrace>
    {
        public PagedPropertyTracesSpecification(int pageSize, int pageNumber, string date, string name, double value, double tax)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (string.IsNullOrEmpty(date))
            {
                Query.Search(c => c.DateSale.ToString(), "%" + date + "%");
            }
            if (string.IsNullOrEmpty(name))
            {
                Query.Search(c => c.Name, "%" + name + "%");
            }
            if (string.IsNullOrEmpty(value.ToString()))
            {
                Query.Search(c => c.Value.ToString(), "%" + value + "%");
            }
            if (string.IsNullOrEmpty(tax.ToString()))
            {
                Query.Search(c => c.Tax.ToString(), "%" + tax + "%");
            }
        }
    }
}
