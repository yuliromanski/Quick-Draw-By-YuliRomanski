using System.Diagnostics;



const string Menu = @"Quick Draw Face your opponent and wait for the signal. Once the signal is given, shoot tour opponent by pressing [space] before they  shoot you. It's all about your reaction time.
Choose Your Opponent:
[1] Easy....1000 milliseconds
[2] Medium...500 milliseconds
[3] Hard.....250 milliseconds
[4] Harder...125 milliseconds";


const string Fire = @"

      _O               O_
      |/|_    Fire    _|\|
      /\                /\
     / |                | \

          [SPACEBAR]

-------------------------------";
const string Wait = @"

       _O          O_
      |/|_  wait  _|\|
       /\           /\
      / |           | \
-------------------------------";
const string LoseTooFast = @"

              TOO FAST     > ╗__O
      //                       / \
     O/__/\   YOU LOSE           /\
           \                     | \

------------------------------------------------------";

const string LoseTooSlow = @"

              TO  SLOW     > ╗__O
      //                       / \
     O/__/\   YOU LOSE           /\
           \                     | \

-------------------------------";

const string Win = @"

       O__╔ <
      / \                  \\
        /\   *You Win*   /\__\O
       / |              /
    
------------------------------------------------------";

Random random = new Random();


while (true)
{
    Console.Clear();
    Console.WriteLine(Menu);
    TimeSpan requiredReactionTime;
    string playerInput = Console.ReadLine();



    switch (playerInput)
    {
        case "1":

            requiredReactionTime = TimeSpan.FromMilliseconds(1000);

            break;

        case "2":

            requiredReactionTime = TimeSpan.FromMilliseconds(0500);

            break;

        case "3":

            requiredReactionTime = TimeSpan.FromMilliseconds(0250);
            break;

        case "4":

            requiredReactionTime = TimeSpan.FromMilliseconds(0125);

            break;

        default:

            continue;
    }
    random.Next();

    Console.Clear();

    TimeSpan signal = TimeSpan.FromMilliseconds(random.Next(5000, 10000));

    Stopwatch stopwatch = new Stopwatch();

    stopwatch.Restart();

    Console.WriteLine(Wait);

    bool isToofast = false;

    while (stopwatch.Elapsed < signal && !isToofast)
    {


        if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Spacebar)
        {
         
            
            isToofast = true;
        }
    }
    Console.Clear();


    if (isToofast)
    {


        Console.WriteLine(LoseTooFast);



    }
    else
    {
        
        
        
        Console.WriteLine(Fire);
        stopwatch.Restart();

        bool isTooSlow = true;


        TimeSpan reactionTime = default;

        while (stopwatch.Elapsed < requiredReactionTime && isTooSlow)

        {
            if (Console.KeyAvailable)
            {

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Spacebar)
                {

                    isTooSlow = false;
                    reactionTime = stopwatch.Elapsed;

                }
            }
        }
        Console.Clear();

        if (isTooSlow)
        {

            Console.WriteLine(LoseTooSlow);
        }

        else
        {
            Console.WriteLine(Win);

            Console.WriteLine($"Reaction time: " + $"{reactionTime.TotalMilliseconds} milliseconds");

        }
    }
    Console.Write("Press [1] to Play again or [2] to quit: ");

    string stayOrLeave = Console.ReadLine();

    if (stayOrLeave == "2")
    {
        Console.Clear();
        Console.Write("Quick Draw was closed.");
        break;
    }
}