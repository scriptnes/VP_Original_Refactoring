namespace VP_Refactoring1
{
    public interface IVehicle   
    {
        string LicensePlate
        {
            get;
        }

        string Owner
        {
            get;
        }

        decimal RegularRate
        {
            get;
        }

        decimal OvertimeRate
        {
            get;
        }

        int ReservedHours
        {
            get;
        }
    }
}
