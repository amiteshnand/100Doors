using System;
using System.Text;

namespace Katas_100Doors
{
  class Program
  {
    static void Main(string[] args)
    {
      Doors[] doors = new Doors[100];
      
      for(var i = 0; i < 100; i++)
      {
        doors[i] = new Doors();
      }
      
      var doorsOpen = new StringBuilder();
      int x = 1;
      
      for (var pass = 1; pass<101;pass++)
      { 
        doorsOpen.AppendLine("Pass " + pass + ":");

        foreach (Doors door in doors)
        {
          //First pass - open each door
          if(pass == 1)
          { 
            door.DoorState = "@";
            doorsOpen.AppendLine("Door " + x + " is opened");
            //x++;
          } else if (pass == 2) //Second pass - close every second door
          {
            if(x % pass == 0)
            { 
              door.DoorState = "#";
              doorsOpen.AppendLine("Door " + x + " is closed");
              //x++;
            }
          } else //Third pass and onwards, toggle every Nth door
          {
            if(x % pass == 0)
            { 
              var currentDoorState = door.DoorState.ToString();
              door.DoorState = ToggleDoor(currentDoorState);
              doorsOpen.AppendLine("Door " + x + " is toggled: " + door.DoorState.ToString());
            }
          }
          x++;
        } 

        Console.WriteLine(doorsOpen.ToString());
        x = 1;
        doorsOpen.Clear();
      }
    
      static string ToggleDoor(string _doorState)
      { 
        string newDoorState = "";  

        if(_doorState == "#")
        {
          newDoorState = "@";
        } else if (_doorState == "@")
        { 
          newDoorState = "#";      
        }
    
      return newDoorState;
      }   
    }

    private class Doors
    {
      public string DoorState { get; set; } = "#";
    }
  }
}
