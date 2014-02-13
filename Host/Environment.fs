namespace FancyFxOwin

open System
open System.Net
open Microsoft.Owin.Hosting
open Microsoft.WindowsAzure.ServiceRuntime

type Environment() = 
    inherit RoleEntryPoint()

    let mutable webApp = 
        Unchecked.defaultof<IDisposable>

    let withOptions = 
        StartOptions()

    let doNothing = 
        ()

    let setMaxConnections count = 
        ServicePointManager.DefaultConnectionLimit <- count

    let assign_Address (options:StartOptions) = 
    #if DEBUG
        let baseUri = "http://+:8080"
    #else
        let httpsEndpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.["Https-Endpoint"]
        let baseUri = sprintf "%s://%A" httpsEndpoint.Protocol httpsEndpoint.IPEndpoint
    #endif
       
        options.Urls.Add(baseUri)
        options

    let init_WebApp (options:StartOptions) = 
        webApp <- WebApp.Start<StartUp>(options) 

    member this.Closing = 
        match webApp with
        | null -> doNothing
        | _    -> webApp.Dispose()

    member this.Start connections = 
        setMaxConnections connections

        withOptions
        |> assign_Address
        |> init_WebApp
    
    override this.OnStart() = 
        
        this.Start 12
        base.OnStart()

    override this.OnStop() = 

        base.OnStop()