namespace ITechArt.FlightBookingsAPI.Web.Models;

public class GetUserModel
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}