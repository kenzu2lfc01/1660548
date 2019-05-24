using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using triluatsoft.tls.Domain.ReviewComments;
using triluatsoft.tls.Services.ReviewComments.Dto;

namespace triluatsoft.tls.Services.ReviewComments
{
    public interface IReviewCommentAppService : IApplicationService
    {

        Task CreateReviewCommentAsync(CreateReviewCommentDto input);
        Task DeleteReviewCommentAsync(Guid Id);
        Task UpdateReviewCommentAsync(UpdateReviewCommentDto input);

        Task<List<GetReviewCommentDto>> GetReviewCommentByHotelId(Guid input);
    }
}
