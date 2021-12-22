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
    public class PagedPropertiesSpecification : Specification<Property>
    {
        public PagedPropertiesSpecification(int pageSize, int pageNumber, string name, string addres, double price, string codInternal, int year)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (string.IsNullOrEmpty(name))
            {
                Query.Search(c => c.Name, "%" + name + "%");
            }
            if (string.IsNullOrEmpty(addres))
            {
                Query.Search(c => c.Address, "%" + addres + "%");
            }
            if (string.IsNullOrEmpty(price.ToString()))
            {
                Query.Search(c => c.Price.ToString(), "%" + price + "%");
            }
            if (string.IsNullOrEmpty(codInternal))
            {
                Query.Search(c => c.CodInternal, "%" + codInternal + "%");
            }
            if (string.IsNullOrEmpty(year.ToString()))
            {
                Query.Search(c => c.Year.ToString(), "%" + year + "%");
            }
        }
    }
}
