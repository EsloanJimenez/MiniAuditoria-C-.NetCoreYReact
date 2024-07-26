using ejpservice.Domain.Entities;
using ejpservice.Domain.Interface;
using ejpservice.Domain.Models;
using ejpservice.Infrastructure.Context;
using ejpservice.Infrastructure.Core;
using System.Linq.Expressions;

namespace ejpservice.Infrastructure.Repositories
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        private readonly EJPServiceContext context;
        public InventoryRepository(EJPServiceContext context) : base(context) 
        {
            this.context = context;
        }

        public List<InventoryModel> GetInventory()
        {
            var inventory = (from inv in this.context.Inventory
                             orderby inv.InventoryId descending
                             where inv.Deleted == false
                             select new InventoryModel()
                             {
                                 InventoryId = inv.InventoryId,
                                 Description = inv.Description,
                                 Date = inv.Date,
                                 Time = inv.Time,
                                 Price = inv.Price,
                                 Amount = inv.Amount,
                                 SubTotal = inv.Amount * inv.Price,
                             }).ToList();

            return inventory;
        }

        public SalesTotalModel GetSalesTotal()
        {
            var salesTotal = new SalesTotalModel
            {
                SalesTotal = (from st in context.Sales
                              where st.Deleted == false
                              select st.Amount * st.Price).Sum()
            };

            return salesTotal;
        }

        public override async Task Save(Inventory entity)
        {
            if (entity is null)
                throw new ArgumentException("Los datos no pueden ser nulos");

            if (await Exists(cd => cd.Description == entity.Description))
                throw new ArgumentException("El articulo ya existe.");

            base.Save(entity);
            base.SaveChanges();
        }

        public override async Task Update(Inventory entity)
        {
            try
            {
                Inventory inventoryToUpdate = await base.Get(entity.InventoryId);

                if (inventoryToUpdate is null)
                    throw new ArgumentException("El articulo no existe.");

                inventoryToUpdate.Description = entity.Description;
                inventoryToUpdate.Date = entity.Date;
                inventoryToUpdate.Time = entity.Time;
                inventoryToUpdate.Amount = entity.Amount;
                inventoryToUpdate.Price = entity.Price;
                inventoryToUpdate.ModifyDate = DateTime.Now;
                inventoryToUpdate.UserMod = entity.UserMod;

                base.Update(inventoryToUpdate);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new ArgumentException("Ocurrio un error al actualizar el articulo.");
            }
        }

        public override Task<List<Inventory>> GetAll(Expression<Func<Inventory, bool>> filter)
        {
            return base.GetAll(filter);
        }

        public override Task<Inventory> Get(int Id)
        {
            return base.Get(Id);
        }

        public override async Task Remove(Inventory entity)
        {
            try
            {
                Inventory inventoryToRemove = await base.Get(entity.InventoryId);

                if (inventoryToRemove is null)
                    throw new ArgumentException("El articulo no existe.");

                inventoryToRemove.Deleted = true;
                inventoryToRemove.DeletedDate = DateTime.Now;
                inventoryToRemove.UserDelete = 1;

                base.Update(inventoryToRemove);
                base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Ocurrio un error eliminando el cliente.");
            }
        }
    }
}
