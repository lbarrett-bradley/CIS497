/*
 * Liam Barrett
 * SecurityCam.cs
 * Spring Assignment 2
 * Subject class that notifies observers when told to notify them
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCam : Subject
{
    public List<Observer> guards = new List<Observer>();

    public void registerObserver(Observer o)
    {
        guards.Add(o);
    }

    public void removeObserver(Observer o)
    {
        int i = guards.IndexOf(o);

        if (i >= 0)
        {
            guards.Remove(o);
        }
    }

    public void notifyObservers()
    {
        foreach (Observer o in guards)
        {
            o.update();
        }
    }
}
