using System.Collections.Generic;
using IOStream;
using System;

class Game{
    static int Main(){
        Game game = new Game();
        game.RealMain();

        System.Console.WriteLine("closing");
        System.Console.Read();
        return 0;
    }

    private List<Room> rooms;
    private Room room;
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
            if(input == "no")
                break;
            splitI = input.Split(' ');
            if()
        }
        return 0;
    }

    private void setup(){
        o += 
        "\nYou lay destitude in your grungy cell," +
        "\nimprisoned by a pack of hariless apes." +
        "\nTheir putrid stench coats the air of this humiliating prison.";

        room = new Room();
        room.description =
        "\nSome terrifying illness seems to have convinced these hindwalkers that they could contain you."+
        "\nTo their credit, three of the walls surrounding you are formed of rock." +
        "\nThe remaining wall, to the east, is of glass." +
        "\nYour captors have left you with a small bowl of water";

        Actable a = new Actable("bowl");
        a.AddAction(new Act("eat", "You scronch down the poor bowl," +
        "\ncold metal nuroushing your ample frame." +
        "\nthe water, once held, now damprns the muddy ground." +
        "\nthis was lethargic."));
        room.actables.Add(a);
        rooms.Add(room);
    }
}