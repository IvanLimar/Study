module PhoneBook

open System.IO
open System

let phoneBook =
    let filePath = new FileInfo("book.txt")
    let rec loop command ls =
        let rec printList ls =
            match ls with
                | (head :: tail) -> printfn "%A" head
                                    printList tail
                | ([]) -> ()
        match command with
            | "0" -> ()
            | "1" -> printfn "Enter 'name' 'phone'"
                     let line = Console.ReadLine();
                     let split = line.Split(' ');
                     if split.Length = 2
                     then printfn "Writing complete. Enter command."
                          let newCommand = Console.ReadLine();
                          loop newCommand ((split.[0], split.[1]) :: ls)
                     else printfn "Wrong format! Try again!"
                          printfn "Enter command."
                          let newCommand = Console.ReadLine();
                          loop newCommand ls
                          
            | "2" -> printfn "Enter 'phone'"
                     let phone = Console.ReadLine();
                     let persons = List.map (fun x -> fst x) (List.filter (fun x -> snd x = phone) ls)
                     if persons.IsEmpty 
                     then printfn "There is nobody with phone numbes %s. Try again." phone 
                     else printfn "Owners of %s" phone
                          printList persons
                     printfn "Enter command."
                     let newCommand = Console.ReadLine();
                     loop newCommand ls
                                          
            | "3" -> printfn "Enter 'name'"
                     let name = Console.ReadLine();
                     let phones = List.map (fun x -> snd x) (List.filter (fun x -> fst x = name) ls)
                     if phones.IsEmpty 
                     then printfn "There are not any %s's phone numbers. Try again" name 
                     else printfn "%s's phone numbers" name 
                          printList phones
                     printfn "Enter command."
                     let newCommand = Console.ReadLine();
                     loop newCommand ls
                     
            | "4" -> let writer = filePath.CreateText();
                     for i in ls do writer.WriteLine(i.ToString())
                     writer.Close()
                     printfn "Writing complete"
                     printfn "Enter command."
                     let newCommand = Console.ReadLine();
                     loop newCommand ls
                     
            | "5" -> if not filePath.Exists
                     then printfn "File doesn't exist. Firstlt, writre data into file."
                          printfn "Enter comand"
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
                          printfn "Reading comlete"
                          printfn "Enter command."
                          let newCommand = Console.ReadLine();
                          loop newCommand newLs
             
             | "Help" | "help" | "HELP" -> printfn "0 - exit"
                                           printfn "1 - add 'name', 'phone'"
                                           printfn "2 - find persons with entered 'phone'"
                                           printfn "3 - find phones, which are belonged to 'person'"
                                           printfn "4 - write into file"
                                           printfn "5 - read from file"
                                           printfn "Enter command."
                                           let newCommand = Console.ReadLine();
                                           loop newCommand ls
             
             | _ -> printfn "Wrong command. Enter 'help'"
                    let newCommand = Console.ReadLine();
                    loop newCommand ls                           
    loop "help" []               