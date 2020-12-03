open System
open System.IO

let data =
    File.ReadAllLines @"./Projects/Julekalender2020/Day2Dataset.txt"
    |> Seq.map (fun x -> x.Split(' '))
    |> Seq.toList

let minmax (str: String) =
    let range = str.Split '-'
    let min = range.[0] |> int
    let max = range.[1] |> int
    (min, max)

let numUsed (char: char) (str: String) =
    str
    |> Seq.filter (fun x -> x = char)
    |> Seq.length

let getChars (str: String) (min: int) (max: int) = (str.[min - 1], str.[max - 1])
let toChar (str: String) = str.[0] |> char

let doCheck (chars: char * char) (c: char) =
    if (fst chars) = (snd chars) then false else fst chars = c || snd chars = c

let oppg1 =
    data
    |> Seq.filter (fun x ->
        let mm = minmax x.[0]
        let num = numUsed (toChar x.[1]) (x.[2])
        num >= fst (mm) && num <= snd (mm))
    |> Seq.length

let oppg2 =
    data
    |> Seq.filter (fun x ->
        let mm = minmax x.[0]
        let chars = getChars (x.[2]) (fst (mm)) (snd (mm))
        doCheck chars (toChar x.[1]))
    |> Seq.length
