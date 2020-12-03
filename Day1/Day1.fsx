open System
open System.IO

let data =
    File.ReadAllLines @"./Projects/Julekalender2020/Day1Dataset.txt"
    |> Seq.map Int32.Parse
    |> Seq.toList

let res list =
    [ for i in list do
        for j in list do
            for k in list do
                if (i + j + k) = 2020 then yield i * j * k ]

let answer = res data
