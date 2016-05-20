open System
open System.Threading

let sum =

    let array = [|for i in 1..1000000 -> 1|]
    
    let flags = [|for i in 1..100 -> false|]
    
    let result = ref 0

    let threads = [for i in 0..99 -> 
                       new Thread(ThreadStart(fun _ -> 
                           let rec loop indexLs acc =
                               match indexLs with
                                   | (head::tail) -> loop tail (acc + array.[head])
                                   | [] -> acc
                           let startIndex = 10000 * i
                           let partialSum = loop [startIndex..startIndex + 9999] 0
                           flags.[i] <- true
                           result := !result + partialSum))]

    for i in threads do 
        i.Start()

    while (not (Array.forall id flags)) do ()
 
    !result

let result = sum
printfn "%i" result