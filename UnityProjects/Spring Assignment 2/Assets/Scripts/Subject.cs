/*
 * Liam Barrett
 * Subject.cs
 * Spring Assignment 2
 * Subject interface for classes that update observers in the observer pattern
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subject
{
    void registerObserver(Observer o);

    void removeObserver(Observer o);

    void notifyObservers();
}
