namespace TGWeb.Controllers
open System
open System.Collections.Generic
open System.Linq
open System.Net.Http
open System.Web.Http

open canopy
open runner

/// Retrieves values.
[<RoutePrefix("api2/values")>]
type ValuesController() =
    inherit ApiController()
    let values = [|"value1";"value2"|]

    /// Gets all values.
    [<Route("")>]
    member x.Post([<FromBody>] value:string) = 
        let y = x.Request
        start chrome
        url value
        try
            let expected = "Hello world!"
            click "hello world"
            let text = read "#output"
            quit()
            if text = expected then "success" else sprintf "failure: text was '%s' but expected '%s'" text expected
        with
            | _ ->  
                quit()
                "failure"

    /// Gets the value with index id.
    [<Route("{id:int}")>]
    member x.Get(id) : IHttpActionResult =
        if id > values.Length - 1 then
            x.BadRequest() :> _
        else x.Ok(values.[id]) :> _