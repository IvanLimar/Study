open FirstFunctions

let printTest (func : int -> int) funcName firstNNumbers =
        let rec loop list acc =
            printfn "%s(%d) = %d" funcName acc (func acc)
            match list with
                | head :: tail -> loop tail (acc + 1)                                  
                | [] -> ()
        loop [-1..(firstNNumbers - 1)] -1
        ()

let toString list = 
    let rec loop list acc =
        match list with
            | head :: tail -> loop tail (acc + head.ToString() + "; ")
            | [] -> acc + "]"
    loop list "[ "

[<EntryPoint>]
let main args =
    printTest factorial "fact" 15
    printTest fibonacci "fib" 15
    let inputList = [1..7]
    let inputLine = toString inputList
    let outputLine = toString (reverseList inputList)
    printfn "Reverse %s = %s" inputLine outputLine
    let outputLine = toString (rowOfPowers 2.0 0 5)
    printfn "Powers of 2: %s" outputLine
    0