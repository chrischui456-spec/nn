using System;
using Applications.Weshare.Swagger.Model;
using Gauge.CSharp.Lib;

namespace Applications.Weshare.Steps
{
    public static class StepsHelper
    {
        public static string BasePath => "http://localhost:5050";
        public static int LastCreatedExpenseId { get; set; }
        public static int LastCreatedPaymentRequestId { get; set; }
    }
}
