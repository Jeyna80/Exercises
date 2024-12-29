using Microsoft.AspNetCore.Mvc;

public class ParkingTransaction
{
    public string LicensePlate { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Cost { get; set; }
}
var cost = CalculateCost(request.StartTime, request.EndTime);
var transaction = new ParkingTransaction
{
    LicensePlate = request.LicensePlate,
    StartTime = request.StartTime,
    EndTime = request.EndTime,
    Cost = cost
};

SaveTransaction(transaction);

return Ok(new { Cost = cost });

var transactions = ReadTransactions();
return Ok(transactions);