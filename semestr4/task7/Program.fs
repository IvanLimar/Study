open System.IO
open System.Text.RegularExpressions
open System.Net
open System.Threading

let fetch (url : string) =
    let request = WebRequest.Create(url)
    use response = request.GetResponse()
    use stream = response.GetResponseStream()
    use reader = new StreamReader(stream)
    let text = reader.ReadToEnd()
    let regularExpression = new Regex("<a href=\"http://.+?\">")
    let urls = [for i in regularExpression.Matches(text) ->
                    let regularExpression = new Regex("\"http://.+?\"")
                    let first = regularExpression.Match(i.ToString())
                    let second = first.ToString()
                    second.Substring(1, second.Length - 2)]
    let fetch (url : string) =
        async {
            let request = WebRequest.Create(url)
            use! response = request.AsyncGetResponse()
            use stream = response.GetResponseStream()
            use reader = new StreamReader(stream)
            let text = reader.ReadToEnd()
            let tprintfn ftm =
                printf " Thread %d " Thread.CurrentThread.ManagedThreadId
                printfn ftm
            do tprintfn "%s - %d" url text.Length
        }
    ignore (List.map (fun x -> Async.Start (fetch x)) urls)
    
fetch "http://math.spbu.ru"