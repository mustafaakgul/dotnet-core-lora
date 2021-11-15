using LoRaWAN.Entity.Enums;
using LoRaWAN.Entity.DTOs.Common;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using ProjNet;
using ProjNet.CoordinateSystems;
using System;
using System.Collections.Generic;
using CommonLocation = LoRaWAN.Entity.DTOs.Common.Location;

namespace LoRaWAN.Data.Extensions
{
    public static class GISExtension
    {
        public static Distances ToMeters(this double meters)
        {
            var result = new Distances();

            if (meters < 1000)
            {
                var meter = Math.Round(meters, 2);
                if (meter < 1000)
                {
                    result.Distance = meter;
                    return result;
                }
            }

            result.Distance = Math.Round((meters / 1000), 2);
            result.Unit = DistanceUnit.kilometers;

            return result;
        }

        public static Distances ToMeters(this Point point, Point currentPoint)
        {
            var result = new Distances();

            // Radius of earth in meters. Use 6371 for kilometers. Use 3956 for miles
            double m = 6371000;
            double km = 6371;

            // Haversine formula  
            double dlon = toRadians(currentPoint.X) - toRadians(point.X);
            double dlat = toRadians(currentPoint.Y) - toRadians(point.Y);
            double a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(toRadians(point.Y)) * Math.Cos(toRadians(currentPoint.Y)) * Math.Pow(Math.Sin(dlon / 2), 2);
            double c = 2 * Math.Asin(Math.Sqrt(a));

            // calculate the meters 
            double meters = c * m;

            if (meters < 1000)
            {
                var meter = Math.Round(meters, 2);
                if (meter < 1000)
                {
                    result.Distance = meter;
                    return result;
                }
            }

            result.Distance = Math.Round(c * km, 2);
            result.Unit = DistanceUnit.kilometers;

            return result;
        }
        public static CommonLocation ToLocation(this Point point)
        {
            return new CommonLocation()
            {
                Latitude = point.X,
                Longitude = point.Y
            };
        }
        public static CommonLocation ToLocation(this Point point, Point currentPoint)
        {
            return new CommonLocation()
            {
                Latitude = point.X,
                Longitude = point.Y,
                Distance = point.ToMeters(currentPoint)
            };
        }
        //MSK-------------------------------------------
        public static LocationModel ToLocationWithoutDistance(this Point point, Point currentPoint)
        {
            return new LocationModel()
            {
                Latitude = point.X,
                Longitude = point.Y,
            };
        }
        //-------------------------------------------

        public static Point CreatePoint(double latitude, double longitude)
        {
            // 4326 is most common coordinate system used by GPS/Maps
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            // see https://docs.microsoft.com/en-us/ef/core/modeling/spatial
            // Longitude and Latitude
            var newLocation = geometryFactory.CreatePoint(new Coordinate(latitude, longitude));

            return newLocation;
        }
        
        public static double toRadians(double angleIn10thofaDegree)
        {
            // Angle in 10th 
            // of a degree 
            return (angleIn10thofaDegree * Math.PI) / 180;
        }

        public static double KiloMeterDistance(this Point point, Point currentPoint)
        {
            // Haversine formula  
            double dlon = toRadians(currentPoint.X) - toRadians(point.X);
            double dlat = toRadians(currentPoint.Y) - toRadians(point.Y);
            double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                       Math.Cos(toRadians(point.Y)) * Math.Cos(toRadians(currentPoint.Y)) *
                       Math.Pow(Math.Sin(dlon / 2), 2);

            double c = 2 * Math.Asin(Math.Sqrt(a));

            // Radius of earth in meters
            // Use 6371 for kilometers.
            // Use 3956 for miles
            double r = 6371000;

            // calculate the result 
            return (c * r);
        }

    }
}
