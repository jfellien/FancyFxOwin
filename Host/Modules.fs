namespace FancyFxOwin.Modules

open System
open Nancy
open Nancy.Extensions

type YourNancyModule() as this = 
    inherit NancyModule()
    
    let toString o = 
        o.ToString()

    do
        this.Get.["/"] <- fun _ -> this.greeting
        this.Post.["/"] <- fun p -> this.postIt p
     

    member this.greeting = 
        "Hallo Welt"
        |> this.Response.AsText
        |> box

    member this.postIt param = 
        param
        |> toString
        |> this.Response.AsText 
        |> box