using System.Collections.Generic;
using UPS.Application.Features.Products.Queries.GetProductsFile;

namespace UPS.Application.Abstractions
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<ProductRecordDto> records);
    }
}
