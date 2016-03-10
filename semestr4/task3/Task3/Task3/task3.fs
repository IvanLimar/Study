module task3

let testList = [1; 2; 2; 1; 0; -2; 4; 6]

printfn "Tested list: %A" testList
printfn ""

let QuantityOfEvenNumbersWithMap ls =
    List.sum (List.map (fun x -> ((x % 2) + 1) % 2) ls)
    
let QuantityOfEvenNumbersWithFilter ls =
    List.length (List.filter (fun x -> x % 2 = 0) ls)
        
let QuantityOfEvenNumbersWithFold ls =
    List.fold (fun x y -> x + ((y % 2) + 1) % 2) 0 ls
    
let test1 = QuantityOfEvenNumbersWithMap testList
let test2 = QuantityOfEvenNumbersWithFilter testList
let test3 = QuantityOfEvenNumbersWithFold testList

printfn "Quantity of even numbers (first variant): %i" test1
printfn "Quantity of even numbers (second variant): %i" test3
printfn "Quantity of even numbers (third variant): %i" test2
printfn ""

let findMaximumNeighbours ls =
    let rec loop ls currentIndex currentMaximum accumulator =
        match (ls, currentIndex) with
            | (head :: tail, 0) -> if tail.IsEmpty then 0 else loop tail 1 (head + tail.Head) 0
            | (head :: tail, _) -> if tail.IsEmpty
                                   then accumulator
                                   else let temp = head + tail.Head
                                        let nextIndex = currentIndex + 1
                                        if temp > currentMaximum
                                        then loop tail nextIndex temp currentIndex
                                        else loop tail nextIndex currentMaximum accumulator
            | ([], 0) -> -1
            | ([], _) -> accumulator
    loop ls 0 0 0
    
let maximumNeighbours = findMaximumNeighbours testList

printfn "Index of maximum neighbours: %i" maximumNeighbours
printfn ""

type Tree<'a> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec heigthOfTree tree =
    match tree with
        | Tree(_, left, rigth) -> 1 + max (heigthOfTree left) (heigthOfTree rigth)
        | Tip(_) -> 1

let tip = Tip 5
let node = Tree (4, tip, tip)
let testTree = Tree (1, node, tip)        
let testHeigth = heigthOfTree testTree

printfn "Height of test tree : %i" testHeigth
printfn ""
        
type ArithmeticalExpression =
    | Number of int
    | Sum of ArithmeticalExpression * ArithmeticalExpression
    | Difference of ArithmeticalExpression * ArithmeticalExpression
    | Multiplication of ArithmeticalExpression * ArithmeticalExpression
    | Division of ArithmeticalExpression * ArithmeticalExpression

let rec countExpression expression =
    match expression with
        | Number(value) -> value
        | Sum(first, second) -> countExpression first + countExpression second
        | Difference(first, second) -> countExpression first - countExpression second
        | Multiplication(first, second) -> countExpression first * countExpression second
        | Division(first, second) -> countExpression first / countExpression second

let testExpression = Multiplication(Sum(Number 5, Number 2), Difference(Number 5, Number 3))
let calculated = countExpression testExpression

printfn "(5 + 2) * (5 - 3) = %i" calculated
printfn ""
    
                        
let rowOfPrimeNumbers =
    let primeNumber i =
        let rec loop ls (row : seq<'a>) accumulator =
            let currentPrimeNumber = Seq.head row
            let newRow = Seq.filter (fun x -> x % currentPrimeNumber <> 0) row
            match ls with
                | (head :: tail) -> loop tail newRow currentPrimeNumber
                | ([]) -> accumulator
        loop [0..i] (Seq.initInfinite (fun i -> i + 2)) 0
    Seq.initInfinite primeNumber
    
printfn "Prime numbers: %A" rowOfPrimeNumbers