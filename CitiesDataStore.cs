using System.Collections.Generic;
using CityInfo.API.Models;

namespace CityInfo.API
{
    class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto(){
                    Id=1,
                    Name="New York City",
                    Description="Some Description",
                    PointsOfInterest=new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id=1,
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterestDto(){
                            Id=2,
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Empire",
                    Description = "Some Description",
                    PointsOfInterest=new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id=1,
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterestDto(){
                            Id=2,
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Dallas",
                    Description = "Some Description",
                    PointsOfInterest=new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id=1,
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterestDto(){
                            Id=2,
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 4,
                    Name = "Los Angeles",
                    Description = "Some Description",
                    PointsOfInterest=new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id=1,
                            Name="Park",
                            Description="Nice Park"
                        },
                        new PointOfInterestDto(){
                            Id=2,
                            Name="Lake",
                            Description="Nice Lake"
                        }
                    }
                }
            };
        }
    }
}