using Microsoft.EntityFrameworkCore;
using Security.Core.Entities;
using Security.Core.Enums;

namespace Inventory.EntityFrameworkCore.Seeds
{
    public static partial class Seed
    {
        public static void SeedMenu(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityMenu>(e =>
                {
                    e.HasData(
                        new IdentityMenu
                        {
                            Id = "d7929eda-8e48-4383-8d9d-722c06969169",
                            Icon = "fa fa-plus",
                            Orden = 4,
                            TipoMenu = TipoMenu.Cabecera,
                            Name = "Artículos",
                            Url = "/items"
                        },
                        new IdentityMenu
                        {
                            Id = "2e4a8010-7a3a-444e-b8c1-6a9a934e32e6",
                            Icon = "icon-star",
                            Orden = 2,
                            TipoMenu = TipoMenu.Cabecera,
                            Name = "Areas",
                            Url = "/areas"
                        },
                        new IdentityMenu
                        {
                            Id = "cfd4b10d-3bdd-4eca-a10f-44829a21eca2",
                            Icon = "fa fa-map-marker",
                            Orden = 1,
                            TipoMenu = TipoMenu.Cabecera,
                            Name = "Almacenes",
                            Url = "/locations"
                        },
                        new IdentityMenu
                        {
                            Id = "0cc1ea20-6f37-4e62-ae66-c4937f1d02db",
                            Icon = "fa fa-industry",
                            Orden = 3,
                            TipoMenu = TipoMenu.Cabecera,
                            Name = "Fabricantes",
                            Url = "/manufacturers"
                        },
                        new IdentityMenu
                        {
                            Id = "dd20b5b6-472f-49c4-8267-74b0440f28af",
                            Icon = "fa fa-print",
                            Orden = 5,
                            TipoMenu = TipoMenu.Cabecera,
                            Name = "Reportes",
                            Url = "/reports"
                        }
                    );
                }
            );
        }
    }
}