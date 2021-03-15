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
        // ATTENTION: Had to disable UserManager functionality within some of the methods in ForumController to run some of the tests - it was not passing otherwise.
        #region
        // TESTING RESTAURANT CONTROLLER METHODS
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
                RestaurantLink = "www.hbh.lt",
                Sender = new AppUser() { SenderName = "Chef Gordon" }
            };

            // Act
            controller.Add(restaurant);

            // Assert
            var retrievedRestaurant = fakeRepo.Restaurants.ToList()[0];
            Assert.Equal("HBH", retrievedRestaurant.RestaurantName);
            Assert.Equal(15, retrievedRestaurant.RestaurantPrice);
            Assert.Equal("Chef Gordon", retrievedRestaurant.Sender.SenderName);
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
                RestaurantLink = "www.hbh.lt",
                Sender = new AppUser() { SenderName = "Chef Ramsey" }
            };

            // Act
            controller.Edit(restaurant); // There is already a restaurant object in the FakeRestaurantRepository that is being updated

            // Assert
            var retrievedRestaurant = fakeRepo.Restaurants.ToList()[0];
            Assert.Equal("HBH", retrievedRestaurant.RestaurantName);
            Assert.Equal(15, retrievedRestaurant.RestaurantPrice);
            Assert.Equal("Awesome family restaurant", retrievedRestaurant.RestaurantDesc);
            Assert.Equal("Chef Ramsey", retrievedRestaurant.Sender.SenderName);
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
                RestaurantLink = "www.hbh.lt",
                Sender = new AppUser() { SenderName = "Chef Tortelinni" }
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
        #endregion

        #region
        // TESTING HOTEL CONTROLLER METHODS
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
                HotelLink = "www.memelhotel.lt",
                Sender = new AppUser() { SenderName = "Donald Trump" }
            };

            // Act
            controller.Add(hotel);

            // Assert
            var retrievedHotel = fakeRepo.Hotels.ToList()[0];
            Assert.Equal("Memel Hotel", retrievedHotel.HotelName);
            Assert.Equal(4, retrievedHotel.HotelRating);
            Assert.Equal("Herkaus g. 15", retrievedHotel.HotelAddress);
            Assert.Equal("Donald Trump", retrievedHotel.Sender.SenderName);
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
                HotelLink = "www.memelhotel.lt",
                Sender = new AppUser() { SenderName = "Will Smith" }
            };

            // Act
            controller.Edit(hotel); // There is already another hotel object in the FakeHotelRepository that is being updated

            // Assert
            var retrievedHotel = fakeRepo.Hotels.ToList()[0];
            Assert.Equal("Klaipeda Hotel", retrievedHotel.HotelName);
            Assert.Equal(45, retrievedHotel.HotelPrice);
            Assert.Equal("Kauno g. 11", retrievedHotel.HotelAddress);
            Assert.Equal("Will Smith", retrievedHotel.Sender.SenderName);
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
                HotelLink = "www.memelhotel.lt",
                Sender = new AppUser() { SenderName = "Will Smith" }
            };

            // Act
            controller.Add(hotel);
            controller.Delete(hotel);

            // Assert
            var retrievedHotel = fakeRepo.Hotels.Where(h => h.HotelID == hotel.HotelID).FirstOrDefault();
            Assert.Null(retrievedHotel);
        }
        #endregion

        #region 
        // TESTING FORUM POST CONTROLLER METHODS
        [Fact]
        public void AddForumPostTest()
        {
            // Arrange
            var fakeRepo = new FakeForumRepository();
            var controller = new ForumController(fakeRepo, null);
            var post = new ForumPost()
            {
                Subject = "Hello",
                Sender = new AppUser() { SenderName = "Me" },
                ForumPostBody = "TESTING ADD METHOD",
                DateSent = DateTime.Today
            };

            // Act
            controller.Forum(post);

            // Assert
            var retrievedPost = fakeRepo.ForumPosts.ToList()[0];
            Assert.Equal("Hello", retrievedPost.Subject);
            Assert.Equal(System.DateTime.Now.Date.CompareTo(retrievedPost.DateSent.Date), 0);
        }

        [Fact]
        public void GetForumPostBySubjectTest()
        {
            // Arrange
            var fakeRepo = new FakeForumRepository();
            var controller = new ForumController(fakeRepo, null);

            var post1 = new ForumPost()
            {
                Subject = "Hello",
                Sender = new AppUser() { SenderName = "Me" },
                ForumPostBody = "TESTING ADD METHOD #1",
                DateSent = DateTime.Today
            };

            var post2 = new ForumPost()
            {
                Subject = "Hello",
                Sender = new AppUser() { SenderName = "You" },
                ForumPostBody = "TESTING ADD METHOD #2",
                DateSent = DateTime.Today
            };

            // Act
            controller.Forum(post1);
            controller.Forum(post2);

            // Assert
            int postCount = fakeRepo.ForumPosts.Where(p => p.Subject == "Hello").Count();
            Assert.Equal(2, postCount);
        }

        [Fact]
        public void UpdateForumPostAddCommentTest()
        {
            // Arrange
            var fakeRepo = new FakeForumRepository();
            var controller = new ForumController(fakeRepo, null);
            var post = new ForumPost()
            {
                Subject = "Hello",
                Sender = new AppUser() { SenderName = "Me" },
                ForumPostBody = "TESTING ADD METHOD",
                DateSent = DateTime.Today
            };

            // Act
            controller.Forum(post);
            fakeRepo.UpdateForumPost(post);

            // Assert
            var retrievedPost = fakeRepo.ForumPosts.ToList()[0];
            Assert.Equal("TESTING ADD METHOD", retrievedPost.ForumPostBody);
            Assert.Equal(1, retrievedPost.Comments.Count);
        }

        #endregion
    }
}
