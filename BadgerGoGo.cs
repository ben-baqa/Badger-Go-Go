using System.Collections.Generic;
using IOStream;
using System;

public class Game{
    static int Main(){
        Game game = new Game();
        Alias a = new Alias();
        game.RealMain();

        System.Console.WriteLine("--------CLOSING GAME------");
        System.Console.Read();
        return 0;
    }

    private List<Room> rooms;
    public Room room;
    OutStream o;
    InStream i;

    public Game(){
        rooms = new List<Room>();
        room = new Room();
        o = new OutStream();
        i = new InStream();
    }

    public int RealMain(){
        //startup code
        string input = "";
        string[] splitI;
        setup();

        //main loop
        while(true){
            input = +i;
            input = input.ToLower();

            if(Alias.reduce(input) == "no")
                break;

            splitI = input.Split(' ');

            if(input == "help"){
                o += "\nUse [look] or [inspect] to look at objects or the room," +
                "\nUse [exit] to close the game" +
                "\nIt is possible to consume things";
                continue;
            }

            if(splitI.Length > 0 && Alias.reduce(splitI[0]) == "look"){
                if(splitI.Length == 1 || splitI[1] == "around")
                    o += room.description;
                else
                    o += room.look(splitI[1]);
            }
            else if(splitI.Length == 2 && room.check(splitI))
                o += "";
            else
                o += "\nInvalid Input, use [help] to get help";
        }
        return 0;
    }

    private void setup(){
        o += 
        "\nYou lay destitude in a grungy cell," +
        "\nImprisoned by a pack of hariless apes" +
        "\nTheir putrid stench coats the air of this humiliating prison" +
        "\nOnce a king amongst badgers, you were caught off guard by these ingrates" +
        "\nYou thirst for vangence";

    //room definitions
        Room r = new Room();
        r.description =
        "\nSome terrifying illness seems to have convinced these hindwalkers that they could contain you"+
        "\nTo their credit, three of the walls surrounding you are formed of rock" +
        "\nThe remaining wall, to the east, is a rusty wire fence" +
        "\nYour captors have left you with a small bowl of water";
        rooms.Add(r);
        room = r;

        r = new Room();
        r.description = "\nYou stand atop a stone path running north to south" +
        "\nto the south lie more cages, the north holds a building and noises of man" +
        "\nAlong the path are several thistles";
        rooms.Add(r);

        r = new Room();
        r.description =
        "\nThe path has continued south" +
        "\nJust off the path lies a small cage holding minks" +
        "\nTo the south is a yard, where you can make out the forms of several large blue green birds";
        rooms.Add(r);

        r = new Room();
        r.description =
        "\nYou stand in a small open field, walled on all sides but the north from which you came" +
        "\nThere are several peacocks";
        rooms.Add(r);

        r = new Room();
        r.description =
        "\nYou are sitting in a human structure";
        rooms.Add(r);

        r = new Room();
        r.description =
        "\nA massive Gate lies before you to the north" +
        "\n the only remaining obstacle between you and succulent freedom";
        rooms.Add(r);


    //starting cage [0]
        Actable a = new Actable("bowl");
        a.description = 
        "\nThe small metal bowl holds a measly amount of old water," +
        "\nIts presence is an insult";
        a.AddAction(new Eat("\nYou scronch down the poor bowl" +
        "\nCold metal nuroushing your ample frame" +
        "\nThe water, once held, now dampens the muddy ground" +
        "\nThis was lethargic"));
        rooms[0].actables.Add(a);

        Actable go = new Actable("east");
        go.description = "Beyond the demolished fence is a stone path running north-south";
        go.AddAction(new Move("\nYou slither onwards like death in the night, despite the high noon sun" +
        "\nYour proud white stripe threatening to expose your position to the no one around to see it" +
        "\nYou have arrived on the path", this, rooms[1]));

        a = new Actable("fence");
        a.description =
        "\nThe old fence buckles and groans under its own weight" +
        "\nSeveral poiunts are nearly rusted through"+
        "\nYour powerful maw should make short work of its crude contruction";
        a.AddAction(new Eat("\nThe fence crumbles before your mighty white fangs" +
        "\nThe way east is clear", rooms[0], go));
        rooms[0].actables.Add(a);
            

    //stone path [1]
        a = new Actable("thistle");
        a.description = "\nThe prickly green leaves remind you of your forfeit kingdom" +
        "\nyou think to mourn, but steel your resolve.";
        a.AddAction(new Eat("\nThe thistle is so completely and thoroughly emancipated from existance that one could think that it never existed in the first place" +
        "\nYour sippling sinew surges with ancient power, the universe seems to cower in your precense" +
        "\nNothing can keep you from your dark desires"));
        rooms[1].actables.Add(a);

        a = new Actable ("west");
        a.description = "\nThe cell you just escaped from" +
        "\nOnly a fool would return to captivity alive";
        a.AddAction(new Move("\nYou saunter back into the damp relic of your oppression like a stonebrain donkey butt", this, rooms[0]));
        rooms[1].actables.Add(a);

        a = new Actable("north");
        a.description =
        "\noffice";
        a.AddAction(new Move("", this, rooms[4]));
        rooms[1].Add(a);

        a = new Actable("south");
        a.description =
        "\nminks";
        a.AddAction(new Move("", this, rooms[2]));
        rooms[1].Add(a);


    //southern cages [2]


        a = new Actable("north");
        a.description =
        "\npath";
        a.AddAction(new Move("", this, rooms[1]));
        rooms[2].Add(a);

        a = new Actable("south");
        a.description =
        "\npeacock";
        a.AddAction(new Move("", this, rooms[3]));
        rooms[2].Add(a);


    //peacock yard [3]
        a = new Actable("peacock");
        a.description =
        "\n";
        a.AddAction(new Eat(""));

        a = new Actable("north");
        a.description =
        "\nminks";
        a.AddAction(new Move("", this, rooms[2]));
        rooms[3].Add(a);


    //office [4]


        a = new Actable("north");
        a.description =
        "\ngate";
        a.AddAction(new Move("", this, rooms[5]));
        rooms[4].Add(a);
        
        a = new Actable("south");
        a.description =
        "\npath";
        a.AddAction(new Move("", this, rooms[1]));
        rooms[4].Add(a);


    //zoo gate [5]


        a = new Actable("north");
        a.description =
        "\nCrisp air wafts from beyond the gate"+
        "\nWhispering echoes of your glorious past from beyond the rigid structures of this hellish prison";
        a.AddAction(new Move("\nFresh wet earth in the distance beckons you to freedom,"+
        "\nYou take a step onwards, feeling the rocky pavement beneath your might paw,"+
        "\n\nA flash of light...\n\nA blaring horn...\n\nThe crushing weight of black rubber tires tearing into your ample frame..."+
        "\n\n\nAs if you could be so easily defeated by such a measly contraption!"+
        "\nIn a single swipe, you rip the car in half, then swallow each half whole"+
        "\nThe earth quakes at your feet as you march off to your new life", this, rooms[3]));
        rooms[5].Add(a);
        
        a = new Actable("south");
        a.description =
        "\noffice";
        a.AddAction(new Move("", this, rooms[4]));
        rooms[5].Add(a);

        room = rooms[0];
    }
}