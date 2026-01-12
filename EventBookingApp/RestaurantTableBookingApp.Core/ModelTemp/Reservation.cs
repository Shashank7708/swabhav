using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestaurantTableBookingApp.Core;

public partial class Reservation
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TableId { get; set; }


    public DateOnly ReservationDate { get; set; }
    public string ReservationStatus { get; set; }

    public virtual TimeSlot TimeSlot { get; set; }= null!;
    public virtual User User { get; set; } = null!;
}
