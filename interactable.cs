using System.Collections.Generic;
using System;
using IOStream;
public class Actable : Describable{
    private List<Act> actions;

    public Actable(string n){
        name = n;
        actions = new List<Act>();
    }

    public void AddAction(Act action){
        actions.Add(action);
    }
}

public class Act{
    private string prompt, output;
    private System.Action onTrigger;

    public Act(string i, string o, System.Action t = null){
        prompt = i;
        output = o;
        onTrigger = t;
    }

    public bool check(string input){
        if(input != prompt)
            return false;
        Console.WriteLine(output);
        if(onTrigger != null)
            onTrigger();
        return true;
    }
}