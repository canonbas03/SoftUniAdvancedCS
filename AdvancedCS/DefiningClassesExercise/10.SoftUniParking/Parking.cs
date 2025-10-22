using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public List<Car> Cars
        {

            get { return this.cars; }
            private set { this.cars = value; }
        }
        public int Count
        {
            get { return this.Cars.Count; }
        }

        public Parking(int size)
        {
            this.capacity = size;
            Cars = new List<Car>();
        }

        public string AddCar(Car car)
        {
            if (Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (Cars.Count >= capacity)
            {
                return "Parking is full!";
            }
           
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            if (car != null)
            {
                this.Cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            this.Cars.RemoveAll(c => registrationNumbers.Contains(c.RegistrationNumber));
        }
    }
}
