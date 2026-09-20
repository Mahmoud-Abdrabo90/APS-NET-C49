using System;

namespace Assignment 02 oop
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

