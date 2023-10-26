namespace Session5.Models
{
    public class Response<T>
    {
        public string message { get; set; }
        public T response { get; set; }

        public Response(string message, T response)
        {
            this.message = message;
            this.response = response;
        }

    }
}
