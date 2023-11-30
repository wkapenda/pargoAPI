using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using server_track_trace.Models;

namespace server_track_trace.Controllers
{
    [ApiController]
    [Route("api/package")]
    public class PackageController : ControllerBase
    {
        private readonly ILogger<PackageController> _logger;

        public PackageController(ILogger<PackageController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static readonly List<PackageHistory> DummyPackageHistories = new List<PackageHistory>
{
    // Existing dummy data

    // Inserting solution for PGO1234567
    new PackageHistory("PGO1234567", "In transit", DateTime.Now.AddDays(-3), "Cnr Kock: Von Wielligh St, Rustenburg, Rustenburg"),
    new PackageHistory("PGO1234567", "Arrived at facility", DateTime.Now.AddDays(-2), "KwaMthembu Complex Office no1, R61 Port St Johns Road, NTLAZA, NTLAZA"),
    new PackageHistory("PGO1234567", "Out for delivery", DateTime.Now.AddDays(-1), "CNR Umphafa Road & Aganang Street, 1st Avenue Hair & Beauty, Soshanguve Ext 4, Soshanguve"),
    new PackageHistory("PGO1234567", "Delivered", DateTime.Now, "130 , 14TH Avenue, Rooth St, same street as the police station, Alexandra, Johannesburg"),

    // Inserting solution for PGO8901234
    new PackageHistory("PGO8901234", "In transit", DateTime.Now.AddDays(-5), "Shop L48 Cape Gate Shopping Centre, Cnr Okavango and De Bron Road, Brackenfell, Brackenfell"),
    new PackageHistory("PGO8901234", "Arrived at facility", DateTime.Now.AddDays(-2), "Shop 40 Fairtrees Road, Vredekloof, Brackenfell"),
    new PackageHistory("PGO8901234", "Out for delivery", DateTime.Now.AddDays(-1), "Shop L11B, Glenvista Shopping Centre, Biggarsberg Road, Glenvista, Johannesburg"),

    // Inserting solution for PGO5678901
    new PackageHistory("PGO5678901", "In transit", DateTime.Now.AddDays(-3), "Shop 6B Northlands Corner Shopping Mall, Corner Witkoppen and New Market Roads, Northriding, Johannesburg"),
    new PackageHistory("PGO5678901", "Arrived at facility", DateTime.Now.AddDays(-2), "Shop 107 Randridge Mall, Cnr John Vorster & Kayburne Avenue, Randburg, Randburg"),

    // Existing dummy data
};


        [HttpGet]
        public ActionResult<IEnumerable<PackageResponse>> GetPackageHistory([FromQuery] string waybillNumber)
        {
            try
            {
                if (string.IsNullOrEmpty(waybillNumber))
                {
                    return BadRequest("Waybill number is required.");
                }

                var matchingHistory = DummyPackageHistories
                    .FindAll(history => string.Equals(history.Waybill, waybillNumber, StringComparison.OrdinalIgnoreCase))
                    .Select(history => new PackageResponse
                    {
                        Status = history.Status,
                        Date = history.Date,
                        Location = history.Location
                    })
                    .ToList();

                return Ok(matchingHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
