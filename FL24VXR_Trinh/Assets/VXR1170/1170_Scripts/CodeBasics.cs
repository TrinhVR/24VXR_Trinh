using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeBasics : MonoBehaviour
{
    // Understanding VARIABLES
    // int = integer, default = 0 
    // float = integer plus decimal values, double, decimal, default = 0.0f
    // string = characters/words "", default value = null
    // bool = false/true, default = false



    // Understanding OPERATORS

    // Arithmetic Operators
    // Addition (+)
    // Subtraction (-)
    // Multiplication (*)
    // Division (/)
    // Modulus (%) - Returns the remainder of division value

    // Assignment Operators 
    // = assignment
    private int level = 1;

    // += addition assignment
    private int coins = 10;
    
    // -= subtraction assignment

    // Comparison Operators 

    // Equal to (==)
    // Not equal to (!=)
    // Greater than (>)
    // Less than (<)
    // Greater than or equal to (>=)
    // Less than or equal to (<=)


    // Logical Operators 
    // AND &&
    // OR ||
    // NOT !

    // Increment / Decrement Operators 
    // Increment (++)
    // Decrement (--)

    // Dot operator (.)




    // Start is called before the first frame update
    void Start()
    {
        int health;

        level++;
    }

    // Update is called once per frame
    void Update()
    {
        coins += 5; // Adds 5 more coins to my already assigned coins = 10, so coins = 15
    }
}
