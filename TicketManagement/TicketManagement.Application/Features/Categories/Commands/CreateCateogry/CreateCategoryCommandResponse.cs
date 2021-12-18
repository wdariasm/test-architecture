using TicketManagement.Application.Responses;

namespace TicketManagement.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryDto Category { get; set; }
    }
}
