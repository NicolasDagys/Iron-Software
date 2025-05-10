using System;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //the console application can be use introduceing the message directly or 
        // putting the numerical sequence as a parameter. For that jus comment this 
        // section and uncomment after //EXAMPLES
        Console.WriteLine("Old Phone Pad");
        Console.WriteLine("Enter the message with number between 1 to 9 as it was an old phone keypad, end the message with #");

        string? MessageInNumbers = Console.ReadLine();
        if(MessageInNumbers != null)
        {
            Console.WriteLine(OldPhonePad(MessageInNumbers));
        }

//Examples
// Console.WriteLine(OldPhonePadOldPhonePad(“33#”).ToString() // E
// Console.WriteLine(OldPhonePadOldPhonePad(“227*#”).ToString() // B
// Console.WriteLine(OldPhonePadOldPhonePad(“4433555 555666#”).ToString() // HELLO
//Console.WriteLine(OldPhonePad("8 88777444666*664#").ToString());  //TURING
//Console.ReadLine();

    }




    public static string OldPhonePad(string ImputStr)
{
    //create a dictionary to map the pad
    Dictionary<char,string> KeyPad = new Dictionary<char, string>() 
    //I wil use char instead of int to avoid haveing to convert later, in a phone should
    //  look like this:
    {
                    {'2', "ABC"}, {'3', "DEF"}, 
      {'4', "GHI"}, {'5', "JKL"}, {'6', "MNO"},
      {'7', "PQRS"}, {'8', "TUV"}, {'9', "WXYZ"},
                    {'0', " "}
    };
    //create a string Builder to build the output string, StringBuilder
    //  it's more efficient that using string += letter
        StringBuilder Message = new StringBuilder();
        StringBuilder CurrentLetter = new StringBuilder();

        //now a fe to go through the input string and determinate if is a
        //special character (#,* or '') or a letter. Using a switch instead of if/esle if would be more efficient
        foreach (char C in ImputStr)
        {
            switch (C)
            {
                case '#': //indicates the end of the message
                    if (CurrentLetter.Length > 0)
                    {
                        Process(CurrentLetter, KeyPad, Message);
                        CurrentLetter.Clear();
                    }
                    break;

                
                
                case '*': // it deletes the last letter
                    if (CurrentLetter.Length > 0)
                    {
                        Process(CurrentLetter, KeyPad, Message); // Process the current letter before clearing
                        CurrentLetter.Clear();
                    }
                    if (Message.Length > 0)
                    {
                        Message.Remove(Message.Length - 1, 1); // This deletes the last letter written
                    }
                        break;

                case ' ': //space
                    if (CurrentLetter.Length > 0)
                    {
                        Process(CurrentLetter, KeyPad, Message);
                        CurrentLetter.Clear();
                    }
                    break;

                default:
                    if (char.IsDigit(C) && KeyPad.ContainsKey(C))
                    {
                        if (CurrentLetter.Length > 0 && CurrentLetter[0] != C)
                        {
                            // if the number changes then, it will process the previous one 
                            Process(CurrentLetter, KeyPad, Message);
                            CurrentLetter.Clear();
                        }
                        CurrentLetter.Append(C); //appends adds in the last position
                    }
                    break;
            }
        }
       return Message.ToString();
                
}
//instead of useing a switch for all the letters, I use a method to process the number and 
//get the letter even when the digit is repeated
private static void Process(StringBuilder sequence, Dictionary<char, string> keypad, StringBuilder output)
    {
        char key = sequence[0]; // the first character is the key. it's the same 7 than 77
        int count = sequence.Length; // is the number of times the key is repeated

        if (keypad.ContainsKey(key)) // check if the key is in the keypad
        {
            string letters = keypad[key]; //it gets the letters for that number
            int index = (count - 1) % letters.Length; //Determines which letter to select 
            // based on how many times the number was pressed. count - 1 because the first 
            // position is 0. 

            output.Append(letters[index]);
        }
    }
}