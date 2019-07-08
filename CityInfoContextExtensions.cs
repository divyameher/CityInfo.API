using System.Collections.Generic;
using System.Linq;
using CityInfo.API.Entities;
using CityInfo.API.Models;

namespace CityInfo.API
{
    public static class CityInfoContextExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            //init seed data
            var cities = new List<City>()
            {
                new City(){
                    Name="New York City",
                    Description="Some Description",
                    PointsOfInterest=new List<PointOfInterest>(){
                        new PointOfInterest(){
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterest(){
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                },
                new City()
                {
                    Name = "Empire",
                    Description = "Some Description",
                    PointsOfInterest=new List<PointOfInterest>(){
                        new PointOfInterest(){
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterest(){
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                },
                new City()
                {
                    Name = "Dallas",
                    Description = "Some Description",
                    PointsOfInterest=new List<PointOfInterest>(){
                        new PointOfInterest(){
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterest(){
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                },
                new City()
                {
                    Name = "Los Angeles",
                    Description = "Some Description",
                    PointsOfInterest=new List<PointOfInterest>(){
                        new PointOfInterest(){
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterest(){
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                }
            };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }

}