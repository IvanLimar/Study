open System

let alternatingSignRow =
    let alternatingSignUnities = Seq.initInfinite (fun i -> if i % 2 = 0 then 1 else -1)
    Seq.mapi (fun index element -> (index + 1) * element) alternatingSignUnities
    
printfn "%A" alternatingSignRow

exception EmptyStack of string
  
type Stack<'a>(element : 'a) =
    let mutable (ls : list<'a>) = element :: List.empty
    member stack.Push element =  ls <- element :: ls 
    member stack.IsEmpty = ls.IsEmpty
    member stack.Pop =
        if ls.IsEmpty 
        then raise(EmptyStack("Stack is empty"))
        else let result = ls.Head
             ls <- ls.Tail
             result

let stack = Stack<int>(5)
stack.Push 1
stack.Push 0
let x = stack.Pop
let a = stack.IsEmpty
let y = stack.Pop
let z = stack.Pop
let c = stack.IsEmpty
let k = stack.Pop

let theBiggestPalindrome =
    let rec findMax ls acc =
        let rec findMaxLoop ls accumulator =
            match ls with
                | (head :: tail) -> let isPalindrome number =
                                        let ls = [for i in number.ToString() -> i]
                                        (=) ls (List.rev ls)
                                    if isPalindrome head
                                    then if head > accumulator then findMaxLoop tail head
                                                               else findMaxLoop tail accumulator
                                    else findMaxLoop tail accumulator
                | [] -> accumulator
        match ls with
            | (head :: tail) ->  let temp = findMaxLoop (List.map ((*) head) [100..999]) acc
                                 if temp > acc then findMax tail temp
                                               else findMax tail acc                                
            | [] -> acc
    findMax [100..999] 0
    
let result = theBiggestPalindrome

let superMap func ls =
    let rec loop ls acc =
        let rec innerLoop ls acc =
            match ls with
                | (head :: tail) -> innerLoop tail (head :: acc)
                | [] -> acc
        match ls with
            | (head :: tail) -> let accumulator = innerLoop (List.rev (func head)) acc
                                loop tail accumulator
            | [] -> acc
    loop (List.rev ls) List.empty
    
let resultSuperMapResult = superMap (fun x -> [x; x * x]) [2.0; 3.0]