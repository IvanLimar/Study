module PhoneBook

open System.IO
open System

let phoneBook =
    let filePath = new FileInfo("book.txt")
    let rec loop (command : string) ls =
        let rec printList ls =
            match ls with
                | (head :: tail) -> printfn "%A" head
                                    printList tail
                | [] -> ()
        let nextIteration ls =
            printfn "Enter command:"
            let newCommand = Console.ReadLine()
            loop newCommand ls
            
        let find case ls =
            let target = Console.ReadLine()
            let result case ls =
                match case with
                    | "2" -> List.map (fun x -> fst x) (List.filter (fun x -> snd x = target) ls)
                    | "3" -> List.map (fun x -> snd x) (List.filter (fun x -> fst x = target) ls)
                    | _ -> List.empty
            let res = result case ls
            if res.IsEmpty
            then printfn "Nothing was found. Try again."
            else printfn "Result:"
                 printList res
        match command.ToLower() with
            | "0" -> ()
            | "1" -> printfn "Enter 'name' 'phone':"
                     let line = Console.ReadLine();
                     let split = line.Split(' ');
                     if split.Length = 2
                     then printfn "Writing complete."
                          nextIteration ((split.[0], split.[1]) :: ls)
                     else printfn "Wrong format! Try again!"
                          nextIteration ls
                          
            | "2" -> printfn "Enter 'phone':"
                     find "2" ls
                     nextIteration ls
                                          
            | "3" -> printfn "Enter 'name'"
                     find "3" ls
                     nextIteration ls
                     
            | "4" -> let writer = filePath.CreateText();
                     let rec write ls =
                        match ls with
                            | (head :: tail) -> writer.WriteLine(head.ToString())
                                                write tail
                            | [] -> ()
                     write ls
                     writer.Close()
                     printfn "Writing complete"
                     nextIteration ls
                     
            | "5" -> if not filePath.Exists
                     then printfn "File doesn't exist. Firstly, writre data into file."
                          printfn "Enter command"
                     else let reader = filePath.OpenText()
                          let rec innerLoop ls =
                              if (not reader.EndOfStream)
                              then let line = reader.ReadLine();
                                   let line2 = line.Trim('(', ')')
                                   let line3 = line2.Replace(",", "")
                                   let line4 = line3.Split(' ')
                                   innerLoop ((line4.[0], line4.[1]) :: ls)
                              else reader.Close()
                                   ls
                          let newLs = innerLoop ls
                          printfn "Reading complete"
                          nextIteration newLs
             
             | "help" -> printfn "0 - exit"
                         printfn "1 - add 'name', 'phone'"
                         printfn "2 - find persons with entered 'phone'"
                         printfn "3 - find phones, which are belonged to 'person'"
                         printfn "4 - write into file"
                         printfn "5 - read from file"
                         nextIteration ls
             
             | _ -> printfn "Wrong command. Try 'help'"
                    nextIteration ls                      
    loop "help" []               