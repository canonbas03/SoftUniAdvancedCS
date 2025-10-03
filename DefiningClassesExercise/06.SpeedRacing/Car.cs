using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpeedRacing
{
    internal class Car
    {
		private string model;
		private double fuelAmount;
		private double fuelConsumption;
		private double traveledDistance;

		public double TraveledDistance
		{
			get { return traveledDistance; }
			set { traveledDistance = value; }
		}


		public double FuelConsumption
		{
			get { return fuelConsumption; }
			set { fuelConsumption = value; }
		}


		public double FuelAmount
		{
			get { return fuelAmount; }
			set { fuelAmount = value; }
		}


		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public bool Drive(int distance)
		{
			double requiredFuel = this.FuelConsumption * distance;
			if(this.FuelAmount >= requiredFuel)
			{
				this.FuelAmount -= requiredFuel;
				this.TraveledDistance += distance;
				return true;
			}
			
			return false;
		}
	}
}
