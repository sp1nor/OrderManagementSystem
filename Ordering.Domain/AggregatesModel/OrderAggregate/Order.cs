﻿using Ordering.Domain.AggregatesModel.OrderAggregate.ValueObjects;
using Ordering.Domain.Common.Models;

namespace Ordering.Domain.AggregatesModel.OrderAggregate;

public class Order : AggregateRoot<OrderId>
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string UserName { get; set; }
    public decimal TotalPrice { get; set; }

    // BillingAddress
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string AddressLine { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
}
