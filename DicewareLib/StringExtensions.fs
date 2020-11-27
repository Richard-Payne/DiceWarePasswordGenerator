namespace DiceWarePasswordGenerator

open System

[<Runtime.CompilerServices.Extension>]
module StringExtensions =
    [<Runtime.CompilerServices.Extension>]
    let SafeSubString(str : string, start : int, length : int) =
        str.Substring(start, Math.Min(length, str.Length - start))
