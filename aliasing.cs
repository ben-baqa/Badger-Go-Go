using System.Collections.Generic;

public class Alias{
    public static List<List<string>> set;

    public Alias(){
        set = new List<List<string>>();
        set.Add(new List<string>());
        set[0].Add("look");
        set[0].Add("inspect");

        set.Add(new List<string>());
        set[1].Add("eat");
        set[1].Add("consume");
        set[1].Add("drink");
        set[1].Add("devour");
        set[1].Add("imbibe");

        set.Add(new List<string>());
        set[2].Add("go");
        set[2].Add("move");
        set[2].Add("leave");
        set[2].Add("travel");
        set[2].Add("walk");

        set.Add(new List<string>());
        set[3].Add("no");
        set[3].Add("exit");
        set[3].Add("close");
        set[3].Add("fuck");
    }

    public static string reduce(string s){
        foreach(List<string> ls in set){
            if(ls.Contains(s))
                return ls[0];
        }
        return "";
    }
}