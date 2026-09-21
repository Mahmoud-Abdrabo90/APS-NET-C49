using System;

namespace Assignment_02_oop
{
    // =====================================================================
    //  C# OOP Assignment
    //  OOP 02 – Smart Delivery Management System
    // =====================================================================

    #region  part01 Theroetical Questions 1

    // ---------------------------------------------------------------------
    // Question 1
    // Answer the following questions:
    //
    // a) What is the difference between a class and a struct?

    //
    // Difference between a class and a struct

    //        class : REFERENCE type. The variable holds a reference to an
    //                  object that lives on the heap.
    //        struct: VALUE type. The variable holds the data itself (on the
    //                  stack, or inline inside the object that contains it).


    //
    // b) Why classes are more suitable for large applications

    //    * Inheritance and polymorphism: classes let us build hierarchies
    //       and reuse code, which structs cannot do.

    //    * Reference semantics: large objects are passed around by reference, so
    //      there is no expensive copying; every part of the program works on the
    //      same shared object and sees the same state.

    //    * Identity and lifetime: objects can be shared, stored in collections,
    //      set to null when they do not exist, and live as long as they are used.

    //    * Better for complex objects: a class handles many fields, validation
    //      and behavior well, while big structs become slow because every
    //      assignment copies all their data.

    //    * Maintainability and extensibility: with abstraction, encapsulation and
    //      inheritance, new features are added with minimal changes to existing code.

    #endregion

    #region Part 01 : Theoretical Questions - Question 2

    // ---------------------------------------------------------------------
    // Question 2

    // a) Which class is the parent class?

    // The parent (base) class is  Shipment.

    // b) Which class is the child class?

    // The child (derived) class is  ExpressShipment

    // c) What members are inherited by ExpressShipment?

    //   ExpressShipment inherits the accessible members of Shipment, which here is
    //    the public property  TrackingCode.
    //     So an ExpressShipment object has TrackingCode (inherited) and its own
    //      ExtraFee.
    //     It also inherits the members of System.Object through Shipment
    //      (ToString, Equals, GetHashCode, GetType).
    //     Constructors are NOT inherited, and private members are not accessible from the child class.


    // d) Why is inheritance better than duplicating the same code in multiple classes?

    //Inheritance is better than duplicating code because:
    //      Code reuse: common members are written once in the parent class.
    //      child classes automatically, instead of editing many copies
    //      Polymorphism: a Shipment variable can hold any child object and call
    //      overridden members (like EstimatedCost) - one code path for all types

    #endregion

    #region Part 02 : Practical -  Shipment Class

