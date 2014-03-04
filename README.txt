DiceWare Password Generator
---------------------------

The project is a password generator using the DiceWare scheme described at http://world.std.com/~reinhold/diceware.html
It is a C# project, build against .Net v4 in VS2010.

I've included a set of word list files in DiceWareLib/WordLists.  The name of each text file is what is displayed in the GUI's language dropdown and the string that must be passed to the /lang switch on the console app.
The internal data format is "<dice code>\t<word>\r\n".

I have no idea if the data in the files is any good.  I just grabbed some of the internet to test against.