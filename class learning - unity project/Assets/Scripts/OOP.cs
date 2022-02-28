using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Monobehaviour can be attached to Unity game objects
public class OOP : MonoBehaviour
{
    private void Start()
    {
        Fish fish; // create an empty variable that stores fish data type
        //Instantiates fish and stores in variables
        fish = new Fish("carrot", 7);
        fish.PrintAnimal(); //call PrintAnimal method from fish

        red r = new red(70);
        r.Drive();

    }
}


//abstract classes can only be inherited from. not instantiated
public abstract class Animal
{
    //encapsulated data can only be changed from within the class
    private string name;
    private int age;
    
    public Animal(string _name, int _age) // class constructor
    {
        name = _name;
        age = _age;
    }

    //abstract method must be implemented in all dericed (child) classes
    public abstract void Eat();
    public abstract void Eat(string food);

    //virtual method may have implementation overriden
    public virtual void PrintAnimal()
    {
        Debug.Log("Name: " + name);
        Debug.Log("Age: " + age);   
    }
}

public class Fish : Animal //fish class inheriets the animal class
{
    //fish constrcutor
    //passes parameters to base class constructor
    public Fish(string _name, int _age) : base(_name, _age)
    {
    
    }
    
    //Override ver of Animal's Eat method
    public override void Eat()
    {
        Debug.Log("fish eat");
    }
    public override void Eat(string food)
    {
        Debug.Log("Fish has eaten" + food); 
    }

    //extended ver of Animal's PrintAnimal methods
    public override void PrintAnimal()
    {
        base.PrintAnimal();
    }
}

public abstract class Vehicle
{
    private int speed;

    public Vehicle(int _speed)
    {
        speed = _speed;
    }

    public virtual void Drive()
    {
        Debug.Log("Driving at" + speed + "KPM");
    }


}

public class red : Vehicle
{
    public red(int _speed) : base(_speed)
    {

    }

    public override void Drive()
    {
        Debug.Log("red has gone");
    }


}