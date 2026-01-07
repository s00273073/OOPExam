using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    public class DeliveryRobot : Robot
    {
        // Delivery robots can also store downloaded household skills.
        private readonly List<HouseholdSkill> Skills = new();

        public DeliveryMode ModeOfDelivery { get; set; }
        public double MaxLoadKG { get; set; }

        public DeliveryRobot(string name, DeliveryMode modeOfDelivery, double maxLoadKg, double powerCapacityKwh, double currentPowerKwh)
        {
            RobotName = name;
            ModeOfDelivery = modeOfDelivery;
            MaxLoadKG = maxLoadKg;
            PowerCapacityKWH = powerCapacityKwh;
            CurrentPowerKWH = currentPowerKwh;
        }

        // Download a skill into this delivery robot
        public override void DownloadSkill(HouseholdSkill skill)
        {
            if (!Skills.Contains(skill))
            {
                Skills.Add(skill);
            }
        }

        public IReadOnlyList<HouseholdSkill> GetDownloadedSkills() => Skills.AsReadOnly();

        public override string DescribeRobot()
        {
            var skillsText = Skills.Any() ? $" Skills downloaded: {string.Join(", ", Skills)}." : string.Empty;
            return $"Delivery robot '{RobotName}' - Mode: {ModeOfDelivery}, Max load: {MaxLoadKG:F1} kg.{skillsText} {DisplayBatteryInformation()}";
        }
    }
}