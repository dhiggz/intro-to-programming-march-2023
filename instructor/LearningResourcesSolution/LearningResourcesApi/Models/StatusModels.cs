namespace LearningResourcesApi.Models;

/*
 {
    "status": "Normal",
    "lastOutage": "185 Days Ago",
    "upcomingScheduledOutages: [],
    "forHelp": {
        "contact": "Bob Smith",
        "contactInfo": {
            "email": "Bob@aol.com",
            "phone": "555-1212"

        }
    }
  }
*/

// Status is always "Normal", "Degraded", "OnFire"
public enum StatusLevel { Normal, Degraded, OnFire }
public record StatusResponse(StatusLevel status, DateTime lastOutage, List<DateTime> upcomingOutages, StatusHelpInfo ForHelp);

public record StatusHelpInfo (string Contact, Dictionary<string,string> contactInfo);
