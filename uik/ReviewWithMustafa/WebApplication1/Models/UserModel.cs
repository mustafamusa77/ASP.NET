using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace WebApplication1.Models;

public class UserModel
{
    public int Age { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }
}