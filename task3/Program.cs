using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            TBus example = new TBus("ГАЗ", 11000, 45);
            example.changeInThePassengersNumber(33);
            example.toString();
            Console.WriteLine("Weight with passengers: " + example.getBusWeight());
        }
    }
    class TBus
    {
        private string busKind_;
        private float busWeight_;
        private int seatsNumber_;
        private int passengersNumber_;
        public string busKind
        {
            get { return busKind_; }
            set
            {
                if (value.GetType() == typeof(String)) busKind_ = value;
            }
        }
        public float busWeight
        {
            get { return busWeight_; }
            set
            {
                if (value.GetType() == typeof(float) && value > 0) busWeight_ = value;
            }
        }
        public int seatsNumber
        {
            get { return seatsNumber_; }
            set
            {
                if (value.GetType() == typeof(float) && value > 0) seatsNumber_ = value;
            }
        }
        public int passengersNumber
        {
            get { return passengersNumber_; }
        }
        public TBus()
        {
            this.busKind_ = "ПАЗ";
            this.busWeight_ = 12000;
            this.seatsNumber_ = 50;
            this.passengersNumber_ = 0;
        }
        public TBus(string busKind, float busWeight, int seatsNumber)
        {
            this.busKind_ = busKind;
            this.busWeight_ = busWeight;
            this.seatsNumber_ = seatsNumber;
            this.passengersNumber_ = 0;
        }
        public void changeInThePassengersNumber(int newPassengersNumber)
        {
            if (newPassengersNumber < this.seatsNumber_)
            {
                this.passengersNumber_ = newPassengersNumber;
            }
            else Console.WriteLine("The number of passengers must be less than the seats quantity!");
        }
        public float getBusWeight()
        {
            return this.busWeight_ + 60 * this.passengersNumber_;
        }
        public void toString()
        {
            Console.WriteLine("Kind of bus: " + this.busKind_);
            Console.WriteLine("Bus weight: " + this.busWeight_);
            Console.WriteLine("Seats quantity: " + this.seatsNumber_);
            Console.WriteLine("Passengers quantity: " + this.passengersNumber_);
        }
    }
}
