//namespace Client.Features.DepartmentBudget.Queries.Export
//{
//    public class ExportProductsQuery : IRequest<Result<string>>
//    {
//        public string SearchString { get; set; }

//        public ExportProductsQuery(string searchString = "")
//        {
//            SearchString = searchString;
//        }
//    }

//    internal class ExportProductsQueryHandler : IRequestHandler<ExportProductsQuery, Result<string>>
//    {
//        private readonly IExcelService _excelService;
//        private readonly IUnitOfWork<int> _unitOfWork;
//        private readonly IStringLocalizer<ExportProductsQueryHandler> _localizer;

//        public ExportProductsQueryHandler(IExcelService excelService
//            , IUnitOfWork<int> unitOfWork
//            , IStringLocalizer<ExportProductsQueryHandler> localizer)
//        {
//            _excelService = excelService;
//            _unitOfWork = unitOfWork;
//            _localizer = localizer;
//        }

//        public async Task<Result<string>> Handle(ExportProductsQuery request, CancellationToken cancellationToken)
//        {
//            var productFilterSpec = new ProductFilterSpecification(request.SearchString);
//            var products = await _unitOfWork.Repository<DepartmentBudget>().Entities
//                .Specify(productFilterSpec)
//                .ToListAsync(cancellationToken);
//            var data = await _excelService.ExportAsync(products, mappers: new Dictionary<string, Func<Product, object>>
//            {
//                { _localizer["Id"], item => item.Id },
//                { _localizer["Name"], item => item.Name },
//                { _localizer["Barcode"], item => item.Barcode },
//                { _localizer["Description"], item => item.Description },
//                { _localizer["Rate"], item => item.Rate },
//                 { _localizer["FirstName"], item => item.FirstName },
//                { _localizer["LastName "], item => item.LastName  },
//                { _localizer["Address"], item => item.Address },
//                { _localizer["Occupation"], item => item.Occupation },
//                { _localizer["PhoneNumber"], item => item.PhoneNumber },
//                 { _localizer["NRC"], item => item.NRC  },
//                { _localizer["Surety"], item => item.Surety },
//                { _localizer["Proof "], item => item.Proof  },
//                { _localizer["AmountGot"], item => item.AmountGot},
//                 { _localizer["AmountToPay"], item => item.AmountToPay },
//                { _localizer["Balance"], item => item.Balance  },
//                { _localizer["LastInstallment"], item => item.LastInstallment},
//                 { _localizer["CurrentInstallment"], item => item.CurrentInstallment  },
//                { _localizer["Currency"], item => item.Currency }

//            }, sheetName: _localizer["Products"]);

//            return await Result<string>.SuccessAsync(data: data);
//        }
//    }
//}
