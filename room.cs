using System.Collections.Generic;

public class Describable{
    public List<string> name = new List<string>();
    public string description = "";

    public static bool operator ==(Describable d, string s){
        foreach(string n in d.name)
            if(s == n)
                return true;
        return false;
    }

    public static bool operator !=(Describable d, string s){ return true; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        return description == (obj as Describable).description;
    }
    
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class Room : Describable{
    public List<Actable> actables;

    public Room(){
        actables = new List<Actable>();
    }

    public void Add(Actable a){
        actables.Add(a);
    }

    public bool check(string[] s){
        foreach(Actable a in actables){
            if(a == s[1])
                if(a.check(s))
                    return true;
        }
        return false;
    }

    public string look(string s){
        foreach(Actable a in actables)
            if(a == s)
                return a.description;
        return "there is nothing to look at";
    }
}