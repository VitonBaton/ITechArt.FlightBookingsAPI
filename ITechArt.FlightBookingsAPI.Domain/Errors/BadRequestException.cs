﻿namespace ITechArt.FlightBookingsAPI.Domain.Errors;

public class BadRequestException : Exception
{
    public BadRequestException() {}
    public BadRequestException(string message) : base(message) {}
}