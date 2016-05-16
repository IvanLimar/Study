open System
open System.Threading

let sum =

    let array = [|for i in 1..1000000 -> 1|]
    
    let result = ref 0

    let threads = [for i in 0..99 -> 
                       new Thread(ThreadStart(fun _ -> 
                           let rec loop indexLs acc =
                               match indexLs with
                                   | (head::tail) -> loop tail (acc + array.[head])
                                   | [] -> acc
                           let startIndex = 10000 * i
                           let partialSum = loop [startIndex..startIndex + 9999] 0
                           result := !result + partialSum))]

    for i in threads do 
        i.Start()
 
    !result

let result = sum
printfn "%i" result