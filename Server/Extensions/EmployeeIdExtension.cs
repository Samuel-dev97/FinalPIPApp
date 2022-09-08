namespace Server.Extensions
{
    public class EmployeeIdExtension
    {
        public static string GetFormatEmployeeId(string Id)
        {
            var EmployeeId = "";
            if (Id.Length == 1)
            {
                EmployeeId = "00000" + Id;
            }
            else if (Id.Length == 2)
            {
                EmployeeId = "0000" + Id;
            }
            else if (Id.Length == 3)
            {
                EmployeeId = "000" + Id;
            }
            else if (Id.Length == 4)
            {
                EmployeeId = "00" + Id;
            }
            else if (Id.Length == 4)
            {
                EmployeeId = "0" + Id;
            }
            else
            {
                EmployeeId = Id;
            }

            return EmployeeId;
        }
    }
}
