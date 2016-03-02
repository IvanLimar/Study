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

let isPalindrome line =
    let ls = [for i in line -> i]
    let reverseList ls =
        let rec loop ls accumulator =
            match ls with
                | head :: tail -> loop tail (head :: accumulator)
                | [] -> accumulator
        loop ls List.Empty
    let rec loop ls reverseLs lsLength i accumulator =
        match (ls, reverseLs, i, accumulator) with
            | (head :: tail, reverseHead :: reverseTail, normal, true) when normal >= 0 && normal <= (lsLength - 1) / 2 -> loop tail reverseTail lsLength (i + 1) ((=) head reverseHead)
            | (head :: tail, reverseHead :: reverseTail, notNormal, _) when notNormal > (lsLength - 1) / 2 -> accumulator
            | (head :: tail, reverseHead :: reverseTail, _, false) -> accumulator
            | ([], [], _, _) -> accumulator
    loop ls (reverseList ls) ls.Length 0 true

let areDifferent ls =
    let sortedLs = List.sort ls
    let rec loop ls accumulator previous =
        let notEqual x y = x <> y
        match (ls, accumulator) with
            | (head :: tail, true) -> loop tail (notEqual head previous) head
            | (head :: tail, false) -> accumulator
            | ([], _) -> accumulator
    if sortedLs.IsEmpty then true else loop sortedLs.Tail true sortedLs.Head