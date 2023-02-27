

using EF_Code_first_tutorial;
using EF_Code_first_tutorial.Models;
using Microsoft.EntityFrameworkCore;

var _context = new SalesDbContext();

//_context.Customers.ToList().ForEach(x => Console.WriteLine(x.Name));

var order = _context.Orders.Include(x => x.OrderLines)
                                .ThenInclude(x => x.Item)
                           .Include(x => x.Customer)
                           .Single(x => x.Id == 4);

Console.WriteLine($"ORDER: Description: {order.Description}");
foreach(var orderline in order.OrderLines)
{
    
    Console.WriteLine($"ORDERLINE: Product: {orderline.Item.Name} Quarntity: {orderline.Quantity} Price: {orderline.Item.Price:C} Line total: {orderline.Quantity * orderline.Item.Price:C}");
    


}
var ordertotal = order.OrderLines.Sum(orderline => orderline.Item.Price * orderline.Quantity);
Console.WriteLine($"Total: {ordertotal:C}");