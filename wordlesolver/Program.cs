string currentWord = "irate";
string result;
bool solved = false;
Console.WriteLine("Start with irate and put in what you got (g=green y=yellow b=blank)");
List<string> lines = new List<string>(System.IO.File.ReadAllLines(@"D:\useful_stuff\5_letter_words.txt"));
while (!solved)
{
    result = Console.ReadLine();
    if (result.Length == 5)
    {
        //loop through every character in the result of blanks,yellows or greens
        for (int i = 0; i < 5; i++)
        {
            // if result is blank remove all words with that letter
            if (result[i] == 'b')
            {
                for (int j = 0; j < lines.Count; j += 1)
                {

                    if (lines[j].ToLower().Contains(currentWord[i]))
                    {

                        lines.RemoveAt(j);
                    }
                }
            }
            // if result is yellow then remove all words without that letter
            if (result[i] == 'y')
            {
                lines.RemoveAll(line => !line.Contains(currentWord[i]));
                lines.RemoveAll(line => line[i] == currentWord[i]);
            }
            // if result is green do the same but check if it is in the right spot
            if (result[i] == 'g')
            {
                lines.RemoveAll(line => line[i] != currentWord[i]);
            }

        }

        currentWord = lines[0];
        Console.WriteLine(currentWord);

    }
    else if (result == "solved")
    {
        Console.WriteLine("Congratulations");
        solved = true;
    }
    else
    {
        Console.WriteLine("that is not 5 letters long");
    }

}
