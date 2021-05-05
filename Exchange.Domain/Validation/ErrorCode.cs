namespace Exchange.Domain.Validation
{
    public class ErrorCode
    {
        //Error Generic
        public static readonly string AWE000_UnexpectedError = "AWE000";
        public static readonly string AWE001_FieldIsEmpty = "AWE001";
        public static readonly string AWE002_ExceededLength = "AWE002";
        public static readonly string AWE003_ObjectIsNull = "AWE003";

        //Error Segment
        public static readonly string AWA001_SegmentDoesNotBelong = "AWS001";
    }
}
