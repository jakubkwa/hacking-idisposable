# Hacking `IDisposable`

> ## `IDisposable` Interface
>
> ### Definition
>
> Provides a mechanism for releasing unmanaged resources.

This is the first sentence you can read about `IDisposable` interface in the [Microsoft documentation](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-6.0).

In this repository however you can see different usage of this interface than for releasing resources. This is not really hacking the interface, but it is a usage outside of the definition, so in this sense it's trying to explore the undocumented ways of using it - that's why it has this clickbaity title.

These examples base on the `using` statement, which is a language structure I tend to like, that's why I use it even for places that it was not designed for.
