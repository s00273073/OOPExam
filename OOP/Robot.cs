namespace OOP
{
    /// <summary>
    /// Abstract base class for robots.
    /// </summary>
    public abstract class Robot
    {

        /// The robot's name.

        public string RobotName { get; set; } = string.Empty;


        /// Power capacity in kilowatt-hours.
  
        public double PowerCapacityKWH { get; set; }


        /// Current stored power in kilowatt-hours.
  
        public double CurrentPowerKWH { get; set; }


        public double GetBatteryPercentage()
        {
            if (PowerCapacityKWH <= 0.0)
            {
                return 0.0;
            }

            double percent = (CurrentPowerKWH / PowerCapacityKWH) * 100.0;
            return System.Math.Clamp(percent, 0.0, 100.0);
        }


        public string DisplayBatteryInformation()
        {
            return string.Format("Battery: {0:F2} / {1:F2} kWh ({2:F0}%)",
                                 CurrentPowerKWH,
                                 PowerCapacityKWH,
                                 GetBatteryPercentage());
        }


        public abstract string DescribeRobot();


        public abstract void DownloadSkill(HouseholdSkill skill);

        public override string ToString() =>
            $"{RobotName} ({GetType().Name})";
    }
}