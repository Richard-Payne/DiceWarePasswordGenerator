namespace DiceWarePasswordGenerator

open System
open System.IO
open System.Linq
open System.Security.Cryptography

type WordListEntry = { Code:string; Word:string }

type public PasswordGenerator(wordListPath:string) =    

    let rngCsp = new RNGCryptoServiceProvider()

    let isFairRoll (roll:byte) (numSides:byte) =
        // There are MaxValue / numSides full sets of numbers that can come up 
        // in a single byte.  For instance, if we have a 6 sided die, there are 
        // 42 full sets of 1-6 that come up.  The 43rd set is incomplete. 
        let fullSetsOfValues = Byte.MaxValue / numSides

        // If the roll is within this range of fair values, then we let it continue. 
        // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use 
        // < rather than <= since the = portion allows through an extra 0 value). 
        // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair 
        // to use. 
        roll < numSides * fullSetsOfValues    

    // This method simulates a roll of the dice. The input parameter is the 
    // number of sides of the dice. 
    let rec rollDice(numberSides:byte) =
        if numberSides <= 0uy then
            raise <| ArgumentOutOfRangeException("numberSides")

        let numArray = [|0uy..0uy|]
        rngCsp.GetBytes(numArray)
        match (isFairRoll numArray.[0] numberSides) with
        | false -> rollDice numberSides
        | true -> numArray.[0] % numberSides + 1uy

    let readFileLine (reader : StreamReader) = 
        match reader.ReadLine() with
        | null -> None
        | line -> Some(line)

    let readFileLines filePath filter =
        let output:WordListEntry list = []

        use stream = new FileStream(filePath, FileMode.Open, FileAccess.Read)
        use reader = new StreamReader(stream)

        let inner (reader:StreamReader) filter (output:WordListEntry list) = 
            match (readFileLine reader) with
            | None -> output
            | Some text -> 
                let parts = text.Split('\n')
                let word = { Code=parts.[0]; Word=parts.[1] }                
                match (filter word) with
                | false -> output
                | true -> word :: output

        inner reader filter output 
        |> List.rev

    let generateRandomWordId =
        String.Join("", (Seq.init 5 (fun _ -> (rollDice 6uy).ToString "0")))

    let generate(numWords:int, language:string) =
        if language.Trim() = "" then
            invalidArg "language" "Language must not be empty"
        else if numWords < 1 then
            invalidArg "numWords" "Number of Word must be greater than zero!"
        else
            // If * is passed in, choose a random language
            let wordListFile =  
                if "*".Equals(language) then
                    // Choose word list at random
                    let wordListFiles = Directory.EnumerateFiles(wordListPath)
                    let wordListLen = byte (wordListFiles.Count() - 1)
                    wordListFiles.ElementAt (int (rollDice wordListLen))
                else
                    language + ".txt"

            let wordKeys = Seq.init numWords (fun _ -> generateRandomWordId)

            let filePath = Path.Combine(wordListPath, wordListFile)
            let words = readFileLines filePath (fun word -> wordKeys |> Seq.contains word.Code)
            let orderedWords = wordKeys |> Seq.map (fun key -> (words |> List.find(fun word -> key = word.Code)).Word)
                                        |> Seq.toList

            String.Join(" ", orderedWords)