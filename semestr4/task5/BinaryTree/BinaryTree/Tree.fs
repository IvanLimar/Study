module tree

open System
open System.Collections
open System.Collections.Generic
open iterator

exception CompareError of string

type Tree<'a when 'a :> IComparable> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of ('a option)
        with    
            member private this.linearize =
                let rec loop tree accumulator =
                    match tree with
                        | Tree(value, left, right) -> let rightList = loop right List.Empty
                                                      loop left ((value :: rightList) @ accumulator)
                                              
                        | Tip(node) -> match node with
                                           | None -> accumulator
                                           | Some(value) -> value :: accumulator
                loop this List.empty
                    
            member tree.Add element =
                match tree with
                    | Tree(value, left, right) -> let temp = value.CompareTo(element)
                                                  match temp with
                                                      | negative when negative < 0 -> Tree(value, left, right.Add element)
                                                      | positive when positive > 0 -> Tree(value, left.Add element, right)
                                                      | 0 -> Tree(value, left, right)
                                                      | _ -> raise (CompareError("Compare error"))
                                  
                    | Tip(value) -> match value with
                                        | None -> Tip(Some(element))
                                        | Some(value) -> let temp = value.CompareTo(element) 
                                                         match temp with
                                                             | negative when negative < 0 -> Tree(value, Tip(None), Tip(Some(element)))
                                                             | positive when positive > 0 -> Tree(value, Tip(Some(element)), Tip(None))
                                                             | 0 -> Tip(Some(value))
                                                             | _ -> raise (CompareError("Compare error"))
            static member Empty = Tip(None)
            
            member tree.IsEmpty =
                match tree with
                    | Tree(_) -> false
                    | Tip(value) -> match value with
                                        | None -> true
                                        | Some(_) -> false
                                        
            member tree.Contains element =
                match tree with
                    | Tree(value, left, right) -> let temp = value.CompareTo(element)
                                                  match temp with
                                                      | negative when negative < 0 -> right.Contains element
                                                      | positive when positive > 0 -> left.Contains element
                                                      | 0 -> true
                                                      | _ -> raise (CompareError("Compare error"))
                                  
                    | Tip(value) -> match value with
                                        | None -> false
                                        | Some(value) -> value.CompareTo(element) = 0
                                        
            member tree.Remove element =
                let mostLeftValue tree =
                    let rec loop tree acc =
                        match tree with
                            | Tree(value, left, right) -> let temp = loop left value
                                                          if value.CompareTo(temp) = 0
                                                          then loop right value
                                                          else temp
                            | Tip(value) -> match value with
                                                | Some(value) -> value
                                                | None -> acc
                    
                    match tree with
                        | Tree(value, left, right) -> Some(loop tree value)
                        | Tip(nodeValue) -> match nodeValue with
                                                | None -> None
                                                | Some(value) -> Some(value)
                 
                match tree with
                    | Tree(value, left, right) -> let temp = value.CompareTo(element)
                                                  match temp with
                                                      | negative when negative < 0 -> Tree(value, left, right.Remove element)
                                                      | positive when positive > 0 -> Tree(value, left.Remove element, right)
                                                      | 0 -> let temp = mostLeftValue right
                                                             match temp with
                                                                 | None -> left
                                                                 | Some(value) -> Tree(value, left, right.Remove value)
                                                      | _ -> raise (CompareError("Compare error"))
                                                      
                    | Tip(node) -> match node with
                                       | None -> Tip(None)
                                       | Some(value) -> Tip(None)
            
            interface IEnumerable<'a> with
                member this.GetEnumerator() =
                    (new TreeIterator<'a>(this.linearize) :> IEnumerator<'a>)
                member this.GetEnumerator() =
                    (new TreeIterator<'a>(this.linearize) :> IEnumerator)
                    
let mutable testTree = Tree.Tip(Some(5))
testTree <- testTree.Add 9
testTree <- testTree.Add 5
testTree <- testTree.Add 7
testTree <- testTree.Add 8
testTree <- testTree.Add 4
testTree <- testTree.Add 1
testTree <- testTree.Add 3
testTree <- testTree.Add 2
testTree <- testTree.Add 10
testTree <- testTree.Add 18
testTree <- testTree.Add 6

printfn "First traversal:"

for x in testTree do printfn "%i" x  

printfn ""
printfn "Contains 9: %A" (testTree.Contains 9)
printfn "Contains 15: %A" (testTree.Contains 15)

printfn "After removing 9, 5, 18:"

testTree <- testTree.Remove 9
testTree <- testTree.Remove 5
testTree <- testTree.Remove 18

printfn ""
printfn "Contains 9: %A" (testTree.Contains 9)
printfn "Contains 1: %A" (testTree.Contains 1)


printfn "Contains 5: %A" (testTree.Contains 5)

printfn "Second traversal:"

for x in testTree do printfn "%i" x