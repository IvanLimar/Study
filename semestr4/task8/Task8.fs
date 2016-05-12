open System
open System.Threading

let sum =

    let array = [|for i in 1..1000001 -> 1|]
    
    let result = ref 0

    let threads = [for i in 1..100 -> new Thread(ThreadStart(fun _ -> Thread.CurrentThread.Name <- i.ToString()
                                                                      let startIndex =  1 + 10000 * (System.Int32.Parse(Thread.CurrentThread.Name) - 1)
                                                                      for j in startIndex..startIndex + 9999 do
                                                                          Monitor.Enter(result)
                                                                          try
                                                                              result := !result + array.[j]
                                                                          finally
                                                                              Monitor.Exit(result)))]

    for i in threads do 
        i.Start()
 
    !result
    
printfn "%i" sum