open System.Collections.Generic
open System

type Tree<'a when 'a :> IComparable> =
    | Tree of 'a * Tree<'a> * Tree<'a>
    | Tip of ('a option)
        with
            member tree.Add element=
                match tree with
                    | Tree(value, left, right) -> let temp = value.CompareTo(element)
                                                  match temp with
                                                      | negative when negative < 0 -> Tree(value, left, right.Add element)
                                                      | positive when positive > 0 -> Tree(value, left.Add element, right)
                                                      | 0 -> Tree(value, left, right)
                                  
                    | Tip(value) -> match value with
                                        | None -> Tip(Some(element))
                                        | Some(value) -> let temp = value.CompareTo(element) 
                                                         match temp with
                                                             | negative when negative < 0 -> Tree(value, Tip(None), Tip(Some(element)))
                                                             | positive when positive > 0 -> Tree(value, Tip(Some(element)), Tip(None))
                                                             | 0 -> Tip(Some(value))
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
                    | Tip(node) -> match node with
                                       | None -> Tip(None)
                                       | Some(value) -> Tip(None)
                                       
type TreeIterator(tree) =
    let linearize tree =
        let rec loop tree accumulator =
            match tree with
                | Tree(value, left, right) -> let rightList = loop right List.Empty
                                              loop left (value :: rightList)
                                              
                | Tip(node) -> match node with
                                   | None -> accumulator
                                   | Some(value) -> value :: accumulator
        loop tree List.empty
        
    let fullList = linearize tree
    let mutable currentList = fullList
    
    member iter.Current =
        match currentList with
            | (head :: tail) -> Some(head)
            | [] -> None
            
    member iter.Next = if currentList.IsEmpty then [] else currentList.Tail
    
    member iter.Reset = currentList <- fullList