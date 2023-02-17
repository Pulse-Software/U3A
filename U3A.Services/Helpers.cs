namespace U3A.Services
{
    public static class Helpers
    {
        static string ErrorMessage = string.Empty;

        public static string GetErrorMessage(Exception ex)
        {
            ErrorMessage = ex.Message; 
            if (ex.InnerException != null) GetErrorMessage(ex.InnerException);
            return ErrorMessage;
        }

    }
}
