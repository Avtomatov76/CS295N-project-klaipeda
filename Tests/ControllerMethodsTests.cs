using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using KlaipedaCity.Repos;
using KlaipedaCity.Controllers;
using KlaipedaCity.Models;
using System.Linq;

namespace Tests
{
    public class ControllerMethodsTests
    {
        [Fact]
        public void AddRestaurantTest()
        {
            // Arrange
            var fakeRepo = new FakeRestaurantRepository();
            var controller = new RestaurantController(fakeRepo);
            var restaurant = new Restaurant()
            {
                RestaurantName = "HBH",
                CuisineName = new Cuisine() { CuisineName = "Lithuanian" },
                RestaurantDesc = "Awesome family restaurant",
                RestaurantRating = 4,
                RestaurantPrice = 15,
                RestaurantLink = "www.hbh.lt"
            };

            // Act
            controller.Add(restaurant);

            // Assert
            var retrievedRestaurant = fakeRepo.Restaurants.ToList()[0];
            Assert.Equal("HBH", retrievedRestaurant.RestaurantName);
            Assert.Equal(15, retrievedRestaurant.RestaurantPrice);
        }

        [Fact]
        public void UpdateRestaurantTest()
        {
            // Arrange
            var fakeRepo = new FakeRestaurantRepository();
            var controller = new RestaurantController(fakeRepo);
            var restaurant = new Restaurant()
            {
                RestaurantName = "HBH",
                CuisineName = new Cuisine() { CuisineName = "Lithuanian" },
                RestaurantDesc = "Awesome family restaurant",
                RestaurantRating = 4,
                RestaurantPrice = 15,
                RestaurantLink = "www.hbh.lt"
            };

            // Act
            controller.Edit(restaurant); // There is already a restaurant object in the FakeRestaurantRepository that is being updated

            // Assert
            var retrievedRestaurant = fakeRepo.Restaurants.ToList()[0];
            Assert.Equal("HBH", retrievedRestaurant.RestaurantName);
            Assert.Equal(15, retrievedRestaurant.RestaurantPrice);
            Assert.Equal("Awesome family restaurant", retrievedRestaurant.RestaurantDesc);
        }

        [Fact]
        public void DeleteRestaurantTest()
        {
            // Arrange
            var fakeRepo = new FakeRestaurantRepository();
            var controller = new RestaurantController(fakeRepo);
            var restaurant = new Restaurant()
            {
                RestaurantName = "HBH",
                CuisineName = new Cuisine() { CuisineName = "Lithuanian" },
                RestaurantDesc = "Awesome family restaurant",
                RestaurantRating = 4,
                RestaurantPrice = 15,
                RestaurantLink = "www.hbh.lt"
            };

            // Act
            controller.Add(restaurant);
            // Making sure the hotel was added
            var newRestaurant = fakeRepo.Restaurants.Where(r => r.RestaurantID == restaurant.RestaurantID).FirstOrDefault();
            Assert.Equal("HBH", newRestaurant.RestaurantName);
            controller.Delete(restaurant);

            // Assert
            var retrievedRestaurant = fakeRepo.Restaurants.Where(r => r.RestaurantID == restaurant.RestaurantID).FirstOrDefault();
            Assert.Null(retrievedRestaurant);
        }

        [Fact]
        public void AddHotelTest()
        {
            // Arrange
            var fakeRepo = new FakeHotelRepository();
            var controller = new HotelController(fakeRepo);
            var hotel = new Hotel()
            {
                HotelName = "Memel Hotel",
                HotelAddress = "Herkaus g. 15",
                HotelRating = 4,
                HotelPrice = 55,
                HotelLink = "www.memelhotel.lt"
            };

            // Act
            controller.Add(hotel);

            // Assert
            var retrievedHotel = fakeRepo.Hotels.ToList()[0];
            Assert.Equal("Memel Hotel", retrievedHotel.HotelName);
            Assert.Equal(4, retrievedHotel.HotelRating);
            Assert.Equal("Herkaus g. 15", retrievedHotel.HotelAddress);
        }

        [Fact]
        public void UpdateHotelTest()
        {
            // Arrange
            var fakeRepo = new FakeHotelRepository();
            var controller = new HotelController(fakeRepo);
            var hotel = new Hotel()
            {
                HotelName = "Klaipeda Hotel",
                HotelAddress = "Kauno g. 11",
                HotelRating = 3,
                HotelPrice = 45,
                HotelLink = "www.memelhotel.lt"
            };

            // Act
            controller.Edit(hotel); // There is already another hotel object in the FakeHotelRepository that is being updated

            // Assert
            var retrievedHotel = fakeRepo.Hotels.ToList()[0];
            Assert.Equal("Klaipeda Hotel", retrievedHotel.HotelName);
            Assert.Equal(45, retrievedHotel.HotelPrice);
            Assert.Equal("Kauno g. 11", retrievedHotel.HotelAddress);
        }

        [Fact]
        public void DeleteHotelTest()
        {
            // Arrange
            var fakeRepo = new FakeHotelRepository();
            var controller = new HotelController(fakeRepo);
            var hotel = new Hotel()
            {
                HotelName = "Klaipeda Hotel",
                HotelAddress = "Kauno g. 11",
                HotelRating = 3,
                HotelPrice = 45,
                HotelLink = "www.memelhotel.lt"
            };

            // Act
            controller.Add(hotel);
            controller.Delete(hotel);

            // Assert
            var retrievedHotel = fakeRepo.Hotels.Where(h => h.HotelID == hotel.HotelID).FirstOrDefault();
            Assert.Null(retrievedHotel);
        }
    }
}
