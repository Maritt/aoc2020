open System
open System.IO
open System.Collections


let data =
    File.ReadAllLines @"./Projects/Julekalender2020/Day3Dataset.txt"

let isTree (char: char) = char = '#'

let intervals =
    [ (1, 1)
      (3, 1)
      (5, 1)
      (7, 1)
      (1, 2) ]

let countTrees (interval: int * int) =
    let mutable x = 0
    let mutable y = 0
    let mutable counter = 0
    let width = data.[0].Length
    while y < data.Length - 1 do
        x <- (x + fst interval) % width
        y <- y + snd interval
        if isTree (data.[y].[x] |> char) then counter <- counter + 1
    counter

let oppg2 =
    intervals
    |> Seq.map countTrees
    |> Seq.fold (fun acc next -> (acc * next)) 1
