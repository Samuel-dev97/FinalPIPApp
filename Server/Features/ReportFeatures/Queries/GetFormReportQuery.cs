//using MediatR;
//using Server.Interface;
//using Shared.Wrappers;


//namespace Server.Features.ReportFeatures.Queries
//{
//    public class GetFormReportQuery : IRequest<Response<IEnumerable<FormViewModel>>>
//    {
//        public Enums.Status? Status { get; set; }
//        public string? Gender { get; set; }
//        public class GetFormReportQueryHandler : IRequestHandler<GetFormReportQueryQuery, Response<IEnumerable<FormViewModel>>>
//        {
//            private readonly IReportRepositoryAsync _repository;
//            public GetFormReportQueryQueryHandler(IReportRepositoryAsync repository)
//            {
//                _repository = repository;
//            }

//            public async Task<Response<IEnumerable<EmployeeViewModel>>> Handle(GetAllEmployeesReportQuery request, CancellationToken cancellationToken)
//            {
//                var response = await _repository.GetAllEmployeesAsync(request.Gender, request.Status);
//                return new Response<IEnumerable<EmployeeViewModel>>(response);
//            }
//        }
//    }
//}
