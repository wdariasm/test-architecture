using System.Collections.Generic;
using MediatR;

namespace TicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery: IRequest<List<CategoryListVm>>
    {
    }
}
