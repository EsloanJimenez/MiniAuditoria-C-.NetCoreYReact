using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using ejpservice.Infrastructure.Context;
using ejpservice.Infrastructure.Core;
using System.Linq.Expressions;

namespace ejpservice.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customers>, ICustomersRepository
    {
        private readonly EJPServiceContext context;

        public CustomerRepository(EJPServiceContext context) : base(context)
        {
            this.context = context;
        }

        public List<CustomerModel> GetCustomers()
        {
            var customer = (from cu in this.context.Customers
                            orderby cu.CustomerId descending
                            where cu.Deleted == false
                            select new CustomerModel()
                            {
                                CustomerId = cu.CustomerId,
                                FirstName = cu.FirstName,
                                LastName = cu.LastName,
                                CompanyName = cu.CompanyName,
                                Email = cu.Email,
                                Phone = cu.Phone,
                            }).ToList();

            return customer;
        }

        public override async Task Save(Customers entity)
        {
            if (entity is null) 
                throw new ArgumentException("Los datos no pueden ser nulos");

            if (await Exists(cd => cd.FirstName == entity.FirstName))
                throw new ArgumentException("El cliente ya existe.");

            base.Save(entity);
            base.SaveChanges();
        }

        public override async Task Update(Customers entity)
        {
            try
            {
                Customers customerToUpdate = await base.Get(entity.CustomerId);

                if (customerToUpdate is null)
                    throw new ArgumentException("El cliente no existe.");

                customerToUpdate.FirstName = entity.FirstName;
                customerToUpdate.LastName = entity.LastName;
                customerToUpdate.CompanyName = entity.CompanyName;
                customerToUpdate.TradeName = entity.TradeName;
                customerToUpdate.Email = entity.Email;
                customerToUpdate.Phone = entity.Phone;
                customerToUpdate.Rnc = entity.Rnc;
                customerToUpdate.ModifyDate = DateTime.Now;
                customerToUpdate.UserMod = entity.UserMod;

                base.Update(customerToUpdate);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ArgumentException("Ocurrio un error al actualizar el cliente.");
            }
        }

        public override Task<List<Customers>> GetAll(Expression<Func<Customers, bool>> filter)
        {
            return base.GetAll(filter);
        }

        public override Task<Customers> Get(int Id)
        {
            return base.Get(Id);
        }

        public override async Task Remove(Customers entity)
        {
            try
            {
                Customers customerToRemove = await base.Get(entity.CustomerId);

                if (customerToRemove is null)
                    throw new ArgumentException("El cliente no existe.");

                customerToRemove.Deleted = true;
                customerToRemove.DeletedDate = DateTime.Now;
                customerToRemove.UserDelete = 1;

                base.Update(customerToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error actualizando el cliente.");
            }
        }
    }
}