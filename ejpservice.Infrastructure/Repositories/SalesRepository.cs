using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using ejpservice.Infrastructure.Context;
using ejpservice.Infrastructure.Core;
using Mysqlx;

namespace ejpservice.Infrastructure.Repositories
{
    public class SalesRepository : BaseRepository<Sales>, ISalesRepository
    {
        private readonly EJPServiceContext _context;
        public SalesRepository(EJPServiceContext context) : base(context)
        {
            _context = context;
        }

        public List<SalesModel> GetSales()
        {
            var sales = (from s in _context.Sales
                         join c in _context.Customers
                         on s.CustomerId equals c.CustomerId
                         orderby s.SaleId descending
                         where s.Deleted == false
                         select new SalesModel()
                         {
                             SaleId = s.SaleId,
                             CustomerId = c.CustomerId,
                             Description = s.Description,
                             FirstName = c.FirstName,
                             Date = s.Date,
                             Time = s.Time,
                             Amount = s.Amount,
                             Price = s.Price,
                             SubTotal = s.Amount * s.Price
                         }).ToList();

            return sales;
        }

        public override async Task Save(Sales sales)
        {
            if(sales is null)
                throw new ArgumentException("Los daots no pueden ser nulos");

            if (await Exists(cd => cd.Description == sales.Description))
                throw new ArgumentException("El evento ya existe");

            base.Save(sales);
            base.SaveChanges();
        }

        public override async Task Update(Sales sales)
        {
            try
            {
                Sales salesToUpdate = await base.Get(sales.SaleId);

                if (salesToUpdate is null)
                    throw new ArgumentException("La venta no existe");

                salesToUpdate.Description = sales.Description;
                salesToUpdate.CustomerId = sales.CustomerId;
                salesToUpdate.Date = sales.Date;
                salesToUpdate.Time = sales.Time;
                salesToUpdate.Amount = sales.Amount;
                salesToUpdate.Price = sales.Price;
                salesToUpdate.ModifyDate = DateTime.Now;
                salesToUpdate.UserMod = sales.UserMod;

                base.Update(salesToUpdate);
                base.SaveChanges();
            }catch(Exception ex)
            {
                throw new ArgumentException("Ocurrio un error al actualizar la venta");
            }
        }

        public override async Task Remove(Sales sales)
        {
            try
            {
                Sales salesToRemove = await base.Get(sales.SaleId);

                if (salesToRemove is null)
                    throw new ArgumentException("La venta no existe");

                salesToRemove.Deleted = true;
                salesToRemove.DeletedDate = DateTime.Now;
                salesToRemove.UserDelete = 1;

                base.Update(salesToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error eliminando la venta");
            }
        }
    }
}
