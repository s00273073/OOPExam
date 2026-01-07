using System.Collections.Generic;
using System.Linq;

namespace OOP
{
    public class HouseholdRobot : Robot
    {
        private readonly List<HouseholdSkill> Skills = new();

        public HouseholdRobot(string name, double powerCapacityKwh, double currentPowerKwh, IEnumerable<HouseholdSkill>? initialSkills = null)
        {
            RobotName = name;
            PowerCapacityKWH = powerCapacityKwh;
            CurrentPowerKWH = currentPowerKwh;
            if (initialSkills != null)
            {
                Skills.AddRange(initialSkills);
            }

            // Ensure every household robot has Cleaning using the DownloadSkill method as requested.
            DownloadSkill(HouseholdSkill.Cleaning);
        }

        public void AddSkill(HouseholdSkill skill)
        {
            if (!Skills.Contains(skill))
            {
                Skills.Add(skill);
            }
        }

        public IReadOnlyList<HouseholdSkill> GetSkills() => Skills.AsReadOnly();

        // Implement DownloadSkill for household robots by delegating to AddSkill
        public override void DownloadSkill(HouseholdSkill skill) => AddSkill(skill);

        public override string DescribeRobot()
        {
            var skillsText = Skills.Any() ? string.Join(", ", Skills) : "None";
            return $"Household robot '{RobotName}'. Skills: {skillsText}. {DisplayBatteryInformation()}";
        }
    }
}