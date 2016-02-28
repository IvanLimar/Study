module Functions

let multiplyDigits number = 
    let rec makeDigitList number accumulator =
        match number with
            | negative when negative < 0 -> makeDigitList -number accumulator
            | positive when positive > 0 -> makeDigitList (number / 10) (number % 10 :: accumulator)
            | _ -> accumulator
    List.fold (*) 1 (makeDigitList number List.Empty)

let findFirstPosition (ls : list<'a>) number =
    let rec loop ls number accumulator currentElement =
        match (ls, currentElement) with
            | (head :: tail, notNumber) when notNumber <> number -> if tail.IsEmpty then -1 else loop tail number (accumulator + 1) tail.Head
            | (head :: tail, number) -> accumulator
            | ([], _) -> -1
    if ls.IsEmpty then -1 else loop ls number 0 ls.Head

let isPalindrome (line : string) =
    let rec loop ls (line : string) accumulator =
        match (ls, accumulator) with
            | (head :: tail, true) -> loop tail line ((=) line.[head] line.[line.Length - 1 - head])
            | (head :: tail, false) -> accumulator
            | ([], _) -> accumulator
    loop [0..(line.Length - 1) / 2] line true

let areDifferent ls =
    let sortedLs = List.sort ls
    let rec loop ls accumulator previous =
        let notEqual x y = x <> y
        match (ls, accumulator) with
            | (head :: tail, true) -> loop tail (notEqual head previous) head
            | (head :: tail, false) -> accumulator
            | ([], _) -> accumulator
    loop sortedLs.Tail true sortedLs.Head