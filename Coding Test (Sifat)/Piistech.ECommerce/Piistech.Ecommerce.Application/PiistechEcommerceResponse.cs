namespace Piistech.Ecommerce.Application
{
    public class PiistechEcommerceResponse
    {
        public bool IsSuccessful { get; set; }

        public string? Message { get; set; }

    }

    public class PiistechEcommerceResponse<T> : PiistechEcommerceResponse where T : class
    {
        public T Model { get; set; }
    }

}
