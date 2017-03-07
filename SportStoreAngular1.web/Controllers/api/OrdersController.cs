using SportStoreAngular1.data;
using SportStoreAngular1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SportStoreAngular1.web.Controllers.api
{
    public class OrdersController : ApiController
    {
        //Install DI container for this
        private OrderRepository repo { get; set; }

        public OrdersController()
        {
            repo = new OrderRepository();
        }

        public IHttpActionResult GetOrders()
        {
            return Ok(repo.GetAll());
        }

        public IHttpActionResult GetOrder(int id)
        {
            var order = repo.GetAll().FirstOrDefault(p => p.Id == id);
            if (order == null)
                return NotFound();

            return Ok(order);
        }

        public async Task<IHttpActionResult> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repo.Save(order);
            return Ok(order.Id);
        }

        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            var order = repo.GetAll().FirstOrDefault(p => p.Id == id);
            if (order == null)
                return NotFound();

            await repo.Delete(id);
            return Ok(string.Format("The order with Id {0} was deleted.", id));
        }
    }
}
