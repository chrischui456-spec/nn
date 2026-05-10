using System;
using System.Collections.Generic;
using Applications.Weshare.Swagger.Model;
using Gauge.CSharp.Lib;

namespace Applications.Weshare.Steps
{
    public static class StepsHelper
    {
        public static string BasePath => "http://localhost:5050";
        public static int LastCreatedExpenseId { get; set; }
        public static int LastCreatedPaymentRequestId { get; set; }
        
        // Multi-user context tracking
        public static Dictionary<string, Person> CapturedUsers { get; set; } = new Dictionary<string, Person>();
        public static Person CurrentLoggedInUser { get; set; }
        public static int CurrentLoggedInPersonId { get; set; }
        public static int LastToPersonId { get; set; }
        
        // Store payment requests by toPersonId (beneficiary)
        public static Dictionary<int, int> PaymentRequestsByToPersonId { get; set; } = new Dictionary<int, int>();
        
        // Email to PersonId mapping
        public static Dictionary<string, int> EmailToPersonIdMap { get; set; } = new Dictionary<string, int>()
        {
            { "student1@wethinkcode.co.za", 1 },
            { "student2@wethinkcode.co.za", 2 },
            { "student3@wethinkcode.co.za", 3 }
        };
        
        public static int GetPersonIdForEmail(string email)
        {
            if (EmailToPersonIdMap.ContainsKey(email))
            {
                return EmailToPersonIdMap[email];
            }
            // For new users, return a default ID or throw exception
            return 0;
        }
    }
}
