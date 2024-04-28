using McF.Process.DAL;
using McF.Process.Models;
using McF.Process.Queries;
using MediatR;

namespace McF.Process.Handlers
{
    public class GetAllProductTypesHandler : IRequestHandler<GetAllProductTypesQuery, IEnumerable<ProductType>>
    {
        private readonly IRepository repository;

        public GetAllProductTypesHandler(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<ProductType>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProductType> productTypes = await repository.GetAllProductTypes().ConfigureAwait(false);
            productTypes.Where(productType => productType != null && productType.Products != null)
               .SelectMany(productType => productType.Products!)
               .Where(product => product.ImageByteArray != null)
               .ToList()
               .ForEach(product => product.ImageBase64 = Convert.ToBase64String(product.ImageByteArray!));
            return productTypes;
        }
    }
}
