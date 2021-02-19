using System.Collections.Generic;

public class Describable{
    public string name, description;
}

public class Room : Describable{
    public List<Actable> actables;

    public Room(){
        actables = new List<Actable>();
    }

    public check(string s){
        foreach(Actable a in actables){
            a.check(s);
        }
    }
}