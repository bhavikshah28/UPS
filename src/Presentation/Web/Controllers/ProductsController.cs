using System.Threading.Tasks;
using UPS.Application.Features.Products.Commands.CreateProduct;
using UPS.Application.Features.Products.Commands.DeleteProduct;
using UPS.Application.Features.Products.Commands.UpdateProduct;
using UPS.Application.Features.Products.Queries.GetProductDetail;
using UPS.Application.Features.Products.Queries.GetProductsFile;
using UPS.Application.Features.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace UPS.Web.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetProductsListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailVm>> Get(int id)
        {
            var vm = await Mediator.Send(new GetProductDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command)
        {
            var productId = await Mediator.Send(command);

            return Ok(productId);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }

        [HttpGet]
        public async Task<FileResult> Download()
        {
            var vm = await Mediator.Send(new GetProductsFileQuery());

            return File(vm.Content, vm.ContentType, vm.FileName);
        }
    }
}