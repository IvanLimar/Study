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