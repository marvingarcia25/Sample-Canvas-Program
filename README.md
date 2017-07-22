# Simple-Canvas-Program
This is a simple .Net Core 1.1 console application of a drawing program that enables the user to draw
in a canvas(i.e draw a line, draw a rectangle, bucketfill). It uses xUnit for testing. 

This project was done using Test Driven Development.

In a nutshell, the program work as follows:
 1. Create a new canvas
 2. Start drawing on the canvas by issuing various commands
 3. Quit
 
## Instructions 
* At first we need to create a canvas that we can use to draw. 

  The program will display like below to read your first command:
  
            enter command:
  
* Now we will type the command below to create a canvas with width = 20 and height = 4 :
     * SYNTAX :  C Width, Height
            
            enter command: C 20 4
     
     
      
     
* We will notice that a canvas was created as below:

            enter command: C 20 4
            ----------------------
            |                    |
            |                    |
            |                    |
            |                    |
            ----------------------
* To draw a line, use the command below:  
      * SYNTAX : L x1,y1,x2,y2
      
            enter command: L 1 2 6 2
            ----------------------
            |                    |
            |xxxxxx              |
            |                    |
            |                    |
            ----------------------
            enter command: L 6 3 6 4
            ----------------------
            |                    |
            |xxxxxx              |
            |     x              |
            |     x              |
            ----------------------
      
      This will draw a line from axis x1,y1 = 1,2 to axis x2,y2 = 6,2.
      Also, a line from axis x1,y1 = 6,3  to  axis  x2,y2 = 6,4
    
* To draw a rectangle, use the command below:
       * SYNTAX : R x1,y1,x2,y2

            enter command: R 14 1 18 3
            ----------------------
            |             xxxxx  |
            |xxxxxx       x   x  |
            |     x       xxxxx  |
            |     x              |
            ----------------------
            
      This will create a rectangle where the upper left corner starts from x,y = 14,1  and 
      lower right corner as x,y = 18,3.
      
* We can also make use of the Bucket Fill functionality of this program.  The behaviour of this is the same as that of the "bucket fill" tool in paint
  programs.
        * SYNTAX : B x y charToUse
        
            enter command: B 10 3 o
            ----------------------
            |oooooooooooooxxxxxoo|
            |xxxxxxooooooox   xoo|
            |     xoooooooxxxxxoo|
            |     xoooooooooooooo|
            ----------------------
            
      This will do a fill to all the surroundings of x,y = 3 just like in paint programs. 
      
* The last command that we will use is the command to quit the program:
      * SYNTAX : Q
      
            enter command: Q
            
## Technical Requirements
  1. .Net Core 1.1 Framework
  2. To debug, use Visual Studio 2017.
  3. Install xUnit if needed.

## Assumptions
  1. .Net Core Framework framework was used to implement this program, assuming that the server where this program will be deployed will also have a .net core 1.1 framework installed.
  2. The program was designed as simple as possible, assuming that for this exercise, it will be judged in a wholistic approach  that includes, but not limited to, requirements gathering, testability, maintainability, scalability.
  3. Visual Studio 2017 was used to develop the program, assuming that Visual Studio 2017 also will be used for future development.
  
## Limitiations
 * The maximum width of the canvas was set to 77 in the app-settings.json file to have a better rendering when used via command prompt.
 * Lines and Rectangles will be drawn using "X" as default.
 * No logging yet
