using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ForeachView : MonoBehaviour
{
    private void Start()
    {
        Person[] persons =
        {
            new Person{FirstName = "LL", LastName = "JJ"},
            new Person{FirstName = "TT", LastName = "UU"}
        };

        foreach (Person person in persons)
        {
            Debug.Log(person);
        }

        Debug.Log("----------------------------------------------");

        IEnumerator enumerator = persons.GetEnumerator();

        while (enumerator.MoveNext())
        {
            Person p = enumerator.Current as Person;
            Debug.Log(p);
        }
    }
}

public class Person : IComparable
{
    public string FirstName;
    public string LastName;

    public override string ToString()
    {
        return string.Format("FirstName: {0}, LastName: {1}", FirstName, LastName);
    }
}