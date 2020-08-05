using System;

namespace Json
{
    public class ResponseGetOperations
    {
        public Operation[] Operations { get; set; }
    }

    public class Operation
    {
        public string OperationId { get; set; }
        public string OperationType { get; set; }
        public string OperationStatus { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public int SubmittedCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public object[] FailedResources { get; set; }
        public object[] Common { get; set; }
        public object Specific { get; set; }
    }

    //public class Specific
    //{
    //}


}
