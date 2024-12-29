using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Parkingapp
{
    public class controller
    {
    }
}

public class ParkingController : ControllerBase
{
    private static List<ParkingRecord> _parkingRecords = new List<ParkingRecord>();

    [HttpPost("checkin")]
    public ActionResult<ParkingRecord> CheckIn(string licensePlate)
    {
        var record = new ParkingRecord
        {
            Id = Guid.NewGuid(),
            LicensePlate = licensePlate,
            CheckInTime = DateTime.Now
        };
        _parkingRecords.Add(record);
        return Ok(record);
    }

    [HttpPost("checkout/{id}")]
    public ActionResult<ParkingRecord> CheckOut(Guid id)
    {
        var record = _parkingRecords.Find(r => r.Id == id);
        if (record == null)
            return NotFound();

        record.CheckOutTime = DateTime.Now;
        record.Cost = CalculateCost(record.CheckInTime, record.CheckOutTime.Value);
        return Ok(record);
    }

    private decimal CalculateCost(DateTime checkIn, DateTime checkOut)
    {
        var duration = checkOut - checkIn;
        var hours = Math.Ceiling(duration.TotalHours);
        return (decimal)hours * 2.0m; // $2 per hour
    }
}

public class ParkingRecord
{
    public Guid Id { get; set; }
    public string LicensePlate { get; set; }
    public DateTime CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public decimal? Cost { get; set; }
}