    public struct DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuildingNumber;

        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
        }


        public string GetFullAddress()
        {
            return BuildingNumber + " " + Street + ", " + City;
        }
    }
    public class Shipment
    {
        private string _trackingCode = "Unknown";
        private string _description = "Unknown";
        private decimal _weight = 1;
        private decimal _deliveryFee = 50;

        public string TrackingCode
        {
            get { return _trackingCode; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _trackingCode = value;
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _description = value;
            }
        }

        public decimal Weight
        {
            get { return _weight; }
            set
            {
                if (value > 0)
                    _weight = value;
            }
        }

        public decimal DeliveryFee
        {
            get { return _deliveryFee; }
            private set
            {
                if (value > 0)
                    _deliveryFee = value;
            }
        }

        public DeliveryAddress Destination { get; set; }

        public virtual decimal EstimatedCost
        {
            get { return DeliveryFee + Weight * 5; }
        }

        public Shipment(string trackingCode, string description, decimal weight,
                        decimal deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
        }

        public virtual void PrintShipment()
        {
            Console.WriteLine("Shipment");
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Description   : " + Description);
            Console.WriteLine("Weight        : " + Weight + " KG");
            Console.WriteLine("Delivery Fee  : " + DeliveryFee + " EGP");
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        }
    }
    //public class StandardShipment : Shipment
    //{
    //    public StandardShipment(string code, string description, decimal weight,
    //                            decimal fee, DeliveryAddress address)
    //        : base(code, description, weight, fee, address)
    //    {
    //    }
    //}

    #endregion
    #region Part 02 : Practical - 2. Create Three Shipment Types

    // ---------------------------------------------------------------------
   

    #region StandardShipment

    public class StandardShipment : Shipment
    {
        
        public StandardShipment(string trackingCode, string description, decimal weight,
                                decimal deliveryFee, DeliveryAddress destination)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Standard Shipment");
            Console.WriteLine();
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Description   : " + Description);
            Console.WriteLine("Weight        : " + Weight + " KG");
            Console.WriteLine("Delivery Fee  : " + DeliveryFee + " EGP");
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        }
    }

    #endregion

    #region ExpressShipment

    public class ExpressShipment : Shipment
    {
        private decimal _extraFee = 0;

        public decimal ExtraFee
        {
            get { return _extraFee; }
            set
            {
                if (value >= 0)
                    _extraFee = value;
            }
        }

     
        public override decimal EstimatedCost
        {
            get { return DeliveryFee + Weight * 5 + ExtraFee; }
        }

        public ExpressShipment(string trackingCode, string description, decimal weight,
                               decimal deliveryFee, DeliveryAddress destination, decimal extraFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extraFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");
            Console.WriteLine();
            Console.WriteLine("Tracking Code : " + TrackingCode);
            Console.WriteLine("Description   : " + Description);
            Console.WriteLine("Weight        : " + Weight + " KG");
            Console.WriteLine("Delivery Fee  : " + DeliveryFee + " EGP");
            Console.WriteLine("Extra Fee     : " + ExtraFee + " EGP");
            Console.WriteLine("Estimated Cost: " + EstimatedCost + " EGP");
        }
    }

    #endregion

     #region InternationalShipment

    public class InternationalShipment : Shipment
    {
        private string _destinationCountry = "Unknown";
        private decimal _customsFee = 0;

        public string DestinationCountry
        {
            get { return _destinationCountry; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _destinationCountry = value;
            }
        }

        public decimal CustomsFee
        {
            get { return _customsFee; }
            set
            {
                if (value >= 0)
                    _customsFee = value;
            }
        }

        public override decimal EstimatedCost
        {
            get { return DeliveryFee + Weight * 5 + CustomsFee; }
        }

        public InternationalShipment(string trackingCode, string description, decimal weight,
                                     decimal deliveryFee, DeliveryAddress destination,
                                     string destinationCountry, decimal customsFee)
            : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }

        public override void PrintShipment()
        {
            Console.WriteLine("International Shipment");
            Console.WriteLine();
            Console.WriteLine("Tracking Code       : " + TrackingCode);
            Console.WriteLine("Description         : " + Description);
            Console.WriteLine("Weight              : " + Weight + " KG");
            Console.WriteLine("Delivery Fee        : " + DeliveryFee + " EGP");
            Console.WriteLine("Destination Country : " + DestinationCountry);
            Console.WriteLine("Customs Fee         : " + CustomsFee + " EGP");
            Console.WriteLine("Estimated Cost      : " + EstimatedCost + " EGP");
        }
    }

    #endregion

    #region Part 02 : Practical - 3. DeliveryCenter Class

    // ---------------------------------------------------------------------
    // 3. DeliveryCenter Class
    //
    // Extend your DeliveryCenter class. The class should contain:
    //     CenterName : string
    //     Shipments  : Shipment[]
    //
    // Requirements:
    //     - The center can store up to 20 shipments.
    //     - The Shipment array must be private.
    //     - Keep the indexers from Assignment 01.
    //     - Keep the AddShipment() method from Assignment 01.
    //
    // Add the following methods:
    //
    // RemoveShipment
    //     Searches for a shipment using its tracking code.
    //     If found:  remove the shipment and return true.
    //     Otherwise: return false.
    //
    // PrintAllShipments
    //     void PrintAllShipments()
    //     Print all stored shipments.
    // ---------------------------------------------------------------------

    public class DeliveryCenter
    {
        private const int MaxShipments = 20;

        // The array is private. "Shipment?" means the slot may be null (empty).
        private readonly Shipment?[] _shipments = new Shipment?[MaxShipments];

        private string _centerName = "Unnamed Center";

        public string CenterName
        {
            get { return _centerName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    _centerName = value;
            }
        }

        // Indexer 1: get / set a shipment by its position.  Example: center[0]
        public Shipment? this[int index]
        {
            get
            {
                if (index < 0 || index >= MaxShipments)
                    return null;         // invalid index

                return _shipments[index];
            }
            set
            {
                if (index >= 0 && index < MaxShipments)
                    _shipments[index] = value;
            }
        }

        // Indexer 2: find a shipment by its tracking code.  Example: center["SH001"]
        public Shipment? this[string trackingCode]
        {
            get
            {
                int position = FindPosition(trackingCode);

                if (position == -1)
                    return null;         // not found

                return _shipments[position];
            }
        }

        // Returns the position of the shipment with this tracking code, or -1 if not found.
        private int FindPosition(string trackingCode)
        {
            for (int i = 0; i < MaxShipments; i++)
            {
                Shipment? shipment = _shipments[i];

                if (shipment != null && shipment.TrackingCode.ToLower() == trackingCode.ToLower())
                    return i;
            }

            return -1;
        }

        // Adds the shipment in the first empty position.
        // Returns true if added, false if the center is full.
        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < MaxShipments; i++)
            {
                if (_shipments[i] == null)
                {
                    _shipments[i] = shipment;
                    return true;
                }
            }

            return false;
        }

        // Searches by tracking code. If found: removes it and returns true.
        public bool RemoveShipment(string trackingCode)
        {
            int position = FindPosition(trackingCode);

            if (position == -1)
                return false;

            _shipments[position] = null;   // the position becomes empty
            return true;
        }

        public void PrintAllShipments()
        {
            bool isFirst = true;

            for (int i = 0; i < MaxShipments; i++)
            {
                Shipment? shipment = _shipments[i];

                if (shipment != null)
                {
                    // A line between the shipments
                    if (!isFirst)
                    {
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine();
                    }

                    shipment.PrintShipment();
                    isFirst = false;
                }
            }

            if (isFirst)
                Console.WriteLine("No shipments stored.");
        }
    }

    #endregion

    class Program
    {
        static void Main()
        {
            DeliveryCenter center = new DeliveryCenter();
            center.CenterName = "Cairo center";

            DeliveryAddress address = new DeliveryAddress("Cairo", "Tahrir", 15);
            StandardShipment standard = new StandardShipment("S001", "Electronics", 10, 50, address);
            ExpressShipment express = new ExpressShipment("S002", "Phone", 2, 80, address, 30);
            InternationalShipment international = new InternationalShipment("S003", "cairo", 15, 120, address, "Egypt", 200);

            center.AddShipment(standard);
            center.AddShipment(express);
            center.AddShipment(international);

            center.PrintAllShipments();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    #endregion
}