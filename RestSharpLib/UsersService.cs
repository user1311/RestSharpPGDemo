using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.NewtonsoftJson;
using RestSharpLib.Models;

namespace RestSharpLib
{
    public class UsersService
    {
        private const string BaseUrl = "https://reqres.in";
        public RestClient client { get; set; }
        public UsersService()
        {
            client = new RestClient(BaseUrl);
            client.UseNewtonsoftJson();
        }

        public IRestResponse<Users> GetUsers()
        {
            //Create request
            var request = new RestRequest("/api/users",Method.GET,DataFormat.Json);
            request.AddQueryParameter("page", "2");
           
            //Execute request and return response
            var response = client.Get<Users>(request);
            return response;
        }

        public IRestResponse<SingleUser> GetUser(int Id)
        {
            //Create GET request with id parameter
            var request = new RestRequest("/api/users/" + Id,Method.GET,DataFormat.Json);

            var response = client.Get<SingleUser>(request);
            return response;
        }

        public IRestResponse<UpsertUserDTO> CreateUser(UpsertUserDTO user)
        {
            // Create POST request and add request body
            var request = new RestRequest("/api/users", Method.POST,DataFormat.Json);
            request.AddJsonBody(user);
            var response = client.Post<UpsertUserDTO>(request);
            return response;

        }

        public IRestResponse<UpsertUserDTO> UpdateUserPUT(UpsertUserDTO user, int id)
        {
            // Create PUT request and add request body
            var request = new RestRequest("/api/users"+id, Method.PUT);
            request.AddJsonBody(user);
            var response = client.Put<UpsertUserDTO>(request);
            return response;
        }

        public IRestResponse<UpsertUserDTO> UpdateUserPATCH(UpsertUserDTO user, int id)
        {
            // Create PATCH request and add request body
            var request = new RestRequest("/api/users" + id, Method.PATCH);
            request.AddJsonBody(user);
            var response = client.Patch<UpsertUserDTO>(request);
            return response;
        }

        public IRestResponse DeleteUser(int id)
        {
            // Create DELETE request and add id parameter
            var request = new RestRequest("/api/users" + id, Method.DELETE);
            var response = client.Delete(request);
            return response;
        }

        public IRestResponse<AuthUserDTO> RegisterUser(AuthUserDTO user)
        {
            //Create request with BasicAuthorization
            var request = new RestRequest("/api/register", Method.POST, DataFormat.Json);
            request.AddJsonBody(user);
            var response = client.Post<AuthUserDTO>(request);
            return response;
        }

        public IRestResponse<AuthUserDTO> Login(AuthUserDTO user)
        {
            //Create request with BasicAuthorization
            client.Authenticator = new SimpleAuthenticator("email", user.email, "password", user.password);

            var request = new RestRequest("/api/login", Method.POST, DataFormat.Json);
            var response = client.Post<AuthUserDTO>(request);
            return response;
        }
    }
}
