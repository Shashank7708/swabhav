using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestaurantTableBookingApp.Core;

public partial class TimeSlot
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int DiningTableId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ReservationDay { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MealType { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? TableStatus { get; set; }
    public virtual DiningTable DiningTable { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; }=new List<Reservation>();
}
