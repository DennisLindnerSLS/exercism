public class RemoteControlCar
{
    public class Telemetry_
    {
        private RemoteControlCar _remoteCar;

        private Telemetry_() {}
        internal Telemetry_(RemoteControlCar remoteControlCar)
        {
            _remoteCar = remoteControlCar;
        }
        public void Calibrate()
        {

        }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string expected)
        {
            _remoteCar.CurrentSponsor = expected;
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            _remoteCar.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    internal enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    internal struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }

    public string CurrentSponsor { get; private set; }
    private Speed currentSpeed;

    public Telemetry_ Telemetry { get; }

    public RemoteControlCar()
    {
        Telemetry = new Telemetry_(this);
        currentSpeed = new();
        CurrentSponsor = "";
    }

    public string GetSpeed()
    {
        return currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;

    }

    private void SetSpeed(Speed speed)
    {
        currentSpeed = speed;
    }
}


