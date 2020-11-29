using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Dictionary<ProcedureType, IProcedure> procedures;


        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<ProcedureType, IProcedure>();
            this.SeedProcedures();
        }

       

        public string Charge(string robotName, int procedureTime)
        {
            string outputMsg = this.DoService(robotName, procedureTime, ProcedureType.Charge, OutputMessages.ChargeProcedure);

            return outputMsg;
        }

        public string Chip(string robotName, int procedureTime)
        {         
            string outputMsg = this.DoService(robotName, procedureTime, ProcedureType.Chip, OutputMessages.ChipProcedure);

            return outputMsg;
        }

        public string History(string procedureType)
        {
            Enum.TryParse(procedureType, out ProcedureType procedureTypeEnum);

            IProcedure procedure = this.procedures[procedureTypeEnum];

            return procedure.History().Trim();

        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            if (!(robotType == nameof(HouseholdRobot) || robotType == nameof(PetRobot) || robotType == nameof(WalkerRobot)))
            {
                string msg = string.Format(ExceptionMessages.InvalidRobotType, robotType);

                throw new ArgumentException(msg);
            }

            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }

            this.garage.Manufacture(robot);

            string outputmsg = string.Format(OutputMessages.RobotManufactured, name);

            return outputmsg;

        }

        public string Polish(string robotName, int procedureTime)
        {
            string outputMsg = this.DoService(robotName, procedureTime, ProcedureType.Polish, OutputMessages.PolishProcedure);

            return outputMsg;
        }

        public string Rest(string robotName, int procedureTime)
        {

            string outputMsg = this.DoService(robotName, procedureTime, ProcedureType.Rest, OutputMessages.RestProcedure);

            return outputMsg;
        }

        public string Sell(string robotName, string ownerName)
        {
            IRobot robot = this.GetRobotByName(robotName);

            this.garage.Sell(robotName, ownerName);

            string res = string.Empty;

            if (robot.IsChipped)
            {
                res = string.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                res = string.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

            return res;

        }

        public string TechCheck(string robotName, int procedureTime)
        {          
            string outputMsg = this.DoService(robotName, procedureTime, ProcedureType.TechCheck, OutputMessages.TechCheckProcedure);

            return outputMsg;
        }

        public string Work(string robotName, int procedureTime)
        {
            IRobot robot = this.GetRobotByName(robotName);
            IProcedure procedure = this.procedures[ProcedureType.Work];
            procedure.DoService(robot, procedureTime);
            

            string outputMsg = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
            return outputMsg;
        }

        private void SeedProcedures()
        {
            this.procedures.Add(ProcedureType.Charge, new Charge());
            this.procedures.Add(ProcedureType.Chip, new Chip());
            this.procedures.Add(ProcedureType.Polish, new Polish());
            this.procedures.Add(ProcedureType.Rest, new Rest());
            this.procedures.Add(ProcedureType.TechCheck, new TechCheck());
            this.procedures.Add(ProcedureType.Work, new Work());
        }

        private IRobot GetRobotByName(string name)
        {
            if (!this.garage.Robots.ContainsKey(name))
            {
                string msg = string.Format(ExceptionMessages.InexistingRobot, name);

                throw new ArgumentException(msg);
            }

            return this.garage.Robots[name];
        }

        private string DoService(string robotName, int procedureTime, ProcedureType procedureType, string outputTemplate)
        {
            IRobot robot = this.GetRobotByName(robotName);
            IProcedure procedure = this.procedures[procedureType];
            procedure.DoService(robot, procedureTime);
            string outputMsg = string.Format(outputTemplate, robot.Name);
            return outputMsg;
        }
    }
}
