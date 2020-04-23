using UnityEngine;
using System.Collections;
using System; //This allows the IComparable Interface

//This is the class you will be storing
//in the different collections. In order to use
//a collection's Sort() method, this class needs to
//implement the IComparable interface.
public class CubeSelector //: IComparable<CubeSelector>
{
    public int id;
    public int nLines;

    public CubeSelector(int newId, int nlines)
    {
        id = newId;
        nLines = nlines;
    }

    //This method is required by the IComparable
    //interface. 
    //public int CompareTo(BadGuy other)
    //{
    //    if(other == null)
    //    {
    //        return 1;
    //    }

    //    Return the difference in power.
    //    return power - other.power;
    //}
}