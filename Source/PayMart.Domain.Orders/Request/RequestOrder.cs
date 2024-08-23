﻿namespace PayMart.Domain.Orders.Request;

public class RequestOrder
{
    public int ProductID { get; set; }

    public string Name { get; set; } = "";
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int UserID {  get; set; }
}

