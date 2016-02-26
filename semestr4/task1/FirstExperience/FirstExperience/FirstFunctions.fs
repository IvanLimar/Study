module FirstFunctions

let factorial n = List.fold (*) 1 [1..n]

let fibonacci n =
    let step (x, y) = (y, x + y)
    let rec loop list acc =
        match list with
            | head :: tail -> loop tail (step acc)
            | [] -> acc
    let temp = loop [1..n] (0, 1)
    fst temp

let reverseList list =
    let rec loop list acc =
        match list with
           | head :: tail -> loop tail (head :: acc)
           | [] -> acc
    loop list List.Empty

let rowOfPowers number firstDegree quantity =
    let rec loop list accList acc = 
        match list with
            | head :: tail -> loop tail ((acc / number) :: accList) (acc / number)
            | [] -> accList
    let temp = float (firstDegree + quantity)
    loop [1..quantity] List.Empty (number ** temp)
