using System;
using System.Drawing;

namespace Runner
{
    class MazeDriver
    {
        //Runs the project as a collective.
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                String inputPath = args[0]; //First argument inserted in cmd
                String outputPath = args[1]; //Second argument inserted in cmd
                try
                {
                    Bitmap bmpOr = new Bitmap(inputPath); //Generates new bitmap from relative input path
                    Maze maze = new Maze(bmpOr);
                    Bitmap bmp = maze.printPath(); //Generates a solution set of the maze and returns it in bitmap form.
                    if (bmp != null) 
                        bmp.Save(outputPath); //Saves bitmap to relative output path
                    else
                        Console.WriteLine("No possible maze solution.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
                Console.WriteLine("Incorrect amount of arguments.");
        }
    }
}
