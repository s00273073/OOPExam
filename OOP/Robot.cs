namespace OOP
{
    /// <summary>
    /// Abstract base class for robots.
    /// </summary>
    public abstract class Robot
    {
        /// <summary>
        /// The robot's name.
        /// </summary>
        public string RobotName { get; set; } = string.Empty;

        /// <summary>
        /// Power capacity in kilowatt-hours.
        /// </summary>
        public double PowerCapacityKWH { get; set; }

        /// <summary>
        /// Current stored power in kilowatt-hours.
        /// </summary>
        public double CurrentPowerKWH { get; set; }

        /// <summary>
        /// Returns remaining power as a percentage (0-100). Returns 0 if capacity is zero or negative.
        /// </summary>
        public double GetBatteryPercentage()
        {
            if (PowerCapacityKWH <= 0.0)
            {
                return 0.0;
            }

            double percent = (CurrentPowerKWH / PowerCapacityKWH) * 100.0;
            return System.Math.Clamp(percent, 0.0, 100.0);
        }

        /// <summary>
        /// Returns a formatted string suitable for display, e.g.:
        /// "Battery: 3.20 / 5.00 kWh (64%)"
        /// </summary>
        public string DisplayBatteryInformation()
        {
            return string.Format("Battery: {0:F2} / {1:F2} kWh ({2:F0}%)",
                                 CurrentPowerKWH,
                                 PowerCapacityKWH,
                                 GetBatteryPercentage());
        }

        /// <summary>
        /// Subclasses implement to return descriptive text about the robot.
        /// </summary>
        public abstract string DescribeRobot();

        /// <summary>
        /// Downloads a household skill into the robot (implemented by derived types that support skills).
        /// </summary>
        public abstract void DownloadSkill(HouseholdSkill skill);

        /// <summary>
        /// Returns the robot name and runtime type, e.g. "Robo1 (WorkerRobot)".
        /// </summary>
        public override string ToString() =>
            $"{RobotName} ({GetType().Name})";
    }
}