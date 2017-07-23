# Simple-Canvas-Program
This is a simple .Net Core 1.1 console application of a drawing program that enables the user to draw
in a canvas(i.e draw a line, draw a rectangle, bucketfill). It uses xUnit for testing. 

This project was done using Test Driven Development.

In a nutshell, the program work as follows:
 1. Create a new canvas
 2. Start drawing on the canvas by issuing various commands
 3. Quit
 
## Instructions 
* Below are the following Commands available:
	
	* C - create a canvas
			SYNTAX: 		C <Width> <Height>
			Description: 	This will create a canvas with the following <Width> and <Height>
			Example:		C 20 4 - will create a canvas with width = 20 and height = 4.
			
	NOTE: axis(x,y) - refers to a point in the canvas
	
	* L - draw a line
			SYNTAX:			L <x1> <y1> <x2> <y2>
			Description:	This will draw a line from axis(x1,y1) to axis(x2,y2).
			Example:		L 1 2 6 2 - will create a line from axis(1,2) to axis(6,2).
	* R - draw a rectangle
			SYNTAX:			R <x1> <y1> <x2> <y2>
			Description:	This will draw a rectangle with the upper left corner = axis(x1,y1) and
							lower right corner = axis(x2,y2)
			Example:		R 14 1 18 3	- will create a rectangle with the upper left corner = axis(14,1) and
							lower right corner = axis(18,3)		
	* B - bucketfill , just like ms paint bucketfill functionality
			SYNTAX:			B <x> <y> <charToUse>
			Description:	This will do a fill to all the surroundings of x,y = axis(x,y) with <charToUse> just like in paint programs. 
							<charToUse> can be any single alpha numeric character.
			Example:		B 10 3 o- will do a bucketfill to all the surroundings of axis(10,3) with 'o' just like in paint programs.
	* Q - quit the program
			SYNTAX: 		Q
			Description:	This will quit the program and remove everything that is stored in the memory.
			Example:		Q
	
* At first we need to create a canvas that we can use to draw. 

  The program will display like below to read your first command:
  
            enter command:
  
* Now we will type the command below to create a canvas with width = 20 and height = 4 :
            
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
      
      The first command will draw a line from axis(1,2) to axis(6,2).
      The second command will draw a line from axis(1,2) to axis(6,2).
    
* To draw a rectangle, use the command below:

            enter command: R 14 1 18 3
            ----------------------
            |             xxxxx  |
            |xxxxxx       x   x  |
            |     x       xxxxx  |
            |     x              |
            ----------------------
            
      This will create a rectangle where the upper left corner starts from axis(14,1)  and 
      lower right corner is axis(18,3)
      
* We can also make use of the Bucket Fill functionality of this program.  The behaviour of this is the same as that of the "bucket fill" tool in paint
  programs.
        
            enter command: B 10 3 o
            ----------------------
            |oooooooooooooxxxxxoo|
            |xxxxxxooooooox   xoo|
            |     xoooooooxxxxxoo|
            |     xoooooooooooooo|
            ----------------------
            
      This will do a bucketfill to all the surroundings of axis(x,y) with 'o' just like in paint programs. 
      
* The last command that we will use is the command to quit the program:
      * SYNTAX : Q
      
            enter command: Q
            
* To clear the canvas again, just recreate the canvas using the create command.

			enter command: C 20 4
            ----------------------
            |                    |
            |                    |
            |                    |
            |                    |
            ----------------------
## Technical Requirements
  1. .Net Core 1.1 Framework
  2. To debug, use Visual Studio 2017.
  3. Install xUnit if needed.

## Assumptions
  1. L and R commands assumed that the X and Y axis are below or equal the width and height of the created canvas. Otherwise it will throw an error.
  2 .Net Core Framework framework was used to implement this program, assuming that the server where this program will be deployed will also have a .net core 1.1 framework installed.
  3. The program was designed as simple as possible, assuming that for this exercise, it will be judged in a wholistic approach  that includes, but not limited to, requirements gathering, testability, maintainability, scalability.
  4. Visual Studio 2017 was used to develop the program, assuming that Visual Studio 2017 also will be used for future development.
  5. The user is assumed that he/she knows how bucketfill works in mspaint programs.
  
## Limitiations
 * The maximum width of the canvas was set to 77 in the app-settings.json file to have a better rendering when used via command prompt.
 * Lines and Rectangles will be drawn using "X" as default.
 * No logging yet
 * The Bucket fill functionality is limited to use 1 char only. If command like "B 10 3 GH" was used, only "G" will be used to fill the canvas
 * Drawline is limited to horizontal and vertical lines only. Diagonal lines are currently not supported.
