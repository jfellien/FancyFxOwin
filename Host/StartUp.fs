namespace FancyFxOwin

open Owin
open Nancy
open Nancy.Bootstrapper
open Nancy.Owin

type StartUp() =
    inherit DefaultNancyBootstrapper()

    member this.Configuration(app: IAppBuilder) =
        app.UseNancy()
        |> ignore


    // override this.ApplicationStartup(container:TinyIoCContainer, pipelines:IPipelines) =

    // override this.ConfigureApplicationContainer(container:TinyIoCContainer) =
        