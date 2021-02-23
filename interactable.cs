using System.Collections.Generic;
using System;
using IOStream;
public class Actable : Describable{
    private List<Act> actions;

    public Actable(string n){
        name.Add(n);
        actions = new List<Act>();
    }

    public void AddAction(Act action){
        actions.Add(action);
    }

    public bool check(string[] s){
        foreach(Act a in actions){
            if(a.check(Alias.reduce(s[0])))
                return true;
        }
        return false;
    }
}

public class Act{
    protected string prompt, output;
    protected bool basic = true;
    protected Room room;
    protected Actable addOnTrigger;

    public Act(string i, string o, Room r, Actable a){
        prompt = i;
        output = o;
        room = r;
        addOnTrigger = a;
        basic = false;
    }

    public Act(string i, string o){
        prompt = i;
        output = o;
    }

    public Act(){}

    public virtual bool check(string input){
        if(input != prompt)
            return false;
        Console.WriteLine(output);
        if(!basic)
            room.actables.Add(addOnTrigger);
        return true;
    }
}

public class Eat: Act{
    public Eat(string o, Room r, Actable a){ output = o; room = r; addOnTrigger = a; basic = false; }

    public Eat(string o){ output = o; }

    public override bool check(string input){
        if(input != "eat")
            return false;

        OutStream o = new OutStream();
        o += output;
        o.WriteBuffer();

        if(!basic)
            room.actables.Add(addOnTrigger);
        return true;
    }
}

public class Move: Act{
    private Game game;

    public Move(string o, Game g, Room r){ output = o; game = g; room = r; }

    public Move(){}

    public override bool check(string input){
        if(input != "go")
            return false;
        
        OutStream o = new OutStream();
        o += output;
        o.WriteBuffer();

        game.room = room;
        return true;
    }
}

public class LastMove: Move{

    public LastMove(string o){ output = o; }

    public override bool check(string input){
        if(input != "go")
            return false;
        
        OutStream o = new OutStream();
        o += output;
        o.WriteBuffer();

        Environment.Exit(0);
        return true;
    }
}