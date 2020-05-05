using Inventory.Entity;
using Microsoft.EntityFrameworkCore;

namespace Inventory.EntityFrameworkCore.Seeds
{
    public static partial class Seed
    {
        private static void SeedState(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(e =>
                {
                    e.HasData(
                        new State {StateId = 1, Name = "Azua", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 2, Name = "Baoruco", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 3, Name = "Barahona", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 4, Name = "Dajabon", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 5, Name = "Distrito nacional", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 6, Name = "Duarte", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 7, Name = "El seibo", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 8, Name = "Elias piña", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 9, Name = "Espaillat", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 10, Name = "Hato mayor", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 11, Name = "Hermanas mirabal", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 12, Name = "Independencia", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 13, Name = "La altagracia", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 14, Name = "La romana", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 15, Name = "La vega", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                        {
                            StateId = 16, Name = "Maria trinidad sanchez", CountryId = Country.REPUBLICA_DOMINICANA
                        },
                        new State
                            {StateId = 17, Name = "Monseñor nouel", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 18, Name = "Monte cristi", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 19, Name = "Monte plata", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 20, Name = "Pedernales", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 21, Name = "Peravia", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 22, Name = "Puerto plata", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 23, Name = "Samana", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 24, Name = "San cristobal", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 25, Name = "San jose de ocoa", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 26, Name = "San juan", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                        {
                            StateId = 27, Name = "San pedro de macoris", CountryId = Country.REPUBLICA_DOMINICANA
                        },
                        new State
                            {StateId = 28, Name = "Sanchez ramirez", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State {StateId = 29, Name = "Santiago", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                            {StateId = 30, Name = "Santiago rodriguez", CountryId = Country.REPUBLICA_DOMINICANA},
                        new State
                        {
                            StateId = State.SANTO_DOMINGO, Name = "Santo domingo",
                            CountryId = Country.REPUBLICA_DOMINICANA
                        },
                        new State {StateId = 32, Name = "Valverde", CountryId = Country.REPUBLICA_DOMINICANA}
                    );
                }
            );
        }
    }
}