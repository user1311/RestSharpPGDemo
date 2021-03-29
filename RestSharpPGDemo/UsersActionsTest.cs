using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharpLib;
using RestSharpLib.Models;
using System;

namespace RestSharpPGDemo
{
    [TestClass]
    public class UsersActionsTest
    {
        #region Init
        private static UsersService _usersService;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _usersService = new UsersService();
        }
        #endregion

        #region Tests

        /// <summary>
        /// Tests with REST UsersService and RestSharp Json Deserializer
        /// </summary>

        [TestMethod]
        public void GetAllUsers()
        {
            //Arrange
            var response = _usersService.GetUsers();
            //Act
            var users = response.Data.data;
            //Assert
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.IsTrue(users.Count==6);
            Assert.AreEqual("Michael", users[0].first_name);
        }

        [TestMethod]
        public void GetSingleUser()
        {
            var response = _usersService.GetUser(1);
            var user = response.Data.data;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual("george.bluth@reqres.in", user.email);
            Assert.AreEqual("George",user.first_name);
            Assert.AreEqual("Bluth",user.last_name);
        }

        [TestMethod]
        public void GetSingleUser_NotFound()
        {
            var response = _usersService.GetUser(9999);
            var user = response.Data.data;
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void CreateUser()
        {
            //Create user
            UpsertUserDTO user = new UpsertUserDTO()
            {
                name = "Adnan",
                job = "QA"
            };

            var response = _usersService.CreateUser(user);
            var createdUser = response.Data;
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
            Assert.AreEqual(response.Data.name, user.name);
            Assert.AreEqual(response.Data.job, user.job);
        }

        [TestMethod]
        public void UpdateUserPUT()
        {
            //Create user
            UpsertUserDTO user = new UpsertUserDTO()
            {
                name = "Adnan Updated PUT",
                job = "Quality Assurance"
            };

            var response = _usersService.UpdateUserPUT(user,2);
            var createdUser = response.Data;
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.Data.name, user.name);
            Assert.AreEqual(response.Data.job, user.job);
        }

        [TestMethod]
        public void UpdateUserPATCH()
        {
            //Create user
            UpsertUserDTO user = new UpsertUserDTO()
            {
                name = "Adnan Updated PATCH",
                job = "Quality Assurance"
            };

            var response = _usersService.UpdateUserPATCH(user, 2);
            var createdUser = response.Data;
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.Data.name, user.name);
            Assert.AreEqual(response.Data.job, user.job);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var response = _usersService.DeleteUser(2);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [TestMethod]
        public void RegisterUser()
        {
            AuthUserDTO registerUser = new AuthUserDTO()
            {
                email = "eve.holt@reqres.in",
                password = "pistol"
            };

            var response = _usersService.RegisterUser(registerUser);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.Data.id,4);
            Assert.AreEqual(response.Data.token, "QpwL5tke4Pnpja7X4");
        }

        [TestMethod]
        public void RegisterUser_BadRequest()
        {
            AuthUserDTO registerUser = new AuthUserDTO()
            {
                email = "eve.holt@reqres.in",
            };

            var response = _usersService.RegisterUser(registerUser);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void LoginUser()
        {
            AuthUserDTO loginUser = new AuthUserDTO()
            {
                email = "eve.holt@reqres.in",
                password = "cityslicka"
            };

            var response = _usersService.Login(loginUser);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.AreEqual(response.Data.token, "QpwL5tke4Pnpja7X4");
        }

        [TestMethod]
        public void Login_BadRequest()
        {
            AuthUserDTO loginUser = new AuthUserDTO()
            {
                email = "eve.holt@reqres.in",
            };

            var response = _usersService.Login(loginUser);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void GetFirstNameInfo()
        {

            //Creating Client connection 
            RestClient restClient = new RestClient("https://reqres.in");


            //Creating request to get data from server
            RestRequest restRequest = new RestRequest("/api/users/2", Method.GET);


            // Executing request to server and checking server response to the it
            IRestResponse restResponse = restClient.Execute(restRequest);


            // Extracting output data from received response
            string response = restResponse.Content;

            // Parsing JSON content into element-node JObject
            var jObject = JObject.Parse(restResponse.Content);

            //Extracting Node element using Getvalue method
            string fName = (string)jObject["data"]["first_name"];
            // Let us print the city variable to see what we got
            Console.WriteLine("First Name recieved " + fName);

            // Validate the response
            Assert.AreEqual("Janet", fName, "Correct first name received in the Response");
        }

        #endregion

    }
}
